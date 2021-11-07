using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuedaOro : MonoBehaviour
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
			AnalyticsGO.GetComponent<GameMasterAnalytics>().ruedaOro++;
			CronometroScript.distancia = CronometroScript.distancia + 20;
			Destroy(gameObject);
		}
	}

	#endregion
}
