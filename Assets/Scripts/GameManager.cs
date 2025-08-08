using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _ins;
    public static GameManager Ins { get { return _ins; } }

    public int brickCount;

    public float brickForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (_ins != null && _ins != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _ins = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
