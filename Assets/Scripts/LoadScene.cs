using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadScenes(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
