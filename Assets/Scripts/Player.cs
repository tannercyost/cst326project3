using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] private GameManager GM;
    public float speed;
    public Transform shootingOffset;
    private int lives;

    void Start()
    {
        speed = 5.0f;
        lives = 3;
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
        Debug.Log("Bang!");
        Destroy(shot, 3f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GM.playerLost();
        Destroy(this.gameObject);
    }
}
