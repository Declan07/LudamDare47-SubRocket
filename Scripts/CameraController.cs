using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float maxCameraSize = 5f;
    [SerializeField] float minCameraSize = 1f;
    [SerializeField] float cameraSizeScaler = 1f;

    private Transform playerTransform;
    private GameObject playerObject;
    private Vector2 playerVelocity;
    
    


    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerVelocity = playerObject.GetComponent<Rigidbody2D>().velocity;
        
    }


    
    void FixedUpdate()
    {
        //Current camera position
        Vector3 tempPos = transform.position;
        tempPos.x = playerTransform.position.x;
        tempPos.y = playerTransform.position.y;
        transform.position = tempPos;

        playerVelocity = playerObject.GetComponent<Rigidbody2D>().velocity;
        Camera.main.orthographicSize = Mathf.Clamp((Mathf.Abs(playerVelocity.y) * cameraSizeScaler), minCameraSize, maxCameraSize);
        

    }
}
