using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private Stat health;
    private void Awake()
    {
        health.Initialize();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            health.CurrentVal -= 10;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            health.CurrentVal += 10;
        }
    }
}
