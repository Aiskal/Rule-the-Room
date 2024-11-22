using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseInventorySlot<T> : MonoBehaviour where T : ItemBase
{
    [SerializeField] Sprite slotsprite;
    Image slotImage;
    private void Start()
    {
        Transform childTransform = transform.Find("Object");
        slotImage = childTransform.GetComponent<Image>();
        slotImage.sprite = slotsprite;
    }
}
