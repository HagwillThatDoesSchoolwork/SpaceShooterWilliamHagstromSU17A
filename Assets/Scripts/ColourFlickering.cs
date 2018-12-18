using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourFlickering : MonoBehaviour
{
    public float flickerTime = 0.1f;
    public Color flickerColour, startColour = Color.white;

    public IEnumerator ColourFlicker(SpriteRenderer renderer)
    {
        renderer.color = flickerColour;
        yield return new WaitForSecondsRealtime(flickerTime);
        renderer.color = startColour;
    }
}
