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
    public GameObject AnalyticsGO;
    public ControlsList controlsList;

    void Start()
    {
        controlsGO = GameObject.Find("Controles");
        AnalyticsGO = GameObject.Find("GameMasterAnalytics");
        controlsList = controlsGO.GetComponent<ControlsList>();

        controlesElegidos = controlsList.ControlesElegidos;

        ActivarControles();
    }

    #region Funciones

    public void ActivarControles()
	{
        controlesMovimiento[controlesElegidos[0]].SetActive(true);
        controlesDisparo[controlesElegidos[1]].SetActive(true);
        controlesBufo[controlesElegidos[2]].SetActive(true);

        AnalyticsGO.GetComponent<GameMasterAnalytics>().ControlesElegidos(controlesMovimiento[controlesElegidos[0]].name,
            controlesDisparo[controlesElegidos[1]].name, controlesBufo[controlesElegidos[2]].name);
    }

    #endregion
}
