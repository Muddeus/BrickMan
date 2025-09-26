using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class BrickMode : MonoBehaviour
{
    public GameObject firstPersonCamera;
    public GameObject brickCamera;
    public GameObject tutorialBrickCam;
    public Animator camAnim;

    public CursorManager cursorManager;

    public StateMachineMovement playerController;

    public BoxCollider col;

    private Scene currentScene;


    private void Start()
    {
        firstPersonCamera.SetActive(true);
        brickCamera.SetActive(false);
        tutorialBrickCam.SetActive(false);
        col = GetComponent<BoxCollider>();
        col.enabled = true;
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().name == "Kaine")
        {
            brickCamera.SetActive(true);
            camAnim.Play("CameraMove2");
            playerController.EnterBrickMode();
            firstPersonCamera.SetActive(false);
            tutorialBrickCam.SetActive(false);
            StartCoroutine(BrickModeActivate1());
        }
        else
        //else if (SceneManager.GetActiveScene().name == "Part2")
        {
            brickCamera.SetActive(true);
            camAnim.Play("CameraMove");
            playerController.EnterBrickMode();
            firstPersonCamera.SetActive(false);
            tutorialBrickCam.SetActive(false);
            StartCoroutine(BrickModeActivate2());
        }
    }

    IEnumerator BrickModeActivate1()
    {
        yield return new WaitForSeconds(1f);
        col.enabled = false;
        firstPersonCamera.SetActive(false);
        brickCamera.SetActive(false);
        tutorialBrickCam.SetActive(true);
        cursorManager.BrickMode();
    }

    IEnumerator BrickModeActivate2()
    {
        yield return new WaitForSeconds(2.5f);
        firstPersonCamera.SetActive(false);
        brickCamera.SetActive(false);
        tutorialBrickCam.SetActive(true);
        cursorManager.BrickMode();
    }
}
