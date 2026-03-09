using UnityEngine;
using ValueObjects;

public class WheelBoostController : MonoBehaviour
{
    public Rigidbody2D wheel;

    public FloatObject boostForce;
    public BoolObject grounded;

    public ActionVoidObject eventObject;

    private bool isGrounded;
    private bool isBoosted;

    public void Awake()
    {
        eventObject.AddListener(OnBoost);
        grounded.OnValueChanged += ResetBoost;
    }

    private void OnDestroy()
    {
        eventObject.RemoveListener(OnBoost);
        grounded.OnValueChanged -= ResetBoost;
    }

    private void ResetBoost(bool oldGrounded, bool newGrounded)
    {
        isGrounded = newGrounded;
        if (!oldGrounded && newGrounded && isBoosted)
        {
            isBoosted = false;
        }
    }

    public void OnBoost()
    {
        if (!isGrounded && !isBoosted)
        {
            isBoosted = true;

            Vector2 force = wheel.linearVelocity.normalized * boostForce.Value;
            wheel.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
