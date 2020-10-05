using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public bool isSub = false;
    public Sprite Rocket;
    public Sprite RocketFlame;
    public Sprite Submarine;
    public bool hitLeftWall = false;
    public bool hitRightWall = false;

    [SerializeField] float rocketThrustForce = 10f;
    [SerializeField] float subThrustForce = 1f;
    [SerializeField] float tiltingForce = 10f;
    [SerializeField] float pitchSpeed = 10f;
    [SerializeField] float rocketFuel = 100f;

    bool throttle = false;
    

    Rigidbody2D rb;
    private float tiltInput = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        tiltInput = Input.GetAxis("Horizontal");
        throttle = Input.GetKey(KeyCode.UpArrow);

        

        
        if (isSub)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Submarine;
        }
        if (!isSub)
        {

            if (throttle && rocketFuel > 1f)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = RocketFlame;
            }

            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Rocket;
            }
                
        }

        /*
        if(!Mathf.Approximately(tiltInput, 0f))
        {
       
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new Vector3(0f, 0f, ((tiltInput * -1) * tiltingForce * Time.deltaTime))));
        }*/
    }

    private void FixedUpdate()
    {
        if (hitLeftWall)
        {
            Vector2 newPos = new Vector2(180, transform.position.y);
            rb.MovePosition(newPos);
            hitLeftWall = false;
        }
        if (hitRightWall)
        {
            Vector2 newPos = new Vector2(20f, transform.position.y);
            rb.MovePosition(newPos);
            hitRightWall = false;
        }

        if (!isSub)
        {
            rocketPhysics();
        }
        else
        {
            subPhysics();
        }
        

    }

    private void rocketPhysics()
    {
        if ((throttle == true) && (rocketFuel > 1))
        {
            rb.AddRelativeForce(Vector2.up * rocketThrustForce * Time.deltaTime);
            rocketFuel--;
            Debug.Log(rocketFuel);
        }

        float pitchTorque = (-1 * tiltInput) * pitchSpeed;
        rb.AddTorque(pitchTorque);

    }

    private void subPhysics()
    {
        if (throttle)
        {
            rb.AddRelativeForce(Vector2.up * subThrustForce * Time.deltaTime);
        }

        

        float pitchTorque = (-1 * tiltInput) * pitchSpeed;
        rb.AddTorque(pitchTorque);
        rb.AddRelativeForce(rb.velocity.magnitude * Vector2.up * Time.deltaTime);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
