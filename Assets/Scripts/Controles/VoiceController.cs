using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
using TextSpeech;

public class VoiceController : MonoBehaviour
{
    const string Lang_Code = "en-US";

    [SerializeField]
    Text uiText;

    void Start()
    {
        Setup(Lang_Code);

#if UNITY_ANDROID
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
#endif

        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
        TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.instance.onDoneCallback = OnSpeakStop;

        CheckPermission();
        Debug.Log("Started");
    }

    void CheckPermission()
	{
#if UNITY_ANDROID
		if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
		{
            Permission.RequestUserPermission(Permission.Microphone);
            Debug.Log("Permission");
        }
#endif
    }

    void Update()
    {
        
    }

    #region Funciones

    void Setup(string code)
	{
        TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);
	}

    //--------------- Text to Speech -------------------

    public void StartSpeaking(string message)
	{
        TextToSpeech.instance.StartSpeak(message);
	}
    
    public void StopSpeaking()
	{
        TextToSpeech.instance.StopSpeak();
	}

    void OnSpeakStart()
	{
        Debug.Log("Start speaking...");
	}
    
    void OnSpeakStop()
	{
        Debug.Log("Stop speaking...");
	}

    //--------------------- Speech to Text -------------------

    public void StartListening()
    {
        SpeechToText.instance.StartRecording();
        Debug.Log("Listening");
    }

    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
        Debug.Log("StopListen");
    }

    void OnFinalSpeechResult(string result)
	{
        uiText.text = result;
	}

    void OnPartialSpeechResult(string result)
    {
        uiText.text = result;
    }

    #endregion
}
