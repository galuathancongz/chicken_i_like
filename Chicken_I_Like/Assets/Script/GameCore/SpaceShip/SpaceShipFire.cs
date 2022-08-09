using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SpaceShipFire : MonoBehaviour
{
    // Ban
    GameObject Fire;
    [SerializeField] GameObject RedFire;
    [SerializeField] GameObject BlueFire;
    [SerializeField] GameObject FlameRedFire;
    GameObject FireClone;
    bool checkClone=true;
    
    // Doi dan
    [SerializeField] Slider slider= null;
    [SerializeField] float timeFullSlider = 20f;
    float slidervalue = 0;
   

  
    void Start()
    {
        Fire = BlueFire;
       
    }

   
    void Update()
    {
        
        CheckDoubleTap();
        if (SpaceShipStart.gameCanStart)
        {
            if(checkClone) { StartCoroutine(CloneFire(0.3f)); }
        }
        SliderManager();
    }
    IEnumerator CloneFire(float seconds)
    {
        checkClone = false;
       FireClone= Instantiate(Fire, transform.position,Quaternion.identity);
        FireClone.transform.DOMoveY(10, 3, false);
        yield return new WaitForSeconds(seconds);
        checkClone = true;
    }
   
    //DoubleTab
    bool checktap1=true;
    bool checktap2=true;
    void CheckDoubleTap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(checktap1 == true)
            {
                checktap1 = false;
                
                StartCoroutine(WaitTap(0.5f));
            }
            else
            {
               
                checktap2 =false;
            }
        }
        if (checktap1 == false && checktap2 == false)
        {
           
            if (Fire == BlueFire) { 
                Fire = RedFire;
              
               
            }
            else if (Fire == RedFire) { Fire = BlueFire;
           
               
            }
        }
        checktap2 = true;
    }
    IEnumerator WaitTap(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        checktap1 = true;
    }




    // Slider
    void SliderManager()
    {
        slider.value = slidervalue;
        if (Fire == BlueFire)
        {
            slidervalue = slider.value + (slider.maxValue - slider.minValue) * (Time.deltaTime / timeFullSlider);
            FlameRedFire.SetActive(false);
        }
        if (Fire == RedFire)
        {
            FlameRedFire.SetActive(true);
            slidervalue = slider.value - (slider.maxValue - slider.minValue) * (Time.deltaTime / timeFullSlider)*2;
            if (slidervalue <= 0.1f)
            {
                Fire = BlueFire;
            }
        }
    }



}
