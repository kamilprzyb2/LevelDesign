using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Door door;
    private bool activated = false;
    public Color activationColor = Color.green;
    public Transform buttonPiece;
    public float pushButtonBy = 0.04f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInteractions>() != null)
        {
            other.GetComponent<PlayerInteractions>().AddButton(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerInteractions>() != null)
        {
            other.GetComponent<PlayerInteractions>().RemoveButton(this);
        }
    }

    public void Activate()
    {
        if (activated)
            return;
        activated = true;
        buttonPiece.GetComponent<Renderer>().material.color = activationColor;
        buttonPiece.position = new Vector3(buttonPiece.position.x, buttonPiece.position.y - pushButtonBy, buttonPiece.position.z);
        door.buttonPressed();
    }
}
