using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDisparo : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPosition;
    public GameObject GameOver;
    public GameObject ContadorNumerosGO;

    //Vectores
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;

    void Start()
    {
        ContadorNumerosGO = GameObject.Find("ContadorNumeros");
    }

    void Update()
    {
        if (GameOver.activeSelf || ContadorNumerosGO.activeSelf)
        {
            return;
        }

        Swipe();
    }

    #region Funciones

    public void Swipe()
	{
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if (!stopTouch && Distance.y > swipeRange)
            {
                Disparo();
                stopTouch = true;
            }

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                Debug.Log("Tap");
            }

        }
    }

    public void Disparo()
    {        
        Instantiate(bullet, spawnPosition.position, spawnPosition.rotation);
    }

    #endregion
}
