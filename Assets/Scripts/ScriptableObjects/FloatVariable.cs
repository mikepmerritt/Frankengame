using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    public float initValue;
    public float value;

    private void OnEnable() {
        value = initValue;
    }
}
