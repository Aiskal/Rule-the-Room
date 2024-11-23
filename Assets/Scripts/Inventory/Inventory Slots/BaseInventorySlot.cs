using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BaseInventorySlot : MonoBehaviour
{
    [SerializeField] Sprite slotsprite;
    Image slotImage;
    Image slotImageBg;
    bool selected;
    Button button;

    public ItemIdentifier Identifyer { get; protected set; } = ItemIdentifier.None;
    protected virtual void Start()
    {
        Transform childTransform = transform.Find("Object");
        slotImage = childTransform.GetComponent<Image>();
        slotImage.sprite = slotsprite;
        Transform childTransformBg = transform.Find("Image");
        slotImageBg = childTransformBg.GetComponent<Image>();
        button = GetComponent<Button>();
    }

    public virtual void ItemClicked()
    {
        ItemSelected.Invoke(Identifyer);
        selected = !selected;
        slotImage.color = new Color(100, 255, 100);
        UpdateButtonState();
    }
    public UnityEvent<ItemIdentifier> ItemSelected { get; set; } = new();

    private void UpdateButtonState()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            if (selected)
            {
                slotImage.color = new Color(0.39f, 1f, 0.39f); // Vert pâle
                slotImageBg.color = new Color(0.39f, 1f, 0.39f);
            }
            else
            {
                slotImage.color = Color.white; // Réinitialiser la couleur
                slotImageBg.color = Color.white;
            }
        }
        else
        {
            Debug.LogWarning("Aucun bouton trouvé pour gérer l'état Selected.");
        }
    }
}
