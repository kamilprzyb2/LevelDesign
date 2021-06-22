using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 3f;
    [SerializeField] private float scrollModifier = 0.1f;
    void Update()
    {
        if (Input.GetMouseButton(1))
            return;

        var horizontal = Input.GetAxis("Mouse X");
        transform.Rotate(horizontal * turnSpeed * Vector3.up, Space.World);

        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0f)
        {
            float delta = scroll * scrollModifier;
            if (turnSpeed + delta > 0)
                turnSpeed += scrollModifier * scroll;
        }
    }
}
