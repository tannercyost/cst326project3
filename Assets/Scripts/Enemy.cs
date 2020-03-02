using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int value;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
        Destroy(this.gameObject);

    }
    void Start()
    {
        // set value based on transform y value
        if (transform.position[1] == 1)
            value = 10;
        else if (transform.position[1] == 2)
            value = 20;
        else if (transform.position[1] == 3)
            value = 35;
        else if (transform.position[1] == 4)
            value = 50;
        //Debug.Log(value);
    }
}
