using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuedaOro : MonoBehaviour
{
	public GameObject CronometroGO;
	public Cronometro CronometroScript;

	void Start()
	{
		CronometroGO = GameObject.FindObjectOfType<Cronometro>().gameObject;
		CronometroScript = CronometroGO.GetComponent<Cronometro>();
	}

	#region Funciones

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Coche>() != null)
		{
			CronometroScript.distancia = CronometroScript.distancia + 20;
			Debug.Log("Rueda Oro");
			Destroy(gameObject);
		}
	}

	#endregion
}
