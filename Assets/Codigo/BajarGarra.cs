using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BajarGarra : MonoBehaviour
{
    private MoverGarra moverGarra;
    private Golosinas golosinas;
    public Button boton_bajar_garra;
    public Button boton_mas_golosinas;

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        GameObject go2 = GameObject.FindGameObjectWithTag("Golosinas");
        moverGarra = go.GetComponent<MoverGarra>();
        golosinas = go2.GetComponent<Golosinas>();
    }

    public void BotonBajarGarra()
    {
        if (moverGarra.controlarGarra)
        {
            moverGarra.bajarGarra = true;
            boton_mas_golosinas.interactable = false;

            StartCoroutine(Esperar(7.0f));
        }
    }

    public void BotonMasGolosinas()
    {
        golosinas.MasGolosinas();
        boton_mas_golosinas.interactable = false;

        StartCoroutine(Esperar(2.0f));
    }

    IEnumerator Esperar(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        boton_mas_golosinas.interactable = true;
    }
}
