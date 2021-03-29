using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMove : MonoBehaviour
{
    public GameObject Coche;
    public GameObject Controller;

    public float AnguloDeGiro;
    public float velocidad;

    //Vectores
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;

    private float horizontal;

    void Start()
    {
        Coche = FindObjectOfType<Coche>().gameObject;
    }

    void Update()
    {
        float GiroEnZ = 0;

        Swipe();

        Controller.transform.Translate(Vector2.right * horizontal * velocidad * Time.deltaTime);

        GiroEnZ = horizontal * -AnguloDeGiro;

        Coche.transform.rotation = Quaternion.Euler(0, 0, GiroEnZ);
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

            if (!stopTouch)
            {
                //Left
                if (Distance.x < -swipeRange)
                {
                    Debug.Log("Left");
                    horizontal = -0.2f;
                    stopTouch = true;
                }
                //Right
                else if (Distance.x > swipeRange)
                {
                    Debug.Log("Right");
                    horizontal = 0.2f;
                    stopTouch = true;
                }
                //Up
                //else if (Distance.y > swipeRange)
                //{
                //    stopTouch = true;
                //}
                ////Down
                //else if (Distance.y < -swipeRange)
                //{
                //    stopTouch = true;
                //}

            }

        }

        //Tap

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                Debug.Log("Tap");
                horizontal = 0;
            }

        }
    }

    #endregion
}
