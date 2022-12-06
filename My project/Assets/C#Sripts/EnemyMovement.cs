using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform RedKoopa;
    Rigidbody2D rb;
    public float moveSpeed = 1.0f;
    public float otherMoveSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        RedKoopa = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RedKoopa.localScale.x > 0)
            rb.velocity = transform.right * moveSpeed;
        else
            rb.velocity = -transform.right * otherMoveSpeed;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            float x = RedKoopa.localScale.x;
            x *= -1;
            RedKoopa.localScale = new Vector3(x, RedKoopa.localScale.y, RedKoopa.localScale.z);
        }
    }
}
