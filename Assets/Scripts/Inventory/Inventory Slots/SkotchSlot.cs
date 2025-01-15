using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkotchSlot : BaseInventorySlot
{
    protected override void Awake()
    {
        Identifyer = ItemIdentifier.Skotch;
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        GameSettings.SkotchItem.OnItemUnlocked.AddListener(UpdateButtonLock);
    }

    private void OnDisable()
    {
        GameSettings.SkotchItem.OnItemUnlocked.RemoveListener(UpdateButtonLock);

    }

    protected override bool IsUnlocked()
    {
        return GameSettings.SkotchItem.IsUnlocked;
    }

    public override void ItemClicked()
    {
        if (!GameSettings.SkotchItem.IsUnlocked) return;

        base.ItemClicked();
    }
}
