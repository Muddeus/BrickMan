using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BrickMode : MonoBehaviour
{
    public GameObject firstPersonCamera;
    public GameObject brickCamera;
    public GameObject tutorialBrickCam;
    public Animator camAnim;

    public CursorManager cursorManager;

    public StateMachineMovement playerController;


    private void Start()
    {
        firstPersonCamera.SetActive(true);
        brickCamera.SetActive(false);
        tutorialBrickCam.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        playerController.EnterBrickMode();
        camAnim.Play("CameraMove");
        firstPersonCamera.SetActive(false);
        brickCamera.SetActive(true);
        tutorialBrickCam.SetActive(false);
        StartCoroutine(BrickModeActivate());
    }

    IEnumerator BrickModeActivate()
    {
        yield return new WaitForSeconds(3.5f);
        firstPersonCamera.SetActive(false);
        brickCamera.SetActive(false);
        tutorialBrickCam.SetActive(true);
        cursorManager.BrickMode();
    }
}
