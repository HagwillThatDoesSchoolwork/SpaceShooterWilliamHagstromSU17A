using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ship : MonoBehaviour
{
    public int dmg;
    public float movementSpeed, hp, flickerTime = 0.1f;
    public Color flickerColour;

    [HideInInspector]
    protected Rigidbody2D rb2d;

    EnemySpawner spawner;
    Color startColour;

    virtual public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySpawner>();
    }

    public void DealDmg(GameObject target, float dmg)
    {
        Ship targetShip = target.GetComponent<Ship>();

        if (targetShip != null)
        {
            targetShip.hp -= dmg;

            //Checks to see if the targetship hp is 0 or less and if so kills it and adds 1 to score
            if (targetShip.hp <= 0 && target.CompareTag("Enemy"))
            {
                spawner.score++;
                Destroy(target);
            }
            //If the hp is greater than 0 it will trigger ColourFlicker
            else if (target.CompareTag("Enemy"))
            {
                SpriteRenderer renderer = target.GetComponent<SpriteRenderer>();

                StartCoroutine(ColourFlicker(renderer));
            }
        }
        else if (target.name != "Kill Wall")
            print("DealDmg: ship = null");
    }

    //Sets the start colour to the colour of the gameObject before changing it to the flicker colour for the duration of flickertime
    public IEnumerator ColourFlicker(SpriteRenderer renderer)
    {
        startColour = renderer.color;

        renderer.color = flickerColour;
        yield return new WaitForSecondsRealtime(flickerTime);
        renderer.color = startColour;
    }
}