using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lookSensitivity;
    private Vector3 movement;

    private void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
        float vertical = Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;
        
        Movement();
    }

    private void Movement()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        float movementMag = Mathf.Clamp(movement.magnitude, 0f, 1f);
        Vector3 movementNorm = movement.normalized;
        Vector3 desiredMovement = movementNorm * movementMag;
        transform.Translate(desiredMovement * moveSpeed * Time.deltaTime);
    }
}
