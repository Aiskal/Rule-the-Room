using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencil : MonoBehaviour
{
    [SerializeField] GameObject pencilSprite;

    private void Start()
    {
        UnEquipPencil();
    }

    private void OnEnable()
    {
        PencilItem.OnItemUsed.AddListener(EquipPencil);
        PencilItem.OnItemUnEquip.AddListener(UnEquipPencil);
    }

    private void OnDisable()
    {
        PencilItem.OnItemUsed.RemoveListener(EquipPencil);
        PencilItem.OnItemUnEquip.RemoveListener(UnEquipPencil);
    }

    void EquipPencil()
    {
        pencilSprite.SetActive(true);
    }

    void UnEquipPencil()
    {
        pencilSprite.SetActive(false);
    }
}
