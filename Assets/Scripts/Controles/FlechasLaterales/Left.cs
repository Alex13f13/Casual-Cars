using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Left : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed;

    public GameObject Coche;
    public GameObject Controller;

    public float AnguloDeGiro;
    public float velocidad;

    void Start()
    {
        Coche = FindObjectOfType<Coche>().gameObject;
    }

    void Update()
    {
        
        if (isPressed)
        {
            //Posición
            Controller.transform.Translate(Vector2.right * -0.2f * velocidad * Time.deltaTime);

            //Angulo
            Right.GiroEnZ = 0.2f * AnguloDeGiro;
        }

    }

    #region Funciones

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        Right.GiroEnZ = 0;
    }

    #endregion
}
