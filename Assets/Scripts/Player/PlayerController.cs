using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class StateMachineMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float gravityUp, gravityDown;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] Transform camTrans;
    [SerializeField] CapsuleCollider playerCol;

    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get our components
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        //make sure our rigidbody is set up correctly
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;

        walkSpeed = 8;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputMovement = GetMovementFromInput();
        inputMovement *= walkSpeed;
        inputMovement.y = rb.linearVelocity.y - gravityDown * Time.deltaTime;

        rb.linearVelocity = inputMovement;
    }

    private Vector3 GetMovementFromInput()
    {
        Vector2 inputThisFrame = new Vector2();
        inputThisFrame.x = Input.GetAxis("Horizontal");
        inputThisFrame.y = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(inputThisFrame.x, 0, inputThisFrame.y);

        transform.localEulerAngles = new Vector3(0, camTrans.localEulerAngles.y);
        //translate direction from world ot local
        moveDirection = transform.TransformDirection(moveDirection);

        return moveDirection;
    }
}