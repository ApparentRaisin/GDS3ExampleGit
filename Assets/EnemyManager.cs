using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] PlayerController player;

    Enemy anEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Enemy
{
    public Vector3 position;

}
