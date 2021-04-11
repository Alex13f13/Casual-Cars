using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Policia : MonoBehaviour
{
	public int life;
	public GameObject[] inpact;

	public GameObject CronometroGO;
	public Cronometro CronometroScript;
	public GameObject AnalyticsGO;

	void Start()
	{
		CronometroGO = FindObjectOfType<Cronometro>().gameObject;
		CronometroScript = CronometroGO.GetComponent<Cronometro>();
		AnalyticsGO = GameObject.Find("GameMasterAnalytics");
	}

	private void Update()
	{
		switch (life)
		{
			case 0:
				
				break;
			case 1:
				inpact[0].SetActive(true);
				break;
			case 2:
				inpact[1].SetActive(true);
				break;
			case 3:
				AnalyticsGO.GetComponent<GameMasterAnalytics>().policia++;
				Destroy(gameObject);
				break;
		}
	}

	#region Funciones

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Coche>() != null)
		{
			CronometroScript.Finish();
			Destroy(gameObject);
		}
		else if(collision.GetComponent<Bullet>() != null)
		{
			life++;			
			Destroy(collision.gameObject);
		}
	}

	#endregion
}

