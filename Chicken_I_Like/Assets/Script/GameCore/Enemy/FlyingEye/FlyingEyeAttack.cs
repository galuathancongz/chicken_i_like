using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyingEyeAttack : MonoBehaviour
{
    bool checkFeelPlayer = true;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip Audioattack;
    [SerializeField] GameObject Bullet;
    GameObject BulletInstate;


    // Update is called once per frame
    void Update()
    {
        if (checkFeelPlayer) { StartCoroutine(FeelPlayer(0.3f)); }
    }
    IEnumerator FeelPlayer(float seconds)
    {
        checkFeelPlayer = false;
        int randomattack = Random.Range(0, 30);


        if (randomattack == 3)
        {
            animator.SetBool("Attack", true);

        }
        else { animator.SetBool("Attack", false); }
        yield return new WaitForSeconds(seconds);
        checkFeelPlayer = true;

    }
    // Tan cong nhan vat
    public void AttackPlayer()
    {

        audioSource.clip = Audioattack;
        audioSource.Play();
        BulletFly();


    }
    public void BulletFly()
    {
        BulletInstate = Instantiate(Bullet, transform.position, Quaternion.identity);
        BulletInstate.transform.DOMoveY(-10, 10, false);
    }
}
