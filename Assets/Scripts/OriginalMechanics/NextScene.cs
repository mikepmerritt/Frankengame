using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void LoadGame() {
        SceneManager.LoadScene(1); // game scene is 1
    }
}
