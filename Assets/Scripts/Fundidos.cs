using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fundidos : MonoBehaviour
{
    public Image Fundido;
    public string[] escenas;

    void Start()
    {
        Fundido.CrossFadeAlpha(0, 0.5f, false);
    }


    #region Funciones

    public void FadeOut(int s)
	{
        Fundido.CrossFadeAlpha(1, 0.5f, false);
        StartCoroutine(CambioEscena(escenas[s]));
	}

    IEnumerator CambioEscena(string escena)
	{
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(escena);
	}
    #endregion
}
