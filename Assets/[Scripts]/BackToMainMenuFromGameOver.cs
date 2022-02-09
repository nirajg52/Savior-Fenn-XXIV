using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenuFromGameOver : MonoBehaviour
{
    

    // Update is called once per frame
    public void LoadScene()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }
}
