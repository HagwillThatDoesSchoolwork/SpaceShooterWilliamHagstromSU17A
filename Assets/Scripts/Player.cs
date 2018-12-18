using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Ship
{
    void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        //Movement via a vector that takes input from the joystick axis
        Vector2 velocity = new Vector2(xInput * movementSpeed, yInput * movementSpeed);
        rb2d.velocity = velocity;
    }

    private void Update()
    {
        if (hp <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(1);
    }
}