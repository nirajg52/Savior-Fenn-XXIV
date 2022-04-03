using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]class GameData
{
    public string position;
    public string healthValue;
    public string totalCoin;
    public string enemyPosition;
}

public class GameSaveManager : MonoBehaviour
{

    public Transform enemy;

    public Transform player;

    public TextMeshProUGUI coinText;

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
        gameData.enemyPosition = JsonUtility.ToJson(enemy.position);
        gameData.totalCoin = JsonUtility.ToJson(coinText.text);
        
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
            
            coinText.text = JsonUtility.FromJson<string>(gameData.totalCoin);


            player.gameObject.GetComponent<PlayerMovement>().enabled = true;


            enemy.gameObject.GetComponent<EnemyBehavior>().enabled = false;
            enemy.position = JsonUtility.FromJson<Vector3>(gameData.enemyPosition);
            enemy.gameObject.GetComponent<EnemyBehavior>().enabled = true;






            //for health
            heathSlider.gameObject.GetComponent<UIControls>().enabled = false;
            heathSlider.value = JsonUtility.FromJson<float>(gameData.healthValue);
            heathSlider.gameObject.GetComponent<UIControls>().enabled = true;


            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.Log("Game not found");
        }
    }
    }
