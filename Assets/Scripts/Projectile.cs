using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.magnitude > 250.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        enemyController e = other.collider.GetComponent<enemyController>();
        if (e != null)
        {
            e.Fix();
        }

        Destroy(gameObject);
    }
}
