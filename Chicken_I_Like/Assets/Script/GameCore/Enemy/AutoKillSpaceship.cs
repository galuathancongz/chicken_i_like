using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AutoKillSpaceship : MonoBehaviour
{
    [SerializeField] GameObject SpaceClone;
    [SerializeField] GameObject SpaceShip;
    Vector2 NowLocation;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        RandomAutoKill();
        Debug.Log(gameObject.transform.childCount);
    }
    
    void RandomAutoKill()
    {
     int numberauto=  Random.Range(1, 100);
        if (numberauto == 30&&transform.childCount>2)
        {
            transform.GetChild(0).GetComponent<FlyingEye>().enabled = false;
            StartCoroutine(TimeEnable(2f));
            transform.GetChild(0).transform.DOJump(SpaceShip.transform.position, 6, 1, 1f, false);
        }
    }
    IEnumerator TimeEnable(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        transform.GetChild(0).GetComponent<FlyingEye>().enabled = true;

    }
}
