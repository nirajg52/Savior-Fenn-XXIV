using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    // Start is called before the first frame update
    private void Start()
    {
        if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    private void Update()
    {

        transform.position = player.position + offset;
    }
}
