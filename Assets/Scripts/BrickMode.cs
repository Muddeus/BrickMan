using UnityEngine;

public class BrickMode : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera brickCamera;

    private void Start()
    {
        firstPersonCamera.enabled = true;
        brickCamera.enabled = false;
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        firstPersonCamera.enabled = false;
        brickCamera.enabled = true;
    }
}
