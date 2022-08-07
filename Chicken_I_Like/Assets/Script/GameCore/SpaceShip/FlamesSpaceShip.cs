using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamesSpaceShip : MonoBehaviour
{
    [SerializeField] SpriteRenderer sRender;
    public float fadeInDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FadeIn(fadeInDuration));
    }
    IEnumerator FadeIn(float duration)
    {
        float timePassed = 0;
        while (timePassed < duration)
        {
            Color newColor = sRender.color;
            newColor.a = timePassed / duration;
            sRender.color = newColor;

            timePassed += Time.deltaTime;
            if(timePassed >= fadeInDuration) timePassed = 0;
            yield return null;

        }
    }
  
}
