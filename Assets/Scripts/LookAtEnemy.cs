using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{
    public GameObject enemy;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            return;
        }

        transform.LookAt(enemy.transform);
    }
}
