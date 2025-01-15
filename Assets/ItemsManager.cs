using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    ItemIdentifier equipedItem = ItemIdentifier.None;

    void OnEnable()
    {
        GameSettings.PencilItem.OnItemEquiped.AddListener(OnItemEquiped);
        GameSettings.EraserItem.OnItemEquiped.AddListener(OnItemEquiped);
        GameSettings.SkotchItem.OnItemEquiped.AddListener(OnItemEquiped);
        GameSettings.HammerItem.OnItemEquiped.AddListener(OnItemEquiped);
        GameSettings.PlaneItem.OnItemEquiped.AddListener(OnItemEquiped);
        GameSettings.RulerItem.OnItemEquiped.AddListener(OnItemEquiped);
        //GameSettings.CatapultItem.OnItemEquiped.AddListener(OnItemEquiped);
    }

    private void OnItemEquiped(ItemIdentifier item)
    {
        if(equipedItem != ItemIdentifier.None)
        {
            GameSettings.GetItem(equipedItem).UnequipItem();
        }
        switch (item)
        {
            case ItemIdentifier.Pencil: GameSettings.PencilItem.gameObject.SetActive(true); break;
            case ItemIdentifier.Eraser:    GameSettings.EraserItem.gameObject.SetActive(true); break;
            case ItemIdentifier.Skotch:    GameSettings.SkotchItem.gameObject.SetActive(true); break;
            case ItemIdentifier.Hammer:    GameSettings.HammerItem.gameObject.SetActive(true); break;
            case ItemIdentifier.Plane:     GameSettings.PlaneItem.gameObject.SetActive(true); break;
            case ItemIdentifier.Ruler:     GameSettings.RulerItem.gameObject.SetActive(true); break;
            case ItemIdentifier.Catapults:    GameSettings.CatapultItem.gameObject.SetActive(true); break;
        }
        equipedItem = item;
    }
}
