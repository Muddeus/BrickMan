using UnityEngine;
using System.Collections.Generic;
using System.Collections;

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
        StartCoroutine(BrickModeActivate());
    }

    IEnumerator BrickModeActivate()
    {
        yield return new WaitForSeconds(3.5f);
        tutorialBrickCam.SetActive(true);
        firstPersonCamera.enabled = false;
        brickCamera.enabled = false;
    }
}
