using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private Material[] mat;
    public float scalar, parallaxScalar;

    void Start()
    {
        mat = GetComponent<Renderer>().materials;
    }


    void Update()
    {
        mat[0].SetTextureOffset("_MainTex", new Vector2(Time.time * scalar, 0));
        mat[1].SetTextureOffset("_MainTex", new Vector2(Time.time * scalar * parallaxScalar, 0));
    }
}
