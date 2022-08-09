using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoDestroy(3f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BackZone"))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator AutoDestroy(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
