using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject playerBullet;
    public GameObject explosion;
    public Image playerHealt;
    public Image panel;
    float playerSpeed = 5;
    float bulletSpeed = 500f;
    float healt = 1f;
    void Start()
    {

    }


    void Update()
    {
        Move();
        Fire();
    }
   void Move()
    {
        float yatay = Input.GetAxis("Horizontal");
        transform.Translate(yatay * Time.deltaTime * playerSpeed, 0, 0);
    }
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = Instantiate(playerBullet, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);
            Destroy(newBullet, 1.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Respawn"))
        {
            Destroy(collision.gameObject);
            healt -= 0.1f;
            if (healt <= 0)
            {
                Destroy(gameObject);
                GameObject newExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(newExplosion, 1.5f);
                panel.gameObject.SetActive(true);
                Invoke("StopGame", 1f);
            }
            playerHealt.fillAmount = healt;
        }
    }
    void StopGame()
    {
        Time.timeScale = 0;
    }
}
