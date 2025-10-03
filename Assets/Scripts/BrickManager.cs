using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public Transform origin;

    public Transform lookAtEnemy;

    public Vector3 startPos;
    public Quaternion startRot;

    public GameObject prefab;

    public Brick brick;

    public float timeToDestroy;
    
    void Start()
    {
        brick = GetComponentInChildren<Brick>();
        startPos = brick.gameObject.transform.position;
        startRot = brick.gameObject.transform.rotation;
    }

    void Update()
    {
        if (brick != null)
        {
            if (brick.launched)
            {
                Destroy(brick, timeToDestroy);
            }
        }
        else
        {
            GameObject nextBrick = Instantiate(prefab, startPos, startRot, transform);
            brick = nextBrick.GetComponent<Brick>();
        }
    }
}
