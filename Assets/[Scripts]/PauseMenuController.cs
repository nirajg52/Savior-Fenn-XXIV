using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public bool isSpeeded = false;
    public Color activatedColor;
    public Button increaseSpeedButton;

    // Update is called once per frame

    public void PauseOnButtonPressed()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        if(isSpeeded){
            Time.timeScale = 2f;
        } else{
            Time.timeScale = 1f;
        }
        
        gameIsPaused = false;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach(AudioSource a in audios)
        {
            a.Pause();
        }
    }


    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu Scene");
    }

    public void onClickIncreaseSpeed(){
        isSpeeded = true;
        ColorBlock cb = increaseSpeedButton.colors;
        cb.normalColor = activatedColor;
        cb.highlightedColor = activatedColor;
        cb.pressedColor = activatedColor;
        cb.selectedColor = activatedColor;
        cb.disabledColor = activatedColor;
        increaseSpeedButton.colors = cb;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
