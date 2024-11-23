using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatapultSlot : BaseInventorySlot
{
    protected override void Start()
    {
        base.Start();
        Identifyer = ItemIdentifier.Catapults;
    }

    public override void ItemClicked()
    {
        if (CatapultItem.IsUnlocked) return;

        base.ItemClicked();
    }

    public override void UpdateDescription(GameObject description)
    {
        if (description == null)
        {
            Debug.LogError("Description GameObject est null !");
            return;
        }

        var textTMP = description.transform.Find("Text")?.GetComponent<TextMeshProUGUI>();
        if (textTMP == null)
        {
            Debug.LogError("TextMeshProUGUI introuvable dans l'objet description.");
            return;
        }

        textTMP.text = CatapultItem.GetDescription();
    }
}
