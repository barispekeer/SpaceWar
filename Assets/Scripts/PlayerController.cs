using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject playerBullet;
    public GameObject explosion;
    public Image playerHealt;
    float playerSpeed = 5;
    float bulletSpeed = 500f;
    float healt = 10f;
    void Start()
    {

    }


    void Update()
    {
        float yatay = Input.GetAxis("Horizontal");
        transform.Translate(yatay * Time.deltaTime * playerSpeed, 0, 0);

        Fire();
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
            healt -= 1;
            if (healt <= 0)
            {
                GameObject newExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(newExplosion, 1.5f);
            }
            playerHealt.fillAmount = healt;
        }
    }
}
