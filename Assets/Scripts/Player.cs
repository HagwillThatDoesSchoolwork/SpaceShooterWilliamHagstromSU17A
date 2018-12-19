using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Ship
{
    float xInput, yInput, maxHp;

    private void Start()
    {
        maxHp = hp;
    }

    void FixedUpdate()
    {
        //Movement via a vector that takes input from the joystick axis
        Vector2 velocity = new Vector2(xInput * movementSpeed, yInput * movementSpeed);
        rb2d.velocity = velocity;
    }

    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (hp <= 0)
        {
            GameOver();
        }

        GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, (maxHp - hp) / maxHp);
    }

    void GameOver()
    {
        SceneManager.LoadScene(1);
    }
}