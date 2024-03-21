using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointProvider : MonoBehaviour
{
    private static WaypointProvider instance;
    public static WaypointProvider Instance => instance;

    List<Transform> waypoints = new List<Transform>();

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            waypoints.Add(transform.GetChild(i));
        }
    }

    public Transform GetNextWaypoint(Transform current = null)
    {
        if(current == null)
            return waypoints[0];

        int index = waypoints.IndexOf(current);
        index++;
        if (index == waypoints.Count) return null;

        return waypoints[index];
    }
}
