using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMove : MonoBehaviour
{
    public bool MovingLeft;
    public FloatVariable LeftEnd, RightEnd, Speed;

    private void Start()
    {
        MovingLeft = true;        
    }

    private void FixedUpdate()
    {
        // move left to an endpoint, then stop and turn
        if(MovingLeft) {
            if(transform.position.x > LeftEnd.value) {
                transform.position -= new Vector3(Speed.value * Time.deltaTime, 0, 0);
            }
            else {
                MovingLeft = false;
            }
        }
        // move right to an endpoint, then stop and turn
        else {
            if(transform.position.x < RightEnd.value) {
                transform.position += new Vector3(Speed.value * Time.deltaTime, 0, 0);
            }
            else {
                MovingLeft = true;
            }
        }
    }
}
