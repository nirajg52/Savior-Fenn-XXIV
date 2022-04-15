using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    //public GameHandler GH;
    public AudioClip coinSound;

    // Start is called before the first frame update
    void Start()
    {
        GameHandler.coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }



    private void OnTriggerEnter(Collider other)
    {
        GameHandler.coins++;

        if (quest.isActive)
        {
            quest.goal.CoinCollected();
            if (quest.goal.IsReached())
            {
                GameHandler.coins += 10;

                quest.Complete();
            }
        }

        AudioSource.PlayClipAtPoint(coinSound, transform.position);
        Destroy(gameObject);
    }
}
