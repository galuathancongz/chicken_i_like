using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScene : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Text text;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(ChangeScene);
    }
  public void ChangeScene()
    {
        SceneManager.LoadScene(text.text,LoadSceneMode.Single);
        button.onClick.RemoveListener(ChangeScene);
    }
}
