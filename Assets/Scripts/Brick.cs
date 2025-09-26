using UnityEngine;

public class Brick : MonoBehaviour
{
    public Vector3 mouseDownPos;
    private Vector3 mousePos => Input.mousePosition;
    public Vector3 mouseOffset;
    public float mouseDistance;
    public float timeDown;
    public float timeUp;

    public GameObject brickPrefab;

    public Transform origin;

    public float multDefault;
    public float multPower;
    public float multDecay;
    public float maxMultTime;
    public float throwForce;

    public bool launched;

    public Rigidbody rb;
    public Vector3 startPos;
    public Vector3 upPos;

    public Transform lookAtEnemy;

    public bool brickDuped;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = rb.position;
        launched = false;
        brickDuped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            print("mouse Down");
            mouseDownPos = mousePos;
            multPower = multDefault;
            timeDown = 0f;
            launched = false;
        }

        if (Input.GetButton("Fire1"))
        {
            mouseOffset = (mouseDownPos - mousePos);
            mouseDistance = mouseOffset.magnitude;
            mouseOffset.y /= 10f;
            mouseOffset.x /= 15f;
            rb.position =  startPos - mouseOffset/100f;
            brickDuped = false;

            if (timeDown > maxMultTime)
            {
                multPower -= multDecay * Time.deltaTime;
            }
            timeDown += Time.deltaTime;
            print("MouseOffset: " + mouseOffset);
            print("Mouse distance: " + mouseDistance);
        }
        else // if not holding mouse1
        {
            timeUp += Time.deltaTime;
            float timeToLerp = 0.2f;
            
            if (!launched && timeUp < timeToLerp)
            {
                rb.position = Vector3.Lerp(origin.position, startPos, timeUp * (1/timeToLerp));
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            
            timeUp = 0f;
            upPos = rb.position;

            if (mouseDistance > 200f)
            {
                launched = true;
                Vector3 direction = -mouseOffset * multPower + lookAtEnemy.forward * throwForce;
                rb.AddForce(direction, ForceMode.Impulse);
            }
        }

        if (launched)
        {
            rb.useGravity = true;
            rb.AddForce(Vector3.down, ForceMode.Force);

            if (!brickDuped && timeUp > 0.1f)
            {
                brickDuped = true;
                GameObject brick = Instantiate(brickPrefab, transform.position, transform.rotation);
                Rigidbody newRb = brick.GetComponent<Rigidbody>();
                newRb.linearVelocity = rb.linearVelocity;
                newRb.angularVelocity = rb.angularVelocity;
                Destroy(brick.GetComponent<Brick>());
                transform.position += Vector3.down * 50;
                //newRb = rb;
            }
        }
        else
        {
            rb.useGravity = false;
        }
    }
}
