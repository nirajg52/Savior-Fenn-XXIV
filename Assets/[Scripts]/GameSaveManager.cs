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

    public Canvas canvas;

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


        int coinNumber = GameHandler.coins;
        Vector3 coinVector = new Vector3(coinNumber, 0, 0);
        gameData.totalCoin= JsonUtility.ToJson(coinVector);


  

 
        //save health value using Vector3
        int health = int.Parse(heathSlider.value.ToString());
        Vector3 healthVector = new Vector3(health, 0, 0);
        gameData.healthValue = JsonUtility.ToJson(healthVector);

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

            //load coin value
            Vector3 coinVector = JsonUtility.FromJson<Vector3>(gameData.totalCoin);
            int coinValue = (int)coinVector[0];
            GameHandler.coins = coinValue;

            enemy.gameObject.GetComponent<EnemyBehavior>().enabled = false;
            enemy.position = JsonUtility.FromJson<Vector3>(gameData.enemyPosition);
            enemy.gameObject.GetComponent<EnemyBehavior>().enabled = true;

            //load health values
            Vector3 healthVector = JsonUtility.FromJson<Vector3>(gameData.healthValue);
            float healthValue = healthVector[0];
            heathSlider.gameObject.GetComponent<UIControls>().enabled = false;
            heathSlider.value = healthValue;
            heathSlider.gameObject.GetComponent<UIControls>().enabled = true;

            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.Log("Game not found");
        }
    }
    }
