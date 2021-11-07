using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccelerometerBufo : MonoBehaviour
{
	public GameObject GameOver;
	private GameObject ContadorNumerosGO;

	private GameObject motorCarreterasGO;
	private MotorCarreteras MotorCarreteras;

	public GameObject Activo;
	private Image activo;
	public float count;

	public void Start()
	{
		motorCarreterasGO = GameObject.Find("MotorCarreteras");
		MotorCarreteras = motorCarreterasGO.GetComponent<MotorCarreteras>();
		ContadorNumerosGO = GameObject.Find("ContadorNumeros");
		activo = Activo.GetComponent<Image>();
		StartCoroutine(Clock());
	}

	public void Update()
	{
		//Debug.Log(Input.acceleration.y);
		if (Input.acceleration.y > 0)
		{
			Bufo();
		}
	}

	#region Funciones

	public void Bufo()
	{
		if (GameOver.activeSelf || ContadorNumerosGO.activeSelf || count < 1)
		{
			return;
		}
		MotorCarreteras.BufoVelocidad();
		count = 0;
		activo.fillAmount = count;
	}

	IEnumerator Clock()
	{
		yield return new WaitForSeconds(1f);
		if (count >= 1)
		{
			StartCoroutine(Clock());
			Debug.Log("count >= 1");
		}
		else
		{
			count += 0.05f;
			activo.fillAmount = count;
			StartCoroutine(Clock());
		}
	}

	#endregion
}
