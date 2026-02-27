using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using ValueObjects;

public class InputToFloatAction : MonoBehaviour
{
    public InputActionReference inputAction;
    public ActionFloatObject eventObject;
    public float k;

    private Coroutine _holdingCoroutine;

    private void OnEnable()
    {
        if (inputAction?.action != null)
        {
            inputAction.action.Enable();
            inputAction.action.started += StartHolding;
            inputAction.action.canceled += StopHolding;
        }
    }

    private void OnDisable()
    {
        if (inputAction?.action != null)
        {
            StopHolding(default);
            inputAction.action.started -= StartHolding;
            inputAction.action.canceled -= StopHolding;
            inputAction.action.Disable();
        }
    }

    private void StartHolding(InputAction.CallbackContext context)
    {
        if (_holdingCoroutine == null)
        {
            _holdingCoroutine = StartCoroutine(HoldRoutine());
        }
    }

    private void StopHolding(InputAction.CallbackContext context)
    {
        if (_holdingCoroutine != null)
        {
            StopCoroutine(_holdingCoroutine);
            _holdingCoroutine = null;

            eventObject.Invoke(0);
        }
    }

    private IEnumerator HoldRoutine()
    {
        while (true)
        {
            float value = inputAction.action.ReadValue<float>();
            eventObject.Invoke(value * k);

            yield return new WaitForFixedUpdate();
        }
    }
}