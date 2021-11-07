using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
	public GameObject CronometroGO;
	public Cronometro CronometroScript;

	public GameObject AnalyticsGO;

	//public GameObject audioFX;
	//public AudioFX AudioFXscript;


	#region Funciones

	void Start()
	{
		CronometroGO = GameObject.FindObjectOfType<Cronometro>().gameObject;
		CronometroScript = CronometroGO.GetComponent<Cronometro>();
		AnalyticsGO = GameObject.Find("GameMasterAnalytics");

		//audioFX = GameObject.FindObjectOfType<AudioFX>().gameObject;
		//AudioFXscript = audioFX.GetComponent<AudioFX>();
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Coche>() != null)
		{
			//AudioFXscript.FXSonidoCoche();
			CronometroScript.RestartVelocity();
			AnalyticsGO.GetComponent<GameMasterAnalytics>().Bus++;
			CronometroScript.tiempo = CronometroScript.tiempo - 30;
			Destroy(this.gameObject);
		}
		else
		{
			Destroy(collision.gameObject);
		}
	}

	#endregion
}
