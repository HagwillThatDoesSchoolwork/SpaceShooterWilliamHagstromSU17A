using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Ship
{
    public virtual void Update()
    {
        Move();
    }

    protected abstract void Move();

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            DealDmg(collision.gameObject, dmg);
    }
}
