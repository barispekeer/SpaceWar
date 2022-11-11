using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject explosion;
    public Image enemyHealt;
    public Image panel;
    float speed = 1f;
    float bulletSpeed = 500f;
    float healt = 1f;
    public Transform player;
    public AudioClip explosionEffect;

    void Start()
    {
        
            InvokeRepeating("EnemyFire", 0, 0.3f);
        

    }


    void Update()
    {
        if (player)
        {
            if (transform.position.x < player.position.x)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (transform.position.x > player.position.x)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(collision.gameObject);
            healt -= 0.05f;
            if (healt <= 0)
            {
                AudioSource.PlayClipAtPoint(explosionEffect, transform.position);
                Destroy(gameObject);
                GameObject newExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(newExplosion, 1.5f);
                panel.gameObject.SetActive(true);
                Invoke("StopGame", 1f);
            }
            enemyHealt.fillAmount = healt;
        }
    }
    void EnemyFire()
    {
        GameObject newBullet = Instantiate(bullet,transform.position,Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * bulletSpeed);
        Destroy(newBullet, 1.5f);
    }
    void StopGame()
    {
        Time.timeScale = 0;
    }
}
