using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwayEnemy : Enemy
{
    [SerializeField]
    [Range(0.1f, 5f)]
    float movementSpeedYMultiplier, swayHeight, swayFrequency;
    float startTime, newYPos;

    public void Start()
    {
        startTime = Time.time;

        if (transform.position.y + swayHeight >= 5)
        {
            newYPos = transform.position.y - 2 * swayHeight - 0.5f;
            transform.position = new Vector3(transform.position.x, newYPos, 0);
        }
    }

    protected override void Move()
    {
        rb2d.velocity = new Vector2(-movementSpeed, Mathf.Sin(Time.time - startTime * swayFrequency) * swayHeight);
    }
}
