using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float distance;
    public float height;
    public float damping;
    public bool followBehind = true;


    void LateUpdate()
    {
        Vector3 wantedPosition;
        if (followBehind)
        {
            wantedPosition = target.TransformPoint(0, height, -distance);
        }
        else
        {
            wantedPosition = target.TransformPoint(0, height, distance);
        }
        transform.position = Vector3.Lerp(transform.position, new Vector3(wantedPosition.x, wantedPosition.y, -10f), Time.deltaTime * damping);
    }
}
