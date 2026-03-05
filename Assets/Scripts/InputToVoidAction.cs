using UnityEngine;
using UnityEngine.InputSystem;
using ValueObjects;

public class InputToVoidAction : MonoBehaviour
{
    public InputActionReference inputAction;
    public ActionVoidObject eventObject;

    private void OnEnable()
    {
        if (inputAction?.action != null)
        {
            inputAction.action.Enable();
            inputAction.action.started += InputStarted;
        }
    }

    private void OnDisable()
    {
        if (inputAction?.action != null)
        {
            inputAction.action.started -= InputStarted;
            inputAction.action.Disable();
        }
    }

    private void InputStarted(InputAction.CallbackContext context)
    {
        eventObject.Invoke();
    }
}