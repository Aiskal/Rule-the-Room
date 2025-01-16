using System;
using UnityEngine;

public class GameSettings : SingletonMB<GameSettings>
{
    private void OnApplicationQuit()
    {
        Quitting = true;
    }

    IItemBase activeItem { get; set; }
    public static IItemBase ActiveItem { get => Instance.activeItem; set => Instance.activeItem = value; }  

    static GameSettings instance;
    public bool drawGizmos = true;

    public static bool Quitting { get; set; } = false;

    //------------------------------------------------------------------------------------------------------------------
    [Header("Objets")]
    [SerializeField] GameObject playerObject;

    public static GameObject PlayerObject { get => Instance.playerObject; }


    //------------------------------------------------------------------------------------------------------------------
    [Header("Items")]
    [SerializeField] CatapultItem catapultItem;
    [SerializeField] EraserItem eraserItem;
    [SerializeField] HammerItem hammerItem;
    [SerializeField] PencilItem pencilItem;
    [SerializeField] PlaneItem planeItem;
    [SerializeField] RulerItem rulerItem;
    [SerializeField] SkotchItem skotchItem;

    public static CatapultItem CatapultItem { get => Instance.catapultItem; }
    public static EraserItem EraserItem { get => Instance.eraserItem; }
    public static HammerItem HammerItem  { get => Instance.hammerItem; }
    public static PencilItem PencilItem { get => Instance.pencilItem; }
    public static PlaneItem PlaneItem { get => Instance.planeItem; }
    public static RulerItem RulerItem { get => Instance.rulerItem; }
    public static SkotchItem SkotchItem { get => Instance.skotchItem; }

    //------------------------------------------------------------------------------------------------------------------
    [Header("Sprites")]
    [SerializeField] Sprite catapultSprite;
    [SerializeField] Sprite eraserSprite;
    [SerializeField] Sprite hammerSprite;
    [SerializeField] Sprite pencilSprite;
    [SerializeField] Sprite planeSprite;
    [SerializeField] Sprite rulerSprite;
    [SerializeField] Sprite skotchSprite;

    public static Sprite GetSprite(ItemIdentifier result)
    {
        switch (result)
        {
            case ItemIdentifier.Pencil: return Instance.pencilSprite;
            case ItemIdentifier.Eraser: return Instance.eraserSprite;
            case ItemIdentifier.Hammer: return Instance.hammerSprite;
            case ItemIdentifier.Catapults: return Instance.catapultSprite;
            case ItemIdentifier.Plane : return Instance.planeSprite;
            case ItemIdentifier.Skotch: return Instance.skotchSprite;
            case ItemIdentifier.Ruler : return Instance.rulerSprite;
            default: return null;
        }
    }

    public static string GetItemDescription(ItemIdentifier result)
    {
        switch (result)
        {
            case ItemIdentifier.Catapults: return Instance.catapultItem.GetDescription();
            case ItemIdentifier.Eraser: return Instance.eraserItem.GetDescription();
            case ItemIdentifier.Hammer: return Instance.hammerItem.GetDescription();
            case ItemIdentifier.Pencil: return Instance.pencilItem.GetDescription();
            case ItemIdentifier.Plane: return Instance.planeItem.GetDescription();
            case ItemIdentifier.Ruler: return Instance.rulerItem.GetDescription();
            case ItemIdentifier.Skotch: return Instance.skotchItem.GetDescription();
            default: return null;
        }
    }

    public static IItemBase GetItem(ItemIdentifier item)
    {
        switch (item)
        {
            case ItemIdentifier.Catapults: return Instance.catapultItem;
            case ItemIdentifier.Eraser: return Instance.eraserItem;
            case ItemIdentifier.Hammer: return Instance.hammerItem;
            case ItemIdentifier.Pencil: return Instance.pencilItem;
            case ItemIdentifier.Plane: return Instance.planeItem;
            case ItemIdentifier.Ruler: return Instance.rulerItem;
            case ItemIdentifier.Skotch: return Instance.skotchItem;
            default: return null;
        }
    }
}
