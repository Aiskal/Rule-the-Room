using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTable : MonoBehaviour
{
    [SerializeField] List<BaseInventorySlot> slots;
    [SerializeField] Image baseImage;
    [SerializeField] Button CraftButton;
    List<ItemIdentifier> craftingContent;

    ItemIdentifier validResult;

    private void OnEnable()
    {
        slots.ForEach(s => s.ItemSelected.AddListener(ToggleCraftItem));
        validResult = ItemIdentifier.None;
        craftingContent = new();
        CraftButton.interactable = false;
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
        ItemIdentifier result = Recipes.TryRecipe(craftingContent);
        switch (result)
        {
            case ItemIdentifier.None: InvalidRecipe(); break;
            default: ValidRecipe(result); break;
        }
    }

    void InvalidRecipe()
    {
        baseImage.color = Color.red;
        CraftButton.interactable = false;
    }

    void ValidRecipe(ItemIdentifier result)
    {
        validResult = result;
        baseImage.color = Color.green;
        CraftButton.interactable = true;
    }

    public void OnChoiceConfirmed()
    {
        switch (validResult)
        {
            case ItemIdentifier.Pencil: PencilItem.OnItemEquiped.Invoke(); break;
            case ItemIdentifier.Eraser: EraserItem.OnItemEquiped.Invoke(); break;
            case ItemIdentifier.Skotch: SkotchItem.OnItemEquiped.Invoke(); break;
            case ItemIdentifier.Hammer: HammerItem.OnItemEquiped.Invoke(); break;
            case ItemIdentifier.Plane: PlaneItem.OnItemEquiped.Invoke(); break;
            case ItemIdentifier.Ruler: RulerItem.OnItemEquiped.Invoke(); break;
            case ItemIdentifier.Catapults: CatapultItem.OnItemEquiped.Invoke(); break;
        }
    }

}
