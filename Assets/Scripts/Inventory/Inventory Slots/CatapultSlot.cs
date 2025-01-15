using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatapultSlot : BaseInventorySlot
{
    protected override void Awake()
    {
        Identifyer = ItemIdentifier.Eraser;
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        GameSettings.CatapultItem.OnItemUnlocked.AddListener(UpdateButtonLock);
    }

    private void OnDisable()
    {
        GameSettings.CatapultItem.OnItemUnlocked.RemoveListener(UpdateButtonLock);

    }
    public override void ItemClicked()
    {
        if (!GameSettings.CatapultItem.IsUnlocked) return;

        base.ItemClicked();
    }

    protected override bool IsUnlocked()
    {
        return GameSettings.CatapultItem.IsUnlocked;
    }

}
