using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurnOffButton : MonoBehaviour
{
    [SerializeField] Button buttonturnoff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        buttonturnoff.onClick.AddListener(TurnOffPopUp);
    }
    void TurnOffPopUp()
    {
       
        gameObject.SetActive(false);
        buttonturnoff.onClick.RemoveListener(TurnOffPopUp);
    }
}
