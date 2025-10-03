using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public GameObject gate;

    // Update is called once per frame
    void Update()
    {
        if (gate == null)
        {
            
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
        
    }
}
