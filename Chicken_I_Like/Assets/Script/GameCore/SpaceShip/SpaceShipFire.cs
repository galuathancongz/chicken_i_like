using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpaceShipFire : MonoBehaviour
{
    [SerializeField] GameObject Fire;
    GameObject FireClone;
    bool checkClone=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpaceShipStart.gameCanStart)
        {
            if(checkClone) { StartCoroutine(CloneFire(0.2f)); }
        }
        
    }
    IEnumerator CloneFire(float seconds)
    {
        checkClone = false;
       FireClone= Instantiate(Fire, transform.position,Quaternion.identity);
        FireClone.transform.DOMoveY(10, 3, false);
        yield return new WaitForSeconds(seconds);
        checkClone = true;
    }
    
}
