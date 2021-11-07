using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstáculo : MonoBehaviour
{
	public GameObject CronometroGO;
	public Cronometro CronometroScript;

	public GameObject AnalyticsGO;

	void Start()
	{
		CronometroGO = GameObject.FindObjectOfType<Cronometro>().gameObject;
		CronometroScript = CronometroGO.GetComponent<Cronometro>();
		AnalyticsGO = GameObject.Find("GameMasterAnalytics");
	}

	#region Funciones

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Coche>() != null)
		{
			//AudioFXscript.FXSonidoCoche();
			CronometroScript.RestartVelocity();
			Destroy(this.gameObject);
		}
		else
		{
			AnalyticsGO.GetComponent<GameMasterAnalytics>().obstaculo++;
			Destroy(this.gameObject);
			Destroy(collision.gameObject);
		}
	}

	#endregion
}

