using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenUIButton : ButtonBehaviour
{
    [SerializeField] private GameObject inventoryCanvas;
    [SerializeField] private Sprite backpackSprite;
    [SerializeField] private Color backpackColor = Color.white;
    [SerializeField] private Sprite crossSprite;
    [SerializeField] private Color crossColor = Color.black;
    
    private Image buttonImage;

    public void BS_ToggleInventory()
    {
        if (inventoryCanvas != null)
        {
            bool isActive = inventoryCanvas.activeSelf;
            inventoryCanvas.SetActive(!isActive);

            UpdateButtonAppearance(!isActive);
        }
        else
        {
            Debug.LogWarning("Aucun Canvas d'inventaire assigné !");
        }
    }

    private void UpdateButtonAppearance(bool isOpen)
    {
        if (buttonImage == null)
        {
            Debug.LogWarning("Aucune image associée au bouton !");
            return;
        }

        buttonImage.sprite = isOpen ? crossSprite : backpackSprite;
        buttonImage.color = isOpen ? crossColor : backpackColor;
    }

    private void Start()
    {
        buttonImage = GetComponent<Image>();

        if (inventoryCanvas != null)
        {
            UpdateButtonAppearance(inventoryCanvas.activeSelf);
        }
    }
}
