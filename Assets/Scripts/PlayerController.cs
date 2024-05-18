using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float moveSpeed = 5.0f;

    public bool isWithKey;
    public bool isSpinHave;

    void Awake()
    {
        isWithKey = false;
        isSpinHave = false;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal") / 1.5f;
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0 && verticalInput != 0)
        {
            if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
                verticalInput = 0;
            else
                horizontalInput = 0;
        }

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GreenKey") /*&& Input.GetKeyDown(KeyCode.F)*/)
        {
            isWithKey = true;
            other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z);
        }

        if (other.gameObject.CompareTag("RedSpin") /*&& Input.GetKeyDown(KeyCode.F)*/)
        {
            isSpinHave = true;
            other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z);
        }

        if (other.gameObject.name == "SpinTube" && Input.GetKeyDown(KeyCode.F) && isSpinHave)
        {
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GreenDoor") && isWithKey && Input.GetKeyDown(KeyCode.F))
        {
            isWithKey = false;
            Destroy(collision.gameObject);
        }
    }
}