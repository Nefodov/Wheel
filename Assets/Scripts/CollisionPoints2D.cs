using UnityEngine;

public class CollisionPoints2D : MonoBehaviour
{
    public ValueObjects.Vector2Object point;
    public ValueObjects.Vector2Object normal;

    [Space]
    public bool drawNormal;
    public bool drawPoints;

    const int MaxContacts = 32;

    ContactPoint2D[] contacts = new ContactPoint2D[MaxContacts];
    int contactCount = 0;

    void OnCollisionStay2D(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount && contactCount < MaxContacts; i++)
        {
            contacts[contactCount++] = collision.GetContact(i);

            if (drawPoints)
            {
                var contact = contacts[contactCount - 1];
                Vector2 point = contact.point;
                Vector2 normal = contact.normal;

                Debug.DrawRay(point, -normal, Color.red);
            }
        }
    }

    private void FixedUpdate()
    {
        if (point == null || normal == null)
        {
            Debug.LogError("Vector2Object field is empty");
            return;
        }

        if (contactCount > 1)
        {
            GetFarthestPoints(out var point1, out var point2);

            Vector2 avgPoint = (point1.point + point2.point) / 2;
            Vector2 avgNormal = (point1.normal + point2.normal).normalized;

            point.Value = avgPoint;
            normal.Value = avgNormal;

            if (drawNormal)
                Debug.DrawRay(avgPoint, -avgNormal, Color.blue);
        }
        else if(contactCount == 1)
        {
            point.Value = contacts[0].point;
            normal.Value = contacts[0].normal;

            if (drawNormal)
                Debug.DrawRay(contacts[0].point, -contacts[0].normal, Color.blue);
        }
        else
        {
            point.Value = Vector2.zero;
            normal.Value = Vector2.zero;
        }

        contactCount = 0;
    }

    public void GetFarthestPoints(out ContactPoint2D point1, out ContactPoint2D point2)
    {
        point1 = contacts[0];
        point2 = contacts[0];
        float maxDistanceSqr = -1f;

        for (int i = 0; i < contactCount; i++)
        {
            for (int j = i + 1; j < contactCount; j++)
            {
                // Use sqrMagnitude to avoid expensive Square Root calculations
                float distSqr = (contacts[i].point - contacts[j].point).sqrMagnitude;

                if (distSqr > maxDistanceSqr)
                {
                    maxDistanceSqr = distSqr;
                    point1 = contacts[i];
                    point2 = contacts[j];
                }
            }
        }
    }
}
