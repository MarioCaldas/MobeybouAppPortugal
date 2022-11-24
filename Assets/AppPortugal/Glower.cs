using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glower : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Glow());
    }

    IEnumerator Glow()
    {
        float elapsedTime = 0;
        float totalTime = 2;

        while(elapsedTime <= totalTime)
        {
            elapsedTime += Time.deltaTime;

            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, Mathf.Lerp(1, 0, elapsedTime / totalTime));

            yield return null;
        }
        elapsedTime = 0;


        while (elapsedTime <= totalTime)
        {
            elapsedTime += Time.deltaTime;

            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, Mathf.Lerp(0, 1, elapsedTime / totalTime));

            yield return null;
        }

        StartCoroutine(Glow());
    }

    public void StopGlow()
    {
        StopAllCoroutines();
        GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 0);

    }
}
