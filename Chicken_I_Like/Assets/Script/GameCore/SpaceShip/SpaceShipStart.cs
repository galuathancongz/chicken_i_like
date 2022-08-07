using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpaceShipStart : MonoBehaviour
{
    [SerializeField] SpriteRenderer sRender;
    [SerializeField] GameObject SpaceClone;
    public float fadeInDuration = 1f;
    public float timeStartFly = 1f;
    Vector2 StartSpacePosition = new Vector2(0, -3.5f);
    static public  bool gameCanStart = false;

    // Start is called before the first frame update
    void Start()
    {
        var sequece = DOTween.Sequence();
        sequece.Append(transform.DOMove(StartSpacePosition, timeStartFly, false));
        sequece.Append(transform.DORotate(new Vector3(0,0,0),2f,RotateMode.Fast));  
        StartCoroutine(FadeIn(fadeInDuration));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles == new Vector3(0, 0, 0))
        {
            gameCanStart = true;
            SpaceClone.SetActive(true);
        }
        
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
            yield return null;
           
        }
    }
   
}
