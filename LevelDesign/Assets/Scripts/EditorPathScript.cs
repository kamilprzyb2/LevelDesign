using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EditorPathScript : MonoBehaviour
{
    public Color rayColor = Color.white;
    public List<Waypoint> pathPoints = new List<Waypoint>();
    public bool loop = false;
    public bool show = true;
    public float startOffset = 0.0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;

        List<Waypoint> waypoints = GetComponentsInChildren<Waypoint>().ToList();
        List<Transform> transforms = GetComponentsInChildren<Transform>().ToList();
        // remove parent transform
        transforms.Remove(transform);

        pathPoints.Clear();
        for (int i = 0; i < waypoints.Count(); i++)
        {
            waypoints[i].position = transforms[i].position;
            pathPoints.Add(waypoints[i]);
        }

        if (show)
        {
            for (int i = 0; i < pathPoints.Count; i++)
            {
                Vector3 currentPosition = pathPoints[i].position;
                if (i > 0)
                {
                    Vector3 previousPosition = pathPoints[i - 1].position;
                    Gizmos.DrawLine(currentPosition, previousPosition);
                }
                Gizmos.DrawWireSphere(currentPosition, 0.07f);
            }
            if (loop)
                Gizmos.DrawLine(pathPoints[0].position, pathPoints[pathPoints.Count - 1].position);
        }

    }
}
