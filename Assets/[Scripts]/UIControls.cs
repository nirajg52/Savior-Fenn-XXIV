using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIControls : MonoBehaviour
{
    public Slider HealthBar;
   
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        int health = int.Parse(HealthBar.value.ToString());
        health -= damage;
        HealthBar.value = health;


        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }


}
