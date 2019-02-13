using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector3 movement;

    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        float movementMag = Mathf.Clamp(movement.magnitude, 0f, 1f);
        Vector3 movementNorm = movement.normalized;
        Vector3 desiredMovement = movementNorm * movementMag;
        transform.Translate(desiredMovement * moveSpeed * Time.deltaTime);
    }
}
