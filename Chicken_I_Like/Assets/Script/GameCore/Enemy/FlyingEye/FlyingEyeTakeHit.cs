using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeTakeHit : MonoBehaviour
{
    [SerializeField] string name_TagFire = "Fire";
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip AudioTakeHit;
    [SerializeField] int numberscore=100;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(name_TagFire))
        {
            AutoTakeHit();
            Score.score += numberscore;
        }

    }
    void AutoTakeHit()
    {
        if (/* neu bi tan cong*/true)
        {
            animator.SetTrigger("TakeHit");
            audioSource.clip = AudioTakeHit;
            audioSource.Play();
        }

    }
    void AutoDeath()
    {
        // audioSource.clip = Audiodead;
        //audioSource.Play();
        Destroy(gameObject);
    }
}
