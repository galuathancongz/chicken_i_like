using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    static public float score = 0;
    [SerializeField] Text text;
    [SerializeField] GameObject ManagerEnemy;    
    [SerializeField] GameObject PopUpNextGame;
    [SerializeField] GameObject SpaceShipMoveobject;
    bool check = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          ChangeScore();
        Win();
    }
    void ChangeScore()
    {
        text.text = score.ToString();
    }
    void Win()
    {
      if(  ManagerEnemy.transform.childCount ==0&&check)
        {
            StartCoroutine(NextGame(2f));
        }
    }
    IEnumerator NextGame(float seconds)
    {
        check = false;
        Debug.Log("Da chay vao day");
        SpaceShipMoveobject.GetComponent<SpaceShipMove>().enabled = false;
        PopUpNextGame.SetActive(true);
        yield return new WaitForSeconds(seconds);
        PopUpNextGame.SetActive(false);
        yield return new WaitForSeconds(seconds+2f);
        SpaceShipMoveobject.transform.DOMoveY(10,2,false);
        yield return new WaitForSeconds(seconds + 4f);
        SpaceShipMoveobject.GetComponent<SpaceShipMove>().enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1, LoadSceneMode.Single);
        check = true;
    }
}
