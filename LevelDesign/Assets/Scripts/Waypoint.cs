using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public float speedMultiplier = 1f;
    public float wait = 0f;
    public bool flip = false;

    [HideInInspector]
    public Vector3 position;

}
