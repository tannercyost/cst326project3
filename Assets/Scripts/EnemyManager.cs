﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemyList;
    private int speed;
    public int enemyCount;

    void Start()
    {
        foreach (Enemy e in enemyList)
        {
            Debug.Log(e.value);
        }
    }

    void Update()
    {
        
    }

}
