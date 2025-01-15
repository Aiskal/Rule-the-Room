using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserSlot : BaseInventorySlot
{
    protected override void Awake()
    {
        Identifyer = ItemIdentifier.Eraser;
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        GameSettings.EraserItem.OnItemUnlocked.AddListener(UpdateButtonLock);
    }

    private void OnDisable()
    {
        GameSettings.EraserItem.OnItemUnlocked.RemoveListener(UpdateButtonLock);

    }

    public override void ItemClicked()
    {
        if (!GameSettings.EraserItem.IsUnlocked) return;

        base.ItemClicked();
    }

    protected override bool IsUnlocked()
    {
        return GameSettings.EraserItem.IsUnlocked;
    }
}
