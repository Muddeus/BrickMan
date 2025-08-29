using UnityEngine;

public class Brick : MonoBehaviour
{
    public Vector3 mouseDownPos;
    private Vector3 mousePos => Input.mousePosition;
    public Vector3 mouseOffset;
    public float mouseDistance;
    public float timeDown;
    public float timeUp;

    public Transform origin;

    public float multDefault;
    public float multPower;
    public float multDecay;
    public float maxMultTime;

    public bool launched;

    public Rigidbody rb;
    public Vector3 startPos;
    public Vector3 upPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = rb.position;
        launched = false;
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
            rb.position =  startPos - mouseOffset/100f;

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
                rb.AddForce(-mouseOffset * multPower + transform.forward * 50f, ForceMode.Impulse);
            }
        }

        if (launched)
        {
            rb.useGravity = true;
            rb.AddForce(Vector3.down, ForceMode.Force);
        }
        else
        {
            rb.useGravity = false;
        }
    }
}
