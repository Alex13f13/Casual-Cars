using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
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
        float GiroEnZ = 0;
        Controller.transform.Translate(Vector2.right * Input.acceleration.x * velocidad * Time.deltaTime);

        GiroEnZ = Input.acceleration.x * -AnguloDeGiro;

        Coche.transform.rotation = Quaternion.Euler(0, 0, GiroEnZ);
    }

    #region Funciones



    #endregion
}
