using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSlot : BaseInventorySlot
{
    protected override void Awake()
    {
        Identifyer = ItemIdentifier.Plane;
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        GameSettings.PlaneItem.OnItemUnlocked.AddListener(UpdateButtonLock);
    }

    private void OnDisable()
    {
        GameSettings.PlaneItem.OnItemUnlocked.RemoveListener(UpdateButtonLock);

    }
    protected override bool IsUnlocked()
    {
        return GameSettings.PlaneItem.IsUnlocked;
    }

    public override void ItemClicked()
    {
        if (!GameSettings.PlaneItem.IsUnlocked) return;

        base.ItemClicked();
    }
}
