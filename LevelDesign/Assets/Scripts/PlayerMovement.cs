using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private float jumpSpeed = 0.5f;
    [SerializeField] private float gravity = 2f;

    CharacterController characterController;
    float yDirection = 0f;

    private Transform followPlatform = null;
    private Vector3 lastPlatformPos;
    private float currentAcceleration = 1f;

    public Vector3 teleportTo = Vector3.zero;
    public Quaternion teleportRotation;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0, vertical).normalized;
        Vector3 transformDirection = transform.TransformDirection(inputDirection);

        if (Input.GetKey(KeyCode.LeftShift) && !PlayerJumped())
        {
            currentAcceleration = sprintSpeed / moveSpeed;
        }
        else
        {
            currentAcceleration = 1;
        }

        Vector3 flatMovement = transformDirection * Time.deltaTime * moveSpeed * currentAcceleration;
   

        Vector3 moveDirection = new Vector3(flatMovement.x, yDirection, flatMovement.z);

        if (PlayerJumped())
            moveDirection.y = jumpSpeed;
        else if (characterController.isGrounded)
            moveDirection.y = 0f;
        else moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection);
        yDirection = moveDirection.y;

        if (followPlatform != null)
        {
            Vector3 platformDiff = followPlatform.position - lastPlatformPos;
            transform.position += platformDiff;
            lastPlatformPos = followPlatform.position;
        }

        if (teleportTo != Vector3.zero)
        {
            transform.position = teleportTo;
            teleportTo = Vector3.zero;
            transform.rotation = teleportRotation;
            Camera.main.transform.rotation = new Quaternion();
        }
    }

    private bool PlayerJumped()
    {
        return characterController.isGrounded && Input.GetKey(KeyCode.Space);
    }

    public void SetPlatform(Transform transform)
    {
        followPlatform = transform;
        lastPlatformPos = transform.position;
    }

    public void UnSetPlatform()
    {
        followPlatform = null;
    }
}
