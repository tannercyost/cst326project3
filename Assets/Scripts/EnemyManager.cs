using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemyList;
    private int speed;
    public int enemyCount;

    private static bool s_permanentInstance = true;  // set to true if you ever only want *one* instance among all scenes and drop an instance of GameManager in your first scene you load
    public static EnemyManager Instance { get; private set; }
    void Start()
    {
        speed = 1;

        foreach (Enemy e in enemyList)
        {
            Debug.Log(e.value);
        }
    }

    private void OnDeath(int value)
    {
        Debug.Log(value);
        // decrement count
        // increase speed
        // report increase in score
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
        
    }

    private void Attack()
    {

    }

}
