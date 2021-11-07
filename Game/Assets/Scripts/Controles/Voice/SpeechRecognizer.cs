using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SpeechRecognizerPlugin;

public class SpeechRecognizer : MonoBehaviour, ISpeechRecognizerPlugin
{
    private SpeechRecognizerPlugin plugin = null;

    public bool listen;

    public GameObject Coche;
    public GameObject Controller;

    public GameObject GameOver;
    public GameObject ContadorNumerosGO;

    public float AnguloDeGiro;
    public float velocidad;

    private float horizontal;

    void Start()
    {
        plugin = GetPlatformPluginVersion(this.gameObject.name);
        Coche = FindObjectOfType<Coche>().gameObject;
        ContadorNumerosGO = GameObject.Find("ContadorNumeros");
        StartListening();
    }

	public void Update()
	{
        float GiroEnZ = 0;        

        Controller.transform.Translate(Vector2.right * horizontal * velocidad * Time.deltaTime);

        GiroEnZ = horizontal * -AnguloDeGiro;

        Coche.transform.rotation = Quaternion.Euler(0, 0, GiroEnZ);        
    }

	private void StartListening()
    {
        plugin.StartListening();
        SetContinuousListening(listen);
    }

    private void SetContinuousListening(bool isContinuous)
    {
        plugin.SetContinuousListening(isContinuous);
    }

    public void OnResult(string recognizedResult)
    {
        if (GameOver.activeSelf || ContadorNumerosGO.activeSelf)
        {
            return;
        }

        char[] delimiterChars = { '~' };
        string[] result = recognizedResult.Split(delimiterChars);

        for (int i = 0; i < result.Length; i++)
        {

            if (result[i] == "derecha" || result[i] == "right")
            {
                horizontal = 0.2f;
            }
            else if (result[i] == "izquierda" || result[i] == "left")
            {
                horizontal = -0.2f;
            }
            else if (result[i] == "para" || result[i] == "stop")
            {
                horizontal = 0;
            }
        }
    }
}
