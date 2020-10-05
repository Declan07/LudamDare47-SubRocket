using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWallTrigger : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Transform transform = collision.GetComponentInParent<Transform>();
        VehicleController vehicle = collision.GetComponentInParent<VehicleController>();
        vehicle.hitRightWall = true;
    }
}
