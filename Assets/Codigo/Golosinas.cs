using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golosinas : MonoBehaviour
{
    public Transform[] posiciones;

    public GameObject[] golosinas;

    int maximoGolosinas = 100;

    public void MasGolosinas()
    {
        int cantidadDeGolosinas = transform.childCount;

        if (cantidadDeGolosinas <= maximoGolosinas)
        {
            for (int i = 0; i < posiciones.Length; i++)
            {
                int int_golosina = Random.Range(0, golosinas.Length);
                GameObject goGolosina = golosinas[int_golosina];

                GameObject go = Instantiate(goGolosina, posiciones[i].position, goGolosina.transform.rotation) as GameObject;
                go.transform.parent = this.transform;
            }
        }
    }
}
