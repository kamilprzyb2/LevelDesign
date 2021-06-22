using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private List<Button> activeButtons;
    private void Start()
    {
        activeButtons = new List<Button>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            foreach (Button button in activeButtons)
            {
                button.Activate();
            }
        }
    }

    public void AddButton(Button button)
    {
        activeButtons.Add(button);
    }
    public void RemoveButton(Button button)
    {
        activeButtons.Remove(button);
    }
}
