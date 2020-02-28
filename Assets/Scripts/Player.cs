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
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
    }

    private void Fire()
    {
        Debug.Log("Firing projectile");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // NYI
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet collided");
            Debug.Log("-1 lives");
        }
    }
}
