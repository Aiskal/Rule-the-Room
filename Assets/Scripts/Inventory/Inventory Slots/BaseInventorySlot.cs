using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BaseInventorySlot : MonoBehaviour
{
    [SerializeField] Sprite slotsprite;
    [SerializeField] GameObject description;

    protected Image slotImage;
    protected Image slotImageBg;
    protected Button button;
    private bool selected;

    public ItemIdentifier Identifyer { get; protected set; } = ItemIdentifier.None;

    public UnityEvent<ItemIdentifier> ItemSelected { get; set; } = new();

    protected virtual void Start()
    {
        Transform childTransform = transform.Find("Object");
        slotImage = childTransform.GetComponent<Image>();
        slotImage.sprite = slotsprite;
        Transform childTransformBg = transform.Find("Image");
        slotImageBg = childTransformBg.GetComponent<Image>();
        button = GetComponent<Button>();

        UpdateButtonLock(0);
        ItemBase.OnItemUnlocked.AddListener(UpdateButtonLock);
    }

    public virtual void ItemClicked()
    {
        ItemSelected.Invoke(Identifyer);
        selected = !selected;
        slotImage.color = new Color(100, 255, 100);
        UpdateButtonState();
        UpdateDescription(description);
    }

    protected virtual bool IsUnlocked()
    {
        return false;
    }
    protected virtual void UpdateButtonLock(ItemIdentifier item)
    {
        if (!IsUnlocked())
        {
            if (slotImage != null) slotImage.color = new Color(0f, 0f, 0f, 130f / 255f); ;
            if (slotImageBg != null) slotImageBg.color = new Color32(0x6A, 0x6A, 0x6A, 255);
        }
        else
        {
            if (slotImage != null) slotImage.color = Color.white;
            if (slotImageBg != null) slotImageBg.color = Color.white;
        }
    }

    private void UpdateButtonState()
    {
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

    public virtual void UpdateDescription(GameObject description)
    {

    }
}
