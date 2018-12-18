using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Enemy
{

    override public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    protected override void Move()
    {
        rb2d.velocity = -Vector2.right * movementSpeed;
    }

    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            DealDmg(collision.gameObject, dmg);
            Destroy(gameObject);
        }
    }
}
