﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        if (transform.position.y > -4)
            Fire(-1);
        else
            Fire(1);
    }

    // Update is called once per frame
    private void Fire(int direction)
    {
      myRigidbody2D.velocity = Vector2.up * speed * direction; 
      Debug.Log("Wwweeeeee");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);

    }
}
