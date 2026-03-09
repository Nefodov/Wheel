using UnityEngine;
using ValueObjects;

public class WheelSlamController : MonoBehaviour
{
    public Rigidbody2D wheel;

    public FloatObject slamForce;
    public BoolObject grounded;

    public ActionVoidObject eventObject;

    private bool isGrounded;
    private bool isSlamed;

    public void Awake()
    {
        eventObject.AddListener(OnSlam);
        grounded.OnValueChanged += ResetSlam;
    }

    private void OnDestroy()
    {
        eventObject.RemoveListener(OnSlam);
        grounded.OnValueChanged -= ResetSlam;
    }

    private void ResetSlam(bool oldGrounded, bool newGrounded)
    {
        isGrounded = newGrounded;
        if (!oldGrounded && newGrounded && isSlamed)
        {
            isSlamed = false;
        }
    }

    public void OnSlam()
    {
        if (!isGrounded && !isSlamed)
        {
            isSlamed = true;

            Vector2 force = Vector2.down * slamForce.Value;
            wheel.linearVelocity = Vector2.zero;
            wheel.angularVelocity = 0;
            wheel.AddForce(force, ForceMode2D.Impulse);
        }
    }
}