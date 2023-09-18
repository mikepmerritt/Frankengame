using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareCollision : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 LaunchPosition;
    public GameObject Explosion;
    public LauncherControls Launcher;
    public Collider2D coll;

    private void Start()
    {
        LaunchPosition = transform.position;
        Launcher = Object.FindObjectOfType<LauncherControls>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        ReloadFlareInLauncher();
    }

    private void Update() {
        ReloadFlareInLauncher();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<CaptivateChecker>() != null) {
            // dont explode like every other time, might not need to
        }
        else {
            DestroyFlare();
        }
    }

    // track launcher position
    public void ReloadFlareInLauncher() {
        if(!LauncherControls.RocketActive && LaunchPosition != Vector3.zero) { // if the rocket is not deployed
            LaunchPosition = new Vector3(Launcher.transform.position.x, LaunchPosition.y, LaunchPosition.z);
            transform.position = LaunchPosition;
        }
    }

    public void DestroyFlare() {
        Instantiate(Explosion, transform.position, Quaternion.identity); // spawn explosion object where collision occurred
        ReloadFlareInLauncher();
        rb.velocity = Vector2.zero;
        rb.isKinematic = true; // freeze object until launched
        coll.enabled = false; // disable collider
        LauncherControls.RocketActive = false; // move player back to launcher controls
    }
}
