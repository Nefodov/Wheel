using System;
using UnityEditor;
using UnityEngine;
using ValueObjects;

public class Teleporter : MonoBehaviour
{
    public StringObject targetTag;
    public Vector3 destination;
    [Space]
    [Space]
    public bool resetVelocity;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(targetTag.Value))
        {
            Teleport(collider.transform);
        }
    }

    private void Teleport(Transform target)
    {
        if (target.TryGetComponent<Rigidbody2D>(out var rb))
        {
            if (resetVelocity)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = 0;
            }

            rb.position = destination;
        }
        else
        {
            target.transform.position = destination;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.DrawLine(transform.position, destination);
    }
#endif

}
