using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2f;
    private float vertical, horizontal;

    private Rigidbody rb;
    private Camera mainCamera;
    
    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0f;

        Vector3 directionVector = (horizontal * mainCamera.transform.right + vertical * cameraForward).normalized;
        Vector3 directionMove = directionVector * movementSpeed;
        rb.velocity = new Vector3 (directionMove.x, rb.velocity.y, directionMove.z);
        rb.angularVelocity = Vector3.zero;
    }
}
