using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseButton : MonoBehaviour
{
    [SerializeField] Button button; 
    [SerializeField] GameObject popup;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(ClickToPause);
    }
    void ClickToPause()
    {
        Time.timeScale = 0;
        popup.SetActive(true);
        button.onClick.RemoveListener(ClickToPause);
    }
}
