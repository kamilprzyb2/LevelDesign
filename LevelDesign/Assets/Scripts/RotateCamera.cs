using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 1f;
    [SerializeField] private float scrollModifier = 0.1f;
    [SerializeField] private float minRotation = 330f;
    [SerializeField] private float maxRotation = 30f;
    [SerializeField] private bool invert = false;


    void Update()
    {
        if (Input.GetMouseButton(1))
            return;

        float vertical = Input.GetAxis("Mouse Y");
        if (vertical != 0f)
        {
            float delta = vertical * turnSpeed;
            if (!invert)
                delta = -delta;

            if (transform.rotation.eulerAngles.x + delta < maxRotation || transform.rotation.eulerAngles.x + delta > minRotation)
            {
                transform.Rotate(delta * Vector3.right, Space.Self);
            }
        }

        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0f)
        {
            float scrollDelta = scroll * scrollModifier;
            if (turnSpeed + scrollDelta > 0)
                turnSpeed += scrollModifier * scroll;
        }
    }
}
