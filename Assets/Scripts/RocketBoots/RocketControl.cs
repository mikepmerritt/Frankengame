using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public FloatVariable speedChange, maxSpeed;
    public FloatVariable LaunchSpeed;
    public Collider2D coll;

    private void OnEnable() {
        LauncherControls.LaunchRocket += LaunchRocket;
    }

    private void OnDisable() {
        LauncherControls.LaunchRocket -= LaunchRocket;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(LauncherControls.RocketActive) { // if the rocket is deployed
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetKey(KeyCode.Space) ? 1 : 0; // if space is held, go up (speed of 1), otherwise don't (0)

            // add speed to rocket, unless at top speed already
            Vector2 newVelocity = rb.velocity + new Vector2((horizontal * speedChange.value) * Time.deltaTime, (vertical * speedChange.value) * Time.deltaTime);
            if(newVelocity.magnitude > maxSpeed.value) {
                newVelocity.Normalize();
                newVelocity *= maxSpeed.value;
            }
            rb.velocity = newVelocity;
        }
    }

    private void LaunchRocket() {
        rb.isKinematic = false; // unfreeze object when launched
        coll.enabled = true; // reenable collider
        rb.velocity = new Vector2(0, LaunchSpeed.value);
    }
    
}
