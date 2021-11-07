using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCocheJoystic : MonoBehaviour
{
    public GameObject Coche;
    public GameObject Controller;
    public GameObject GO;

    public float AnguloDeGiro;
    public float velocidad;

    public Joystick joystick;

    void Start()
    {
        Coche = FindObjectOfType<Coche>().gameObject;
    }

    void Update()
    {
        float GiroEnZ = 0;

        Controller.transform.Translate(Vector2.right * joystick.Horizontal * velocidad * Time.deltaTime);

        GiroEnZ = joystick.Horizontal * -AnguloDeGiro;

        Coche.transform.rotation = Quaternion.Euler(0,0,GiroEnZ);


		if (GO == null)
		{
            return;           
        }

        if (joystick.Horizontal > 0 || joystick.Horizontal < 0)
        {
            Destroy(GO);
        }

    }

    #region Funciones



    #endregion
}
