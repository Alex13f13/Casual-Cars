using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnClick : MonoBehaviour
{
    public GameObject GO;
    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        GO.SetActive(false);
        Debug.Log("algo");
    }
}
