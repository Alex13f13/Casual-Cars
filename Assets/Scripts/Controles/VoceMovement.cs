using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoceMovement : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    public Text uiText;

    void Start()
    {
        actions.Add("forward", Forward);
        actions.Add("up", Up);
        actions.Add("down", Down);
        actions.Add("back", Back);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += ReconizedSpeech;
        keywordRecognizer.Start();
    }

    #region Funciones

    private void ReconizedSpeech(PhraseRecognizedEventArgs speech)
	{
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
	}

    private void Forward()
	{
        Debug.Log("Forward_Event");
        uiText.text = "Forward_Event";
    }

    private void Back()
    {
        Debug.Log("Back_Event");
        uiText.text = "Back_Event";
    }

    private void Up()
    {
        Debug.Log("Up_Event");
        uiText.text = "Up_Event";
    }

    private void Down()
    {
        Debug.Log("Down_Event");
        uiText.text = "Down_Event";
    }

    #endregion
}
