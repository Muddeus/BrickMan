using UnityEngine;

public class CursorManager : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void BrickMode()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}