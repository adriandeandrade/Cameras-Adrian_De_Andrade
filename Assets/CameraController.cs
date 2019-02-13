using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Adrian De Andrade */

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform firstPersonTarget;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float offsetPadding;
    [SerializeField] private float dampingTime;
    [SerializeField] private float toggleDampingTime;
    [SerializeField] private bool toggleFirstPerson;
    private Vector3 cameraOffset;

    private bool inPosition;

    private void Start()
    {
        toggleFirstPerson = false;
        cameraOffset = (transform.position - target.position) * offsetPadding;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            ToggleFirstPerson();
        }

        float horizontal = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float vertical = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (toggleFirstPerson)
        {
            ThirdPersonCamera();
        }
        else
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        transform.parent = null;
        Vector3 desiredPosition = target.position + cameraOffset;
        Vector3 pos = Vector3.Lerp(transform.position, desiredPosition, dampingTime * Time.deltaTime);
        transform.position = pos;
    }

    private void ThirdPersonCamera()
    {
        Vector3 desiredPosition = firstPersonTarget.position;
        transform.SetParent(target);

        if (transform.position == desiredPosition)
        {
            inPosition = true;
        }
        else
        {
            Vector3 pos = Vector3.Lerp(transform.position, firstPersonTarget.position, toggleDampingTime * Time.deltaTime);
            transform.position = pos;
        }

    }

    private void ToggleFirstPerson()
    {
        inPosition = false;
        toggleFirstPerson = !toggleFirstPerson;
        Debug.Log(toggleFirstPerson);
    }
}
