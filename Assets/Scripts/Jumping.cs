using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private bool isGrounded;
    [SerializeField]
    private float jumpForce = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    /// <summary>
    /// Персонаж находится на земле
    /// <summary>
    void OnCollisionEnter() 
    {
        isGrounded = true;
    }

    /// <summary>
    /// Производим проверку, если персонаж находится на земле, то он может использовать прыжок
    /// <summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            isGrounded = false;
            rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
