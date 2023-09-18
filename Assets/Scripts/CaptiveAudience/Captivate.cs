using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Captivate : MonoBehaviour
{
    public static event Action<bool> CaptivateStart;
    public static bool Distracted; // bool to check if a flare is currently affecting the destroyer, since events dont work otherwise

    void Start() {
        Distracted = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !Distracted)
        {
            CaptivateStart.Invoke(true);
        }
    }
}
