using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button NewGameButton;
    [SerializeField] Button LevelButton;
    [SerializeField] Button SettingButton;
    [SerializeField] Button QuitButton;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip click;
    // Start is called before the first frame update
    void Start()
    {
        NewGameButton.onClick.AddListener(clickNewGame);
        LevelButton.onClick.AddListener(clicktoLevel);
        SettingButton.onClick.AddListener(clicktoSetting);
        QuitButton.onClick.AddListener(clicktoQuit);
        audioSource.Play();
    }

    // Update is called once per frame
    
    void clickNewGame()
    {
        audioSource.PlayOneShot(click);
        SceneManager.LoadScene("Scene 1", LoadSceneMode.Single);
        HeartManager.numberHeart = 5;
        Score.score = 0;
        NewGameButton.onClick.RemoveListener(clickNewGame);
        

    }
    void clicktoLevel()
    {
        audioSource.PlayOneShot(click);
        SceneManager.LoadScene("SceneLevel", LoadSceneMode.Single);

        LevelButton.onClick.RemoveListener(clicktoLevel);


    }
    void clicktoSetting()
    {
        audioSource.PlayOneShot(click);
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
        SettingButton.onClick.RemoveListener(clicktoSetting);
        
    }
    void clicktoQuit()
    {
        audioSource.PlayOneShot(click);
        Application.Quit();
        QuitButton.onClick.RemoveListener(clicktoQuit);
        
    }
   
}
