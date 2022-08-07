using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyingEye : MonoBehaviour
{
    bool checkFeelPlayer = true;
    [SerializeField] LayerMask BackZoneLayer;
    [SerializeField] Animator animator;
     [SerializeField] GameObject Bullet;
    GameObject BulletInstate;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip Audioattack;
    [SerializeField] AudioClip AudioTakeHit;
   // [SerializeField] AudioClip Audiodead;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (checkFeelPlayer) { StartCoroutine(FeelPlayer(0.3f)); }
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
   // Cam thay co nhan vat
    IEnumerator FeelPlayer(float seconds)
    {
        checkFeelPlayer = false;
        int randomattack =Random.Range(0, 50);
       
        
        if(randomattack==3)
        {
           animator.SetBool("Attack", true);
            
        }else { animator.SetBool("Attack", false); }
        yield return new WaitForSeconds(seconds);
        checkFeelPlayer=true;
      
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
        BulletInstate= Instantiate(Bullet,transform.position,Quaternion.identity);
        BulletInstate.transform.DOMoveY(-10, 10, false);
    }

    // Chet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire")) 
        {
            AutoTakeHit();
            Score.score += 1000;
        }
    }
    void AutoTakeHit()
    {
        if(/* neu bi tan cong*/true) { 
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
