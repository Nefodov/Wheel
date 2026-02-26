using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    public ParticleSystem _particleSystem;
    public void Emit()
    {
        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();

        emitParams.position = new Vector3(10,10,10);
        _particleSystem.Emit(emitParams, 1);
    }

}
