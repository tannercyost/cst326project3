using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int value;
    public bool isBottom;
    public Transform shootingOffset;
    public GameObject bullet;
    public EnemyManager manager;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name != "Enemy")
        {
            manager.ReportDeath(value, gameObject);
            Destroy(gameObject);
        }
    }
    void Start()
    {
        shootingOffset = transform.Find("ShootOffset");
        value = 0;
        isBottom = false;

        // set value based on transform y value
        if (transform.position[1] == 1) {
            value = 10;
            isBottom = true;
        }
        else if (transform.position[1] == 2)
            value = 20;
        else if (transform.position[1] == 3)
            value = 35;
        else if (transform.position[1] == 4)
            value = 50;
        //Debug.Log(value);
    }

    public void Move(int a)
    {
        // float amt = 0.1f;
        
        if (a == 0) // right
        {
            transform.Translate(Vector3.right);
        }
        if (a == 1) // left
        {
            transform.Translate(Vector3.left);
        }
        if (a == 2) // down
        {
            transform.Translate(Vector3.down);
        }

    }
    public void Fire()
    {
        GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
        Destroy(shot, 3f);
    }
}
