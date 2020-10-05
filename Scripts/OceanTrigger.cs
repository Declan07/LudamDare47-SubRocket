using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        VehicleController vehicle = collision.GetComponentInParent<VehicleController>();
        vehicle.isSub = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        VehicleController vehicle = collision.GetComponentInParent<VehicleController>();
        vehicle.isSub = false;
    }
}
