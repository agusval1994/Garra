using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCerrarColeccion : MonoBehaviour
{
    public GameObject coleccion;

    public void AbrirColeccion()
    {
        coleccion.SetActive(true);
    }

    public void CerrarColeccion()
    {
        coleccion.SetActive(false);
    }
}
