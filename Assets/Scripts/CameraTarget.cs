using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ValueObjects;

public class CameraTarget : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera virtualCamera;
    public TransformObject target;

    private void OnTargetChanged(Transform transform1, Transform transform2)
    {
        virtualCamera.Follow = transform2;
    }

    private void Awake()
    {
        target.OnValueChanged += OnTargetChanged;
    }

    private void OnDestroy()
    {
        target.OnValueChanged -= OnTargetChanged;
    }
}
