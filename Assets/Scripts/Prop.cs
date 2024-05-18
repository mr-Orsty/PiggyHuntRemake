using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Prop : MonoBehaviour
{
    private PlayerController playerController;
    private Vector3 offset = new Vector3(0, 1f, 0);
    
    private Animator keyAnimator;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        keyAnimator = GetComponent<Animator>();
        keyAnimator.Play("propIdle");
    }

    void Update()
    {
        if (playerController.isWithKey)
        {
            keyAnimator.gameObject.GetComponent<Animator>().enabled = false;
            gameObject.transform.position = playerController.transform.position + offset;
        }

        if (!GameObject.Find("GreenDoor"))
        {
            Destroy(gameObject);
        }

        if(playerController.isSpinHave)
        {
            gameObject.transform.position = playerController.transform.position + offset;
        }
    }
}
