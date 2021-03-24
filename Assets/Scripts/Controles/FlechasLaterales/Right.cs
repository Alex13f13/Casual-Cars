using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Right : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed;

    public GameObject Coche;
    public GameObject Controller;

    public float AnguloDeGiro;
    public float velocidad;
    public static float GiroEnZ;

    void Start()
    {
        Coche = FindObjectOfType<Coche>().gameObject;
    }

    void Update()
    {
        

		if (isPressed)
		{
            //Posición
            Controller.transform.Translate(Vector2.right * 0.2f * velocidad * Time.deltaTime);

            //Angulo
            GiroEnZ = 0.2f * -AnguloDeGiro;
        }
               
        Coche.transform.rotation = Quaternion.Euler(0, 0, GiroEnZ);
    }

    #region Funciones

    public void OnPointerDown(PointerEventData eventData)
	{
        isPressed = true;
	}

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        GiroEnZ = 0;
    }

    #endregion
}
