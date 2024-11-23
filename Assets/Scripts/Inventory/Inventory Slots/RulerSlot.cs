using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerSlot : BaseInventorySlot
{
    protected override void Start()
    {
        base.Start();
        Identifyer = ItemIdentifier.Ruler;
    }

    public override void ItemClicked()
    {
        if (!RulerItem.IsUnlocked) return;

        base.ItemClicked();
    }
}
