using UnityEngine;

public class BrickMode : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera brickCamera;
    public Animator camAnim;
    public GameObject tutorialBrickCam;

    public StateMachineMovement playerController;


    private void Start()
    {
        firstPersonCamera.enabled = true;
        brickCamera.enabled = false;
        tutorialBrickCam.SetActive(false);
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        playerController.EnterBrickMode();
        camAnim.Play("CameraMove");
        firstPersonCamera.enabled = false;
        brickCamera.enabled = true;
        tutorialBrickCam.SetActive(false);
    }
}
