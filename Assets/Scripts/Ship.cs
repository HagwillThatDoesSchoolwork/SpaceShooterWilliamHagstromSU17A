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
            if (targetShip.hp <= 0 && target.CompareTag("Enemy"))
            {
                spawner.score++;
                Destroy(target);
            }
            else
                StartCoroutine(ColourFlicker(target.GetComponent<SpriteRenderer>()));
        }
        else if (target.name != "Kill Wall")
            print("DealDmg: ship = null");
    }

    public IEnumerator ColourFlicker(SpriteRenderer renderer)
    {
        Color startColour = renderer.color;
        print(startColour);
        renderer.color = flickerColour;
        yield return new WaitForSecondsRealtime(flickerTime);
        renderer.color = startColour;
    }
}