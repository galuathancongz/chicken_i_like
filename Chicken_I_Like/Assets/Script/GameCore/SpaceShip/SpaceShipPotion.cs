using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipPotion : MonoBehaviour
{
    
    [SerializeField] SpriteRenderer sRender;
    [SerializeField] GameObject spaceshipmini;
    // Start is called before the first frame update

    private void Update()
    {
        spaceshipmini.SetActive(checkpart1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            HeartManager.numberHeart++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Gear"))
        {
            StartCoroutine(Gear(10f));
            Destroy(collision.gameObject);
        }
    }
    bool checkpart1=false;
    bool checkpart2=false;
    IEnumerator Gear(float seconds)
    {
        
        if (checkpart1 == false)
        {
            checkpart1 = true;
            yield return new WaitForSeconds(seconds);
            if (checkpart2 == false)
            {
                checkpart1 = false;
            }
        }
        else
        {
            checkpart2= true;
            yield return new WaitForSeconds(seconds);
            checkpart2 = false;
        }
    }
}
