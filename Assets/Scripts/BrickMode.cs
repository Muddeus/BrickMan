using UnityEngine;

public class BrickMode : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera brickCamera;
    public Animator camAnim;
    public Camera tutorialBrickCam;

    public StateMachineMovement playerController;


    private void Start()
    {
        firstPersonCamera.enabled = true;
        brickCamera.enabled = false;
        tutorialBrickCam.enabled = false;
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        playerController.EnterBrickMode();
        camAnim.Play("CameraMove");
        firstPersonCamera.enabled = false;
        brickCamera.enabled = false;
        tutorialBrickCam.enabled = true;
    }
}
