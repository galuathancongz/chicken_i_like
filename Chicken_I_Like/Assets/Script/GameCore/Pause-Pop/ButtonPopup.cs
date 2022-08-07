using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPopup : MonoBehaviour
{
    
    [SerializeField] Button buttonturnoff;
    [SerializeField] Button buttonback;
    [SerializeField] Button buttonmute;
    [SerializeField] Button buttonhelp;
    [SerializeField] GameObject PopUpHelp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        buttonturnoff.onClick.AddListener(TurnOffPopUp);
        buttonback.onClick.AddListener(ClickToBack);
        buttonmute.onClick.AddListener(ClickToMute);
        buttonhelp.onClick.AddListener(ClickToHelp);
    }
    void TurnOffPopUp()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        buttonturnoff.onClick.RemoveListener(TurnOffPopUp);
    }
    void ClickToBack()
    {
       
        SceneManager.LoadScene("SceneHome", LoadSceneMode.Single);
        buttonback.onClick.RemoveListener(ClickToBack);
    }
    void ClickToMute()
    {
        AudioListener.pause = true;
        buttonmute.onClick.RemoveListener(ClickToMute);
    }
    void ClickToHelp()
    {
        PopUpHelp.SetActive(true);
        buttonhelp.onClick.RemoveListener(ClickToHelp);
    }
}
