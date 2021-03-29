using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoUI : MonoBehaviour
{
	public GameObject bullet;
	public Transform spawnPosition;
	public GameObject GameOver;
	public GameObject ContadorNumerosGO;

	public GameObject motorCarreterasGO;
	public MotorCarreteras MotorCarreteras;

	public void Start()
	{
		motorCarreterasGO = GameObject.Find("MotorCarreteras");
		MotorCarreteras = motorCarreterasGO.GetComponent<MotorCarreteras>();
		ContadorNumerosGO = GameObject.Find("ContadorNumeros");
	}

	#region Funciones

	public void Disparo()
	{
		if (GameOver.activeSelf || ContadorNumerosGO.activeSelf)
		{
			return;
		}
		Instantiate(bullet, spawnPosition.position, spawnPosition.rotation);
	}


	#endregion
}
