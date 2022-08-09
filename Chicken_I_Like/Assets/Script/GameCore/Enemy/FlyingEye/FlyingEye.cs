using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyingEye : MonoBehaviour
{
    
    [SerializeField] LayerMask BackZoneLayer;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        audioSource.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        FeelBackZone();
        AutoMove();        
    }
    void AutoMove()
    {
        transform.DOMove(new Vector2(transform.position.x + Random.Range(-0.1f, 0.1f), transform.position.y + Random.Range(-0.1f, 0.1f)),0.3f,false);
    }
    void FeelBackZone()
    {
        Collider2D backzone = Physics2D.OverlapCircle(transform.position, 1f, BackZoneLayer);
        if (backzone)
        {
            transform.DOMove(new Vector2(0 + Random.Range(-0.5f, 0.5f), 0 + Random.Range(-0.5f, 0.5f)), 5f, false);
        }
    }
   
   

}
