using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSlot : BaseInventorySlot
{
    protected override void Start()
    {
        base.Start();
        Identifyer = ItemIdentifier.Plane;
    }
    protected override bool IsUnlocked()
    {
        return PlaneItem.IsUnlocked;
    }

    public override void ItemClicked()
    {
        if (!PlaneItem.IsUnlocked) return;

        base.ItemClicked();
    }
}
