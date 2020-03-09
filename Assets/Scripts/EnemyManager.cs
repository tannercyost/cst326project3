using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemyList;
    private int speed;
    private float stepSize;
    public int enemyCount;
    private int leftMoves;
    private int rightMoves;
    private int downMoves;
    [SerializeField] private GameManager gManager;

    
    void Start()
    {
        speed = 1;
        stepSize = 0.5f;

        InvokeRepeating("Attack", 2.0f, 2.371f);
        InvokeRepeating("Movement", 1.0f, 1.312f);
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
            if (e.name == enemy.gameObject.name)
            {
                toRemove = e;
                //enemyList.Remove(e);
            }
        }
        if (toRemove != null)
        {
            Debug.Log("Removed enemy: " + toRemove);
            enemyList.Remove(toRemove);
            Destroy(toRemove);
        }

        // findNextBottom(); 

    }

    private void findNextBottom()
    {
        foreach (Enemy e in enemyList)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
            if (hit.collider != null || hit.collider.CompareTag("Player"))
            {
                // if downward raycast is null it must be the bottom
                // if downward raycast hits player that is fine
                e.isBottom = true;
            }
            Debug.Log(hit);
        }
    }

    private void Movement()
    {
        if (rightMoves < 6)
        {
            MoveEnemies(0);
            rightMoves++;
        }
        else if (downMoves < 1)
        {
            MoveEnemies(2);
            downMoves++;
        }
        else if (leftMoves < 6)
        {
            MoveEnemies(1);
            leftMoves++;
        }

        else
        {
            rightMoves = 0;
            leftMoves = 0; 
            downMoves = 0;
        }
    }

    private void MoveEnemies(int direction)
    {
        foreach (Enemy e in enemyList)
        {
            e.Move(direction);
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
