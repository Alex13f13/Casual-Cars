using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GameMasterAnalytics : MonoBehaviour
{

    #region Singleton

    private static GameMasterAnalytics _instance;

    void Awake()
    {

        if (_instance == null)
        {

            _instance = this;
            DontDestroyOnLoad(this.gameObject);

            //Rest of your Awake code

        }
        else
        {
            Destroy(this);
        }
    }

    #endregion

    public float policia;
    public float relojes;
    public float ruedaOro;
    public float Bus;
    public float obstaculo;

    private string movimientostr;
    private string disparostr;
    private string velocidadstr;

	public void Start()
	{
        Analytics.CustomEvent("Cantidad de Usuarios", new Dictionary<string, object> {
                { "Usuarios", "Cantidad" }
        }
        );
    }


	#region Funciones

	public void ControlesElegidos(string movimiento, string disparo, string velocidad)
	{
        //Debug.Log("Movimiento del coche: " + movimiento);
        //Debug.Log("Disparo: " + disparo);
        //Debug.Log("Bufo de Velocidad: " + velocidad);

        movimientostr = movimiento;
        disparostr = disparo;
        velocidadstr = velocidad;

		Analytics.CustomEvent("Controles Elegidos", new Dictionary<string, object> {
				{ "Movimiento del coche", movimiento },
				{ "Disparo", disparo },
				{ "Bufo de Velocidad", velocidad },
				{ "Convinacion de Controles elegidos", movimiento + " + " + disparo + " + " + velocidad }
			}
		);
    }

    public void EndedGame(float distancia)
    {
        //Debug.Log("Policia Destruida: " + policia);
        //Debug.Log("Relojes Cogidos: " + relojes);
        //Debug.Log("Ruedas de Oro Cogidas: " + ruedaOro);
        //Debug.Log("Bus Colisionados: " + Bus);
        //Debug.Log("Obstáculos Destruidos: " + obstaculo);
        //Debug.Log("Distancia Recorrida: " + distancia);

		Analytics.CustomEvent(movimientostr + " + " + disparostr + " + " + velocidadstr, new Dictionary<string, object> {
				{ "Policia Destruida", policia },
				{ "Relojes Cogidos", relojes },
				{ "Ruedas de Oro Cogidas", ruedaOro },
				{ "Bus Colisionados", Bus },
				{ "Obstaculos Destruidos", obstaculo },
				{ "Distancia Recorrida", distancia},
            }
		);

		policia = 0;
        relojes = 0;
        ruedaOro = 0;
        Bus = 0;
        obstaculo = 0;
    }

    #endregion
}
