using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FireBlue : MonoBehaviour
{
    [SerializeField] GameObject HeartPotion;
    GameObject HeartPotionClone;
    [SerializeField] GameObject GearPotion;
    GameObject GearPotionClone;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BackZone"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            ClonePotion();
        }
    }
    void ClonePotion()
    {
        int ramdomclone = Random.Range(1, 20);
        if (ramdomclone==1) {
            switch (Random.Range(1, 3))
            {
                case 1: HeartPotionClone = Instantiate(HeartPotion, transform.position, Quaternion.identity); HeartPotionClone.transform.DOMoveY(-10, 10, false); break;
                case 2: GearPotionClone = Instantiate(GearPotion, transform.position, Quaternion.identity); GearPotionClone.transform.DOMoveY(-10, 10, false); break;
            }
        }
    }
}
