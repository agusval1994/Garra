using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GuardarInfo
{
    public int[] items;
    public List<int> muchosItems = new List<int>();

    public GuardarInfo(RecolectarItems recolectarItems)
    {
        muchosItems = recolectarItems.codigoItems;
    }
}
