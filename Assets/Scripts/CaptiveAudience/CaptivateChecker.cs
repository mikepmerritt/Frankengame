using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CaptivateChecker : MonoBehaviour
{
    public static event Action<float> CountDown;
    private bool inRange = false;
    private Quaternion startRot;
    public GameObject prompt;
    private void Start()
    {
        startRot = transform.rotation;
    }//stores original rotation for later.
    private void OnEnable()
    {
        Captivate.CaptivateStart += CaptivateCheck;
        MovementReset.CountdownFinish += ResetRot;
    }
    private void OnDisable()
    {
        Captivate.CaptivateStart -= CaptivateCheck;
        MovementReset.CountdownFinish -= ResetRot;
    }
    private void CaptivateCheck(bool checking)
    {
        if (inRange == true)
        {
            Vector3 target = UnityEngine.Object.FindObjectOfType<FlareCollision>().transform.position;
            float theta = -Mathf.Atan2(target.x - transform.position.x, target.y - transform.position.y) * 180 / Mathf.PI; // find angle to rotate to so it can face the flare
            transform.eulerAngles = new Vector3(0f, 0f, theta + 90); // +90 because its accidentally started in right pos

            CountDown.Invoke(5);
        }//rotates guard to the direction of the performer player upon captivation. starts cooldown of 5 to return to original rotation.
    }
    private void ResetRot(bool rot)
    {
        transform.rotation = startRot;
    }//sets to original rotation, called after cooldown is over.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<FlareCollision>() != null)
        {
            inRange = true;
            prompt.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<FlareCollision>() != null)
        {
            inRange = false;
            prompt.SetActive(false);
        }
    }
}
