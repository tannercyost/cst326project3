using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] private GameManager GM;
    public float speed;
    public Transform shootingOffset;
    public UnityEvent events;


    void Start()
    {
        speed = 5.0f;

        // GM = GameObject.Find("GameManager");
    }
    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
        Destroy(shot, 3f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GM.playerLost();
    }
}
