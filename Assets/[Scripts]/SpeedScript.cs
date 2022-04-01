using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedScript : MonoBehaviour
{
    public GameHandler GH;
    public AudioClip speedSound;
    public GameObject speedUI;

    // Start is called before the first frame update
    void Start()
    {
        speedUI.SetActive(false);
        GH = GameObject.Find("Canvas").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        speedUI.SetActive(true);
        AudioSource.PlayClipAtPoint(speedSound, transform.position);
        Destroy(gameObject);
    }

}
