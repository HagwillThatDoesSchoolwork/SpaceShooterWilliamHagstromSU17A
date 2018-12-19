using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    EnemySpawner spawner;

    private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySpawner>();
    }

    void Update()
    {
        scoreText.text = "Score: " + spawner.score;
    }
}
