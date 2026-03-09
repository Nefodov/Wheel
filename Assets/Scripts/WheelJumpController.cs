using UnityEngine;
using ValueObjects;

public class WheelJumpController : MonoBehaviour
{
    public Rigidbody2D wheel;

	public FloatObject jumpForce;

	public Vector2Object point;
	public Vector2Object normal;

    public ActionVoidObject eventObject;

    public void Awake()
    {
        eventObject.AddListener(OnJump);
    }
    private void OnDestroy()
    {
        eventObject.RemoveListener(OnJump);
    }

    public void OnJump()
    {
        wheel.AddForce(normal.Value * jumpForce.Value, ForceMode2D.Impulse);
    }
}
