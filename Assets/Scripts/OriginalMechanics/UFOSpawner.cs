using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UFOSpawner : MonoBehaviour
{
    public GameObject UFO;
    public Vector3 SpawnPos; // off screen position to put new UFOs at
    public TMP_Text Score;
    void Update()
    {
        if(Object.FindObjectOfType<CollisionCounter>() == null) { // if there is no UFO
            Instantiate(UFO, SpawnPos, Quaternion.identity); // add new one
            UpdateScore(); // update score
        }
    }

    private void UpdateScore() {
        Score.text = "UFOs: " + CollisionCounter.NumDestroyed;
    }
}
