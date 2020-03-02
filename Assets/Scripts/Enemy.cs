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
        manager.ReportDeath(value);
        Destroy(this.gameObject);
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

    private void Update()
    {
 
    }
    private void Fire()
    {
        GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
        Destroy(shot, 3f);
    }
}
