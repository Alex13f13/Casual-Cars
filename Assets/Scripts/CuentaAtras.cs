using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{
    public GameObject motorCarreterasGO;
    public MotorCarreteras MotorCarreteras;

    public Sprite[] numeros;
    public GameObject ContadorNumerosGO;
    public SpriteRenderer ContadorNumerosComp;

    public GameObject ControladorCoche;
    public GameObject Coche;


    void Start()
    {
        InicioComponentes();
    }

    void Update()
    {
        
    }

    #region Funciones

    void InicioComponentes()
    {
        motorCarreterasGO = GameObject.Find("MotorCarreteras");
        MotorCarreteras = motorCarreterasGO.GetComponent<MotorCarreteras>();

        ContadorNumerosGO = GameObject.Find("ContadorNumeros");
        ContadorNumerosComp = ContadorNumerosGO.GetComponent<SpriteRenderer>();

        Coche = GameObject.Find("Coche");
        ControladorCoche = GameObject.Find("ControladorCoche");

        InicioCuentaAtras();

    }
    void InicioCuentaAtras()
    {
        StartCoroutine(Contando());
    }

    IEnumerator Contando()
    {
        ControladorCoche.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        ContadorNumerosComp.sprite = numeros[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        ContadorNumerosComp.sprite = numeros[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        ContadorNumerosComp.sprite = numeros[3];
        MotorCarreteras.inicioJuego = true;
        ContadorNumerosGO.GetComponent<AudioSource>().Play();
        Coche.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        ContadorNumerosGO.SetActive(false);
    }

    #endregion
}
