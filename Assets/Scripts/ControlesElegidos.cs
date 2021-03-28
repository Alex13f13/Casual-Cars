using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesElegidos : MonoBehaviour
{
    public GameObject[] controlesMovimiento;
    public GameObject[] controlesDisparo;
    public GameObject[] controlesBufo;

    public int[] controlesElegidos;

    public GameObject controlsGO;
    public ControlsList controlsList;

    void Start()
    {
        controlsGO = GameObject.Find("Controles");
        controlsList = controlsGO.GetComponent<ControlsList>();

        controlesElegidos = controlsList.ControlesElegidos;

        //ActivarControles();
    }

    #region Funciones

    public void ActivarControles()
	{
        controlesMovimiento[controlesElegidos[0]].SetActive(true);
        controlesDisparo[controlesElegidos[1]].SetActive(true);
        controlesBufo[controlesElegidos[2]].SetActive(true);
    }

    #endregion
}
