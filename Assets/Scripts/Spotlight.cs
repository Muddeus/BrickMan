using UnityEngine;

public class Spotlight : MonoBehaviour
{
    public GameObject politcian;

    //// Update is called once per frame
    void Update()
    {
        transform.LookAt(politcian.transform);
    }
}
