using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{

    [Header("Volume Setting")]
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1f;

    [Header("Game Play")] 
    [SerializeField] private Slider sensitivitySlider = null;
    [SerializeField] private int defaultSensitivity = 5;
    public int mainSensitivity = 5;

    [Header("Toggle")] [SerializeField] private Toggle invertY = null;


    [Header("Level to Load")] 
    public string newGame;
    public string loadLevelto;

   /* [Header("Confirmation Prompt")]
    [SerializeField] private GameObject confirmationPrompt = null;*/

    [SerializeField] private GameObject noSaveDialog = null;

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(newGame);
    }

    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("Saved Level"))
        {
            loadLevelto = PlayerPrefs.GetString("Saved Level");
            SceneManager.LoadScene(loadLevelto);
        }

        else
        {
            noSaveDialog.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        
    }

    public void Apply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        //StartCoroutine(ConfirmationBox());

    }

    public void SetSensitivity(float sensitivity)
    {
        mainSensitivity = Mathf.RoundToInt(sensitivity);
    }

    public void GamePlayApply()
    {
        PlayerPrefs.SetInt("masterInvertY", invertY.isOn ? 1 : 0);

        PlayerPrefs.SetFloat("masterSensitivity", mainSensitivity);
       // StartCoroutine(ConfirmationBox());
    }

    public void Reset(string MenuType)
    {
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            Apply();
        }

    }

    /*public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }*/

}
