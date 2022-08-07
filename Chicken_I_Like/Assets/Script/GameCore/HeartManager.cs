using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class HeartManager : MonoBehaviour
{
    [SerializeField] GameObject popupGameOver;
    [SerializeField] public Text text;
    static public int numberHeart=5;
    
   
    public void Update()
    {
        if (numberHeart == 0&& popupGameOver.active==false)
        {
            popupGameOver.SetActive(true);

        }
        ChangeNumberHeart();
    }
    public void ChangeNumberHeart()
    {
        text.text = numberHeart.ToString();
    }
}
