using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    protected override void Move()
    {
        rb2d.velocity = -Vector2.right * movementSpeed;
    }
}
