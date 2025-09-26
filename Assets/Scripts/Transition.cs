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
            print("no gate");
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        print("go");
        yield return new WaitForSeconds(3.5f);
        
    }
}
