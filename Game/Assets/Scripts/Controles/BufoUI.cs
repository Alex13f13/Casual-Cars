using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BufoUI : MonoBehaviour
{
	public GameObject GameOver;
	public GameObject ContadorNumerosGO;

	public GameObject motorCarreterasGO;
	public MotorCarreteras MotorCarreteras;

	public GameObject Activo;
	public Image activo;
	public float count;

	public void Start()
	{
		motorCarreterasGO = GameObject.Find("MotorCarreteras");
		MotorCarreteras = motorCarreterasGO.GetComponent<MotorCarreteras>();
		ContadorNumerosGO = GameObject.Find("ContadorNumeros");
		activo = Activo.GetComponent<Image>();
		StartCoroutine(Clock());
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
