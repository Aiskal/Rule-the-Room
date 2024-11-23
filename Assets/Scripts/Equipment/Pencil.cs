using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencil : MonoBehaviour
{
    [SerializeField] GameObject pencilSprite;

    private void Start()
    {
        UnEquipPencil(ItemIdentifier.Pencil);
    }

    private void OnEnable()
    {
        PencilItem.OnItemEquiped.AddListener(EquipPencil);
        PencilItem.OnItemUnEquip.AddListener(UnEquipPencil);
    }

    private void OnDisable()
    {
        PencilItem.OnItemEquiped.RemoveListener(EquipPencil);
        PencilItem.OnItemUnEquip.RemoveListener(UnEquipPencil);
    }

    void EquipPencil(ItemIdentifier item)
    {
        if (item != ItemIdentifier.Pencil) return;
        pencilSprite.SetActive(true);
    }

    void UnEquipPencil(ItemIdentifier item)
    {
        if (item != ItemIdentifier.Pencil) return;
        pencilSprite.SetActive(false);
    }
}
