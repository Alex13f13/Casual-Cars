using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstáculo : MonoBehaviour
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
			//AudioFXscript.FXSonidoCoche();
			CronometroScript.RestartVelocity();
			Destroy(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
			Destroy(collision.gameObject);
		}
	}

	#endregion
}

