using System.Collections;
using UnityEngine;

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
        
        yield return new WaitForSeconds(3.5f);
        
    }
}
