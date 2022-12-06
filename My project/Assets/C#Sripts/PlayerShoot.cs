using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public float speed;
    public float bulletLifeTime = 2.0f;
    public AudioClip shootSound;

    void Start()
    {
        
    }


    void Update()
    {

        if (Time.timeScale == 1)
        {

            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bulletSpawn = Instantiate(bullet, transform.position, Quaternion.identity);

                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = -Camera.main.transform.position.z;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector2 shootDir = mousePosition - transform.position;

                shootDir.Normalize();
                bulletSpawn.GetComponent<Rigidbody2D>().velocity = shootDir * speed;

                Destroy(bulletSpawn, bulletLifeTime);
                //Camera.main.GetComponent<AudioSource>().PlayOneShot(shootSound);

            }
            void OnCollisionEnter2D(Collision2D collision)
			{
				string otherTag = collision.gameObject.tag;
				if (otherTag == "Enemy1")
				{
					GameObject.Destroy(bullet);
				}
			}

		}

    }

}
