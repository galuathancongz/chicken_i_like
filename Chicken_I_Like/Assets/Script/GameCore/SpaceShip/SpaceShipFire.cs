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
                Debug.Log("Vao check1");
                StartCoroutine(WaitTap(1f));
            }
            else
            {
                Debug.Log("Vao check2");
                checktap2 =false;
            }
        }
        if (checktap1 == false && checktap2 == false)
        {
            Debug.Log("Vao doi cau");
            if (Fire == BlueFire) { Fire = RedFire;
                Debug.Log("Doi sang mau do");
            }
            else if (Fire == RedFire) { Fire = BlueFire;
                Debug.Log("Doi sang mau xanh");
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
        }
        if (Fire == RedFire)
        {
            slidervalue = slider.value - (slider.maxValue - slider.minValue) * (Time.deltaTime / timeFullSlider)*2;
            if (slidervalue <= 0.1f)
            {
                Fire = BlueFire;
            }
        }
    }



}
