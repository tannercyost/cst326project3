using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager gm;
    [SerializeField] public float speed;
    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameManager>();
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetAxis("Horizontal") == 1)
        //{
        //    float translation = Input.GetAxis("Horizontal") * speed;
        //    translation *= Time.deltaTime;
        //    transform.Translate(translation, 0, 0);
        //}
        //if (Input.GetAxis("Horizontal") == -1)
        //{
        //    float translation = Input.GetAxis("Horizontal") * speed;
        //    translation *= Time.deltaTime;
        //    transform.Translate(translation, 0, 0);
        //}
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    speed = 10.0f;
        //} 
        //else
        //{
        //    speed = 5.0f;
        //}
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // NYI
    }
}
