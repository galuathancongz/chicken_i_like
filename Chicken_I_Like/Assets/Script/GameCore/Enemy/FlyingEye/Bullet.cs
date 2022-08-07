using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioboom;
    

    private void Start()
    {
        audioSource.volume = 0.5f;
    }
    
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Boom");
            audioSource.clip = audioboom;
            audioSource.Play();
            
        }
        if (collision.gameObject.CompareTag("BackZone"))
        {
            Destroy(gameObject);
        }
    }
    void DesTroyGameObject()
    {
        Destroy(gameObject);
    }

}
