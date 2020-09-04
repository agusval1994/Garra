using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecolectarItems : MonoBehaviour
{
    public List<int> codigoItems = new List<int>();
    public Image[] listaDeImagenes;
    public GameObject goGolosinas;
    public AudioSource sonidoCaerItem;
    private Golosinas golosinas;
    private Item item;

    private void Awake()
    {
        golosinas = goGolosinas.GetComponent<Golosinas>();
        CargarItems();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Golosinas")
        {
            GameObject go = collision.gameObject;

            item = go.GetComponent<Item>();

            if (!codigoItems.Contains(item.codigoDeItem))
            {
                AgregarItem(item.codigoDeItem, item.icono);
            }

            sonidoCaerItem.Play();
            Destroy(collision.gameObject);
        }
    }

    public void AgregarItem(int codigo ,Sprite imagen)
    {
        codigoItems.Add(codigo);
        Image imagenItem = listaDeImagenes[codigo];
        imagenItem.sprite = imagen;

        SaveSystem.SavePlayer(this);
    }

    public void CargarItems()
    {
        GuardarInfo data = SaveSystem.LoadPlayer();

        if(data != null)
        {
            codigoItems = data.muchosItems;
        }

        if (codigoItems.Count != 0)
        {
            for (int i = 0; i < codigoItems.Count; i++)
            {
                int aux = codigoItems[i];
                GameObject goAux = golosinas.golosinas[aux];
                Image imgAux = listaDeImagenes[aux];

                item = goAux.GetComponent<Item>();

                imgAux.sprite = item.icono;
            }
        }
    }
}
