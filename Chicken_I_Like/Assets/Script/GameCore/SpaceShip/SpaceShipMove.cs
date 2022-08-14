using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpaceShipMove : MonoBehaviour
{
    Vector2 newPos;
    [SerializeField] SpriteRenderer sRender;
    
  
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        SpaceShipStart spaceShipStart = new SpaceShipStart();
        if (SpaceShipStart.gameCanStart)
        {
            SpacePositon();
        }
    }
    void SpacePositon()
    {
        
        newPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        newPos.y = -3.5f;
        transform.position = newPos;
        if (newPos.x < -0.75f) { transform.DORotate(new Vector3(0, -45, 0), 2f, RotateMode.Fast); }
        else if (newPos.x > 0.75f) { transform.DORotate(new Vector3(0, 45, 0), 2f, RotateMode.Fast); }
        else { transform.DORotate(new Vector3(0, 0, 0), 2f, RotateMode.Fast); }   

    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HeartManager.numberHeart--;
            StartCoroutine(Hurt(0.3f));

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HeartManager.numberHeart--;
            Destroy(collision.gameObject);
            StartCoroutine(Hurt(0.3f));

        }
    }
    IEnumerator Hurt(float seconds)
    {
        Color newColor = sRender.color;
        newColor.a = 0;
        sRender.color = newColor;
        yield return new WaitForSeconds(seconds);
        newColor.a = 100;
        sRender.color = newColor;
    }

}
