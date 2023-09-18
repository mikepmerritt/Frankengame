using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCounter : MonoBehaviour
{
    public SpriteRenderer Light1, Light2, Light3;
    public Color BrokenColor;
    public int Lives = 3; // used to track number of collisions
    public static int NumDestroyed = 0;
    
    public void TakeDamage() {
        if(Lives == 3) {
            Light3.color = BrokenColor;
            Lives--;
        }
        else if(Lives == 2) {
            Light2.color = BrokenColor;
            Lives--;
        }
        else {
            NumDestroyed++;
            Destroy(this.gameObject);
        }
    }
}
