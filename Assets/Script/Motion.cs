using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public float Speed;
    private float _smootingTime = 0.1f;
    private float _limits = 10.0f;
    private Vector3 _darting;
    void FixedUpdate()
    {
        // The ray follows a mouse position
        Ray PointingFinger = Camera.main.ScreenPointToRay(Input.mousePosition);
        // There's coordinates of the ray point midst active sphere for preciseness of Z-axis moving
        Vector3 Yaw = new Vector3(transform.position.x, transform.position.y, PointingFinger.GetPoint(Vector3.Distance(Camera.main.transform.position, transform.position)).z);
        // Adding constraints and some smoothness
        if (Yaw.z > _limits)
            Yaw.z = _limits;
        else if (Yaw.z < -_limits)
            Yaw.z = -_limits;
        Vector3 Velocity = Vector3.zero;
        _darting = Vector3.SmoothDamp(transform.position, Yaw, ref Velocity, _smootingTime, Speed);
        transform.position = _darting;
        Cestlavie.Head.transform.position = _darting;
    }
}
