using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using static SpeechRecognizerPlugin;

public class SpeechRecognizerDisparo : MonoBehaviour, ISpeechRecognizerPlugin
{
    private SpeechRecognizerPlugin plugin = null;

    public bool listen;

    public GameObject bullet;
    public Transform spawnPosition;
    public GameObject GameOver;
    public GameObject ContadorNumerosGO;

    void Start()
    {
        plugin = GetPlatformPluginVersion(this.gameObject.name);
        ContadorNumerosGO = GameObject.Find("ContadorNumeros");
        StartListening();
    }

    public void Disparo()
    {
        if (GameOver.activeSelf || ContadorNumerosGO.activeSelf)
        {
            return;
        }
        Instantiate(bullet, spawnPosition.position, spawnPosition.rotation);
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
            if (result[i] == "disparo")
            {
                StartCoroutine(Clock());
            }            
        }
    }

    IEnumerator Clock()
    {
        yield return new WaitForSeconds(0.5f);
        Disparo();
        yield return new WaitForSeconds(0.5f);
        Disparo();
        yield return new WaitForSeconds(0.5f);
        Disparo();
    }
}
