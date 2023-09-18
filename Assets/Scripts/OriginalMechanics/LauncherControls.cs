using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LauncherControls : MonoBehaviour
{
    public static event Action LaunchRocket;
    public static bool RocketActive;
    public FloatVariable LauncherSpeed;
    public GameObject Rocket, Flare;

    private void Start() {
        RocketActive = false;
    }

    private void Update() {
        if(!RocketActive) {
            // launch with space
            if(Input.GetKeyDown(KeyCode.Space) && LaunchRocket != null) {
                RocketActive = true;
                LaunchRocket.Invoke();
            }

            // switch with x
            if(Input.GetKeyDown(KeyCode.X) && LaunchRocket != null) {
                if(Rocket.activeSelf) {
                    Rocket.SetActive(false);
                    Flare.SetActive(true);
                }
                else {
                    Rocket.SetActive(true);
                    Flare.SetActive(false);
                }
            }
        }
    }

    private void FixedUpdate() {
        if(!RocketActive) {
            float horizontal = Input.GetAxisRaw("Horizontal");
            transform.position += new Vector3((horizontal * LauncherSpeed.value) * Time.deltaTime, 0, 0);
            Rocket.transform.position = new Vector3(transform.position.x, Rocket.transform.position.y, Rocket.transform.position.z);
            Flare.transform.position = new Vector3(transform.position.x, Flare.transform.position.y, Flare.transform.position.z);
        }
    }
}
