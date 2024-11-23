using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BaseInventorySlot<T> : MonoBehaviour where T : ItemBase
{
    [SerializeField] Sprite slotsprite;
    Image slotImage;
    public ItemIdentifier Identifyer { get; protected set; } = ItemIdentifier.None;
    protected virtual void Start()
    {
        Transform childTransform = transform.Find("Object");
        slotImage = childTransform.GetComponent<Image>();
        slotImage.sprite = slotsprite;
    }

    public void ItemClicked()
    {
        ItemSelected.Invoke(Identifyer);
    }
    public UnityEvent<ItemIdentifier> ItemSelected { get; set; } = new();
}
