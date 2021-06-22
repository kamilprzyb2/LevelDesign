using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            other.GetComponent<PlayerMovement>().teleportTo = teleportTo.position;
            other.GetComponent<PlayerMovement>().teleportRotation = teleportTo.rotation;
        }
    }
}
