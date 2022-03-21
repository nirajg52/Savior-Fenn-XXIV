using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]class GameData
{
    public string position;
    public string healthValue;
    public int totalCoin;
}

public class GameSaveManager : MonoBehaviour
{

    
    public Transform player;

    public GameObject coinPrefab;

    public Slider heathSlider;


    public void OnSaveButton_Pressed()
    {
        SaveGame();
    }

    public void OnLoadButton_Pressed()
    {
        LoadGame();
    }

    void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat");
        GameData gameData = new GameData();
        gameData.position = JsonUtility.ToJson(player.position);
        gameData.healthValue = JsonUtility.ToJson(heathSlider.value);
        bf.Serialize(file, gameData);
        file.Close();
        Debug.Log("Game data saved!");
    }

    void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            GameData gameData = (GameData)bf.Deserialize(file);
            file.Close();
            player.gameObject.GetComponent<PlayerMovement>().enabled = false;
            player.position = JsonUtility.FromJson<Vector3>(gameData.position);
            player.gameObject.GetComponent<PlayerMovement>().enabled = true;

            //for health
            heathSlider.gameObject.GetComponent<UIControls>().enabled = false;
            heathSlider.value = JsonUtility.FromJson<float>(gameData.healthValue);
            heathSlider.gameObject.GetComponent<UIControls>().enabled = true;


            Debug.Log("Game data loaded!");
        }
        else
        {

        }
    }
    }
