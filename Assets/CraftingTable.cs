using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTable : MonoBehaviour
{
    [SerializeField] List<BaseInventorySlot> slots;
    [SerializeField] Image baseImage;
    [SerializeField] Image DeclineImage;
    [SerializeField] Image ValidImage;
    [SerializeField] Image CraftImage;
    [SerializeField] Button CraftButton;
    [SerializeField] TextMeshProUGUI Description;
    List<ItemIdentifier> craftingContent;

    ItemIdentifier validResult;

    enum CraftState { Default, Valid, Invalid }

    private void OnEnable()
    {
        slots.ForEach(s => s.ItemSelected.AddListener(ToggleCraftItem));
        validResult = ItemIdentifier.None;
        craftingContent = new();
        CraftButton.interactable = false;
        TryRecipe();

    }

    private void OnDisable()
    {
        slots.ForEach(s => { s.Unselect(); s.ItemSelected.RemoveAllListeners(); });
    }

    private void SetState(CraftState _state)
    {
        baseImage.gameObject.SetActive(false);
        DeclineImage.gameObject.SetActive(false);
        ValidImage.gameObject.SetActive(false);
        CraftButton.interactable = false;
        Description.text = "";
        switch (_state)
        {
            case CraftState.Default: 
                baseImage.gameObject.SetActive(true); break;

            case CraftState.Invalid: 
                DeclineImage.gameObject.SetActive(true); break;

            case CraftState.Valid: 
                ValidImage.gameObject.SetActive(true); 
                CraftButton.interactable = true; break;
        }
    }

    void ToggleCraftItem(ItemIdentifier item)
    {
        if (craftingContent.Exists(i => i == item))
        {
            craftingContent.Remove(item);
        }
        else
        {
            craftingContent.Add(item);
        }

        TryRecipe();
    }

    void TryRecipe()
    {
        if(craftingContent.Count == 0)
        {
            SetState(CraftState.Default);
            return;
        }
        ItemIdentifier result = Recipes.TryRecipe(craftingContent);
        switch (result)
        {
            case ItemIdentifier.None: InvalidRecipe(); break;
            default: 
                ValidRecipe(result); break;
        }
    }

    void InvalidRecipe()
    {
        SetState(CraftState.Invalid);
    }

    void ValidRecipe(ItemIdentifier result)
    {
        SetState(CraftState.Valid);
        CraftImage.sprite = GameSettings.GetSprite(result);
        Description.text = GameSettings.GetItemDescription(result);
        validResult = result;
    }

    public void OnChoiceConfirmed()
    {
        switch (validResult)
        {
            case ItemIdentifier.Pencil: GameSettings.PencilItem.OnItemEquiped.Invoke(validResult); break;
            case ItemIdentifier.Eraser: GameSettings.EraserItem.OnItemEquiped.Invoke(validResult); break;
            case ItemIdentifier.Skotch: GameSettings.SkotchItem.OnItemEquiped.Invoke(validResult); break;
            case ItemIdentifier.Hammer: GameSettings.HammerItem.OnItemEquiped.Invoke(validResult); break;
            case ItemIdentifier.Plane: GameSettings.PlaneItem.OnItemEquiped.Invoke(validResult); break;
            case ItemIdentifier.Ruler: GameSettings.RulerItem.OnItemEquiped.Invoke(validResult); break;
            case ItemIdentifier.Catapults: GameSettings.CatapultItem.OnItemEquiped.Invoke(validResult); break;
        }
    }

}
