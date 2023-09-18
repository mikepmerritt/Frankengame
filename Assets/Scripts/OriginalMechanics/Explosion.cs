using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public bool Expanding;

    private void Start() {
        Expanding = true;
    }

    private void Update()
    {
        // explosion gets large quickly
        if(Expanding) {
            if(transform.localScale.x < 1f) {
                transform.localScale += new Vector3(Time.deltaTime * 5, Time.deltaTime * 5, 0);
            }
            else {
                Expanding = false;
            }
        }
        // then gets smaller
        else {
            if(transform.localScale.x > 0f) {
                transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, 0);
            }
            else {
                Destroy(gameObject); // goes away when no longer visible
            }
        }
        
    }
}
