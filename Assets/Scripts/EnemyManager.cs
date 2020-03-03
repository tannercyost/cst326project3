using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemyList;
    private int speed;
    private float stepSize;
    public int enemyCount;

    [SerializeField] private GameManager gManager;

    
    void Start()
    {
        speed = 1;
        stepSize = 0.5f;
        foreach (Enemy e in enemyList)
        {
            Debug.Log(e.value);
        }
        InvokeRepeating("Attack", 2.0f, 6.0f);
    }

    private void OnDeath(int value)
    {
        // decrement count
        // increase speed
        // report increase in score
        gManager.AddScore(value);
    }

    public void ReportDeath(int value)
    {
        OnDeath(value);
        // call OnDeath
        // raycast each to find lowest
        // set lowest isBottom to true
    }

    void Update()
    {
        
        // InvokeRepeating("Attack", 2.0f, 6.0f);
    }

    private void Attack()
    {
        foreach (Enemy e in enemyList)
        {
            if (e.isBottom)
                e.Fire();
        }
    }

}
