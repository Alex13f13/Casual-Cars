using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static SpeechRecognizerPlugin;

public class SpeechRecognizerBufo : MonoBehaviour, ISpeechRecognizerPlugin
{
    private SpeechRecognizerPlugin plugin = null;

    public bool listen;

    private GameObject motorCarreterasGO;
    private MotorCarreteras MotorCarreteras;

    public GameObject Activo;
    private Image activo;
    public float count;

    public GameObject GameOver;
    public GameObject ContadorNumerosGO;

    void Start()
    {
        plugin = GetPlatformPluginVersion(this.gameObject.name);
        motorCarreterasGO = GameObject.Find("MotorCarreteras");
        MotorCarreteras = motorCarreterasGO.GetComponent<MotorCarreteras>();
        ContadorNumerosGO = GameObject.Find("ContadorNumeros");
        activo = Activo.GetComponent<Image>();
        StartCoroutine(Clock());
        StartListening();
    }

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
        char[] delimiterChars = { '~' };
        string[] result = recognizedResult.Split(delimiterChars);

        for (int i = 0; i < result.Length; i++)
        {
            if (result[i] == "bufo" || result[i] == "velocidad" || result[i] == "go")
            {
                Bufo();
            }            
        }
    }
}
