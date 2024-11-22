using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUIButton : ButtonBehaviour
{
    [SerializeField] private GameObject inventoryCanvas;

    public void BS_ToggleInventory()
    {
        if (inventoryCanvas != null)
        {
            bool isActive = inventoryCanvas.activeSelf;
            inventoryCanvas.SetActive(!isActive);
        }
        else
        {
            Debug.LogWarning("Aucun Canvas d'inventaire assigné !");
        }
    }

}
