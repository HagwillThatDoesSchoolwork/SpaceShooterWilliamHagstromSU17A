using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    EnemySpawner EnemySpawner;

    Material[] mat;

    [SerializeField]
    float parallaxScalar = 0.25f, scalar = 0.05f, colourFadeSpeed = 0.2f;

    void Awake()
    {
        mat = GetComponent<Renderer>().materials;
    }

    void Update()
    {
        mat[0].SetTextureOffset("_MainTex", new Vector2(Time.time * scalar, 0));
        mat[1].SetTextureOffset("_MainTex", new Vector2(Time.time * scalar * parallaxScalar, 0));

        mat[0].SetColor("_MainTex", Color.HSVToRGB(Mathf.Sin(Time.time * colourFadeSpeed) / 2 + 0.5f, 1, 1));
    }
}
