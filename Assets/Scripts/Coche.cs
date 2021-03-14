using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour
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

	void Update()
	{
		if (GameOver.activeSelf || ContadorNumerosGO.activeSelf)
		{
			return;
		}

		if (Input.GetMouseButtonDown(0))
		{
			Disparo();
		}
		if (Input.GetKeyDown("space"))
		{
			MotorCarreteras.BufoVelocidad();
		}
	}


	public void Disparo()
	{
		Debug.Log("disparo");
		Instantiate(bullet, spawnPosition.position, spawnPosition.rotation);
	}
}
