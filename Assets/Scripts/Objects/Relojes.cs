using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relojes : MonoBehaviour
{
	public GameObject CronometroGO;
	public Cronometro CronometroScript;

	//public GameObject audioFX;
	//public AudioFX AudioFXscript;


	#region Funciones

	void Start()
	{
		CronometroGO = GameObject.FindObjectOfType<Cronometro>().gameObject;
		CronometroScript = CronometroGO.GetComponent<Cronometro>();

		//audioFX = GameObject.FindObjectOfType<AudioFX>().gameObject;
		//AudioFXscript = audioFX.GetComponent<AudioFX>();
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Coche>() != null)
		{
			//AudioFXscript.FXSonidoCoche();
			CronometroScript.tiempo = CronometroScript.tiempo + 10;
			Destroy(this.gameObject);
		}
	}

	#endregion
}
