using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : MonoBehaviour
{
    public EditorPathScript pathToFollow;
    public int currentWaypointId = 0;
    private int previousWaypointId;
    public float speed = 1.0f;  

    public float reachDistance = 0.1f;

    private List<Waypoint> pathPoints;
    private bool forward = true;
    private float sleepTimer = 0f;
    private float offset;

    void Start()
    {
        offset = pathToFollow.startOffset;
        pathPoints = pathToFollow.pathPoints;
        // place object on the first waypoint
        transform.position = pathPoints[0].position;
    }

    void FixedUpdate()
    {
        if (offset > 0.0f)
        {
            offset = offset - Time.deltaTime <= 0.0f ? 0.0f : offset - Time.deltaTime;
            return;
        }

        Waypoint nextPoint = pathPoints[currentWaypointId];
        previousWaypointId = currentWaypointId == 0 ? pathPoints.Count - 1 : currentWaypointId - 1;
        
        float distance = Vector3.Distance(transform.position, nextPoint.position);

        // wait
        if (sleepTimer > 0f)
        {            
            sleepTimer -= Time.deltaTime % 60;
            return;
        }

        // move the object
        transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, Time.deltaTime * speed * nextPoint.speedMultiplier);
        
        // if reached next point
        if (distance <= reachDistance)
        {
            sleepTimer = nextPoint.wait;
            if (nextPoint.flip)
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
            currentWaypointId = forward ? ++currentWaypointId : --currentWaypointId;
        }

        // if we reached the last point in the route
        if (currentWaypointId == pathToFollow.pathPoints.Count)
        {
            if (pathToFollow.loop)
                currentWaypointId = 0;
            else
            {
                forward = false;
                currentWaypointId -= 2;
            }
        }
        // if we reached the first point going back
        else if (currentWaypointId == -1)
        {
            forward = true;
            currentWaypointId += 2;
        }
    }
}

