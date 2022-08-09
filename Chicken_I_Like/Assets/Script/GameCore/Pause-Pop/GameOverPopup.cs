using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPopup : MonoBehaviour
{

    
    [SerializeField] Button buttonback;
    [SerializeField] Button buttonrestart;
    [SerializeField] Button buttonhelp;
    [SerializeField] GameObject PopUpHelp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        buttonback.onClick.AddListener(ClickToBack);
        buttonrestart.onClick.AddListener(ClickToRestart);
        buttonhelp.onClick.AddListener(ClickToHelp);
    }
    
    void ClickToBack()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SceneHome", LoadSceneMode.Single);
        buttonback.onClick.RemoveListener(ClickToBack);
    }
    void ClickToRestart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        Time.timeScale = 1;
        HeartManager.numberHeart = 5;
        buttonback.onClick.RemoveListener(ClickToRestart);
    }

    void ClickToHelp()
    {
        PopUpHelp.SetActive(true);
        buttonhelp.onClick.RemoveListener(ClickToHelp);
    }
}
