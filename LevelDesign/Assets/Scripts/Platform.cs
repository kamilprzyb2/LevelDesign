using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            other.GetComponent<PlayerMovement>().SetPlatform(transform);
        }     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            other.GetComponent<PlayerMovement>().UnSetPlatform();
        }
    }
}
