using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 offset = new Vector3(0f, 11.6f, -14.0f);
    private Vector3 lightOffset = new Vector3(0f, 3f, 0f);

    void Update()
    {
        gameObject.transform.position = player.transform.position + offset;

        if (gameObject.CompareTag("Light"))
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
            gameObject.transform.position = player.transform.position + lightOffset;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(40, 10, 0));
            offset.x = -1;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(40, -10, 0));
            offset.x = 1;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(40, 0, 0));
            offset.x = 0;
        }
    }
}
