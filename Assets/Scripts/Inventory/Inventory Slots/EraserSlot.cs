using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserSlot : BaseInventorySlot
{
    protected override void Start()
    {
        base.Start();
        Identifyer = ItemIdentifier.Eraser;
    }

    public override void ItemClicked()
    {
        if (!EraserItem.IsUnlocked) return;

        base.ItemClicked();
    }
}
