using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsList : MonoBehaviour
{
    public int[] ControlesElegidos = new int[3];


	public void Start()
	{        
        DontDestroyOnLoad(gameObject);
    }

	#region Funciones

	public void Movimiento(int controlTipe)
	{
        ControlesElegidos[0] = controlTipe;
    }

    public void Disparo(int controlTipe)
    {
        ControlesElegidos[1] = controlTipe;
    }

    public void Bufo(int controlTipe)
    {
        ControlesElegidos[2] = controlTipe;
    }

    #endregion
}
