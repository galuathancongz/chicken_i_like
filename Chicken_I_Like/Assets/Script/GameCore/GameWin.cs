using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    
    [SerializeField] GameObject ManagerEnemy;
    [SerializeField] GameObject PopUpNextGame;
    [SerializeField] GameObject SpaceShipMoveobject;
    bool check = true;

    // Update is called once per frame
    void Update()
    {
        Win();
    }
    void Win()
    {
        if (ManagerEnemy.transform.childCount == 0 && check)
        {
            StartCoroutine(NextGame(2f));
        }
    }
    IEnumerator NextGame(float seconds)
    {
        check = false;
        PopUpNextGame.SetActive(true);
        yield return new WaitForSeconds(seconds);
        PopUpNextGame.SetActive(false);
        yield return new WaitForSeconds(seconds);
        SpaceShipMoveobject.transform.DOMoveY(8, 2, false);
        yield return new WaitForSeconds(seconds);
        SpaceShipMoveobject.GetComponent<SpaceShipMove>().enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        check = true;
    }
}
