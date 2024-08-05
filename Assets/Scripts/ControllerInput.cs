using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ValueObjects;

public class ControllerInput : MonoBehaviour
{
    public ActionFloatObject eventObject;
    public float k;

    private void FixedUpdate()
    {
        var force = Input.GetAxis("Axis 3");
        if (force != 0)
        {
            eventObject.Invoke(force * k);
        }
    }
}
