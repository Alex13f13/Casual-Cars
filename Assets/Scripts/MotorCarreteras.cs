using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;

public class MotorCarreteras : MonoBehaviour {

	public GameObject contenedorCallesGO;
	public GameObject[] contenedorCallesArray;

	public float velocidad;
	public bool inicioJuego;
	public bool juegoTerminado;

	int contadorCalles = 0;
	int numeroSelectorCalles;

	public GameObject CalleAnterior;
	public GameObject CalleNueva;

	public float TamañoCalle;

	public Vector3 medidaLimitePantalla;
	public bool Salio;
	public GameObject mCamGo;
	public Camera mCamComp;

	public GameObject cocheGO;
	public GameObject audioFXGO;
	public AudioFX audioFXScript;
	public GameObject bgFinalGO;


	void Start () 
	{
		InicioJuego();
	}

	void InicioJuego()
	{
		contenedorCallesGO = GameObject.Find("ContenedorCalles");

		mCamGo = GameObject.Find("Main Camera");
		mCamComp = mCamGo.GetComponent<Camera>();

		bgFinalGO = GameObject.Find("PanelGameOver");
		bgFinalGO.SetActive(false);

		audioFXGO = GameObject.Find("AudioFX");
		audioFXScript = audioFXGO.GetComponent<AudioFX>();

		cocheGO = GameObject.FindObjectOfType<Coche>().gameObject;

		velocidad = 12;
		MedirPantalla();
		BuscoCalles();
	}

	public void JuegoTerminado()
	{
		cocheGO.GetComponent<AudioSource>().Stop();
		audioFXScript.FXMusic();
		bgFinalGO.SetActive(true);
		AnalyticsResult analyticsResult = Analytics.CustomEvent("Juego Terminado");
		Debug.Log(analyticsResult);
	}

	void BuscoCalles()
	{
		contenedorCallesArray = GameObject.FindGameObjectsWithTag("Calle");
		for(int i = 0; i < contenedorCallesArray.Length ; i++)
		{
			contenedorCallesArray[i].gameObject.transform.parent = contenedorCallesGO.transform;
			contenedorCallesArray[i].gameObject.SetActive(false);
			contenedorCallesArray[i].gameObject.name = "CalleOFF_"+i;
		}
		CrearCalles();

	}

	void CrearCalles()
	{
		contadorCalles ++;
		numeroSelectorCalles = Random.Range(0,contenedorCallesArray.Length);
		GameObject Calle = Instantiate(contenedorCallesArray[numeroSelectorCalles]);
		Calle.SetActive(true);
		Calle.name = "Calle"+contadorCalles;
		Calle.transform.parent = gameObject.transform;
		PosicionoCalles();
	}

	void PosicionoCalles()
	{
		CalleAnterior = GameObject.Find("Calle"+(contadorCalles-1));
		CalleNueva = GameObject.Find("Calle"+contadorCalles);
		MidoCalle();
		CalleNueva.transform.position = new Vector3(CalleAnterior.transform.position.x,
			CalleAnterior.transform.position.y + TamañoCalle, 0);

		Salio = false;
	}

	void MidoCalle()
	{
		for(int i = 0; i < CalleAnterior.transform.childCount; i++)
		{
			if(CalleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
			{
				float tamañoPieza = CalleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
				TamañoCalle = TamañoCalle + tamañoPieza;
			}
		}
	}


	void MedirPantalla()
	{
		medidaLimitePantalla = new Vector3(0,mCamComp.ScreenToWorldPoint(new Vector3(0,0,0)).y - 0.5f,0);
	}

	void Update () 
	{
		if (inicioJuego == true && juegoTerminado == false)
		{
			transform.Translate(Vector3.down * velocidad * Time.deltaTime);

			if (CalleAnterior.transform.position.y + TamañoCalle < medidaLimitePantalla.y && Salio == false)
			{
				Salio = true;
				DestruyoCalles();
			}
		}		
	}

	void DestruyoCalles()
	{
		Destroy(CalleAnterior);
		TamañoCalle = 0;
		CalleAnterior = null;
		CrearCalles();
	}
}
