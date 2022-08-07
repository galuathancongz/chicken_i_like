using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipPotion : MonoBehaviour
{
    
    [SerializeField] SpriteRenderer sRender;
    [SerializeField] GameObject spaceshipmini;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    HeartManager HeartManager = new HeartManager();
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
 
    IEnumerator Gear(float seconds)
    {

        spaceshipmini.SetActive(true);
        yield return new WaitForSeconds(seconds);
        spaceshipmini.SetActive(false);
    }
}
