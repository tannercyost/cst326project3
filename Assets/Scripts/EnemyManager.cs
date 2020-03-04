﻿using System.Collections;
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

    public void ReportDeath(int value, GameObject enemy)
    {
        Enemy toRemove = null;
        OnDeath(value);
        foreach (Enemy e in enemyList)
        {
            if (e.name == enemy.name)
            {
                toRemove = e;
                //enemyList.Remove(e);
            }
        }
        if (toRemove != null)
        {
            enemyList.Remove(toRemove);
        }

        findNextBottom();
        // call OnDeath
        // raycast each to find lowest
        // set lowest isBottom to true
    }

    private void findNextBottom()
    {

        foreach (Enemy e in enemyList)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
            if (hit.collider != null || hit.collider.CompareTag("Player"))
            {
                // if downward raycast is null it must be the bottom
                // if downward raycast hits player that is fine
            }
            Debug.DrawRay(transform.position, forward, Color.green);
            Debug.Log(hit);
        }
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
