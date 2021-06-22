using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int requireButtons = 1;
    public void buttonPressed()
    {
        requireButtons--;
        if (requireButtons <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
