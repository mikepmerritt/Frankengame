using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollision : MonoBehaviour
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
        ReloadRocketInLauncher();
    }

    private void Update() {
        ReloadRocketInLauncher();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<CaptivateChecker>() != null) {
            // dont explode, this is the radius for the flare prompt and not an obstacle
        }
        else if(other.gameObject.GetComponent<CollisionCounter>() != null) { // this means it hit the UFO, so do damage
            other.gameObject.GetComponent<CollisionCounter>().TakeDamage();
            DestroyRocket();
        }
        else {
            DestroyRocket();
        }
        
    }

    // track launcher position
    public void ReloadRocketInLauncher() {
        if(!LauncherControls.RocketActive && LaunchPosition != Vector3.zero) { // if the rocket is not deployed
            LaunchPosition = new Vector3(Launcher.transform.position.x, LaunchPosition.y, LaunchPosition.z);
            transform.position = LaunchPosition;
        }
    }

    private void DestroyRocket() {
        Instantiate(Explosion, transform.position, Quaternion.identity); // spawn explosion object where collision occurred
        ReloadRocketInLauncher();
        rb.velocity = Vector2.zero;
        rb.isKinematic = true; // freeze object until launched
        coll.enabled = false; // disable collider
        LauncherControls.RocketActive = false; // move player back to launcher controls
    }
}
