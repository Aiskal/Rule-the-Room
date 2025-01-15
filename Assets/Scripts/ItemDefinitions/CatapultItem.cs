using UnityEngine.Events;
using UnityEngine;

public class CatapultItem : MonoBehaviour, IItemBase
{

    public ItemIdentifier Identity { get; set; } = ItemIdentifier.Catapults;
    public bool IsUnlocked { get; set; }
    public UnityEvent<ItemIdentifier> OnItemUnlocked { get; set; } = new();
    public UnityEvent<ItemIdentifier> OnItemEquiped { get; set; } = new();
    public UnityEvent<ItemIdentifier> OnItemUnEquip { get; set; } = new();


    private void Awake()
    {
        //OnItemUnlocked = new();
        //OnItemEquiped = new();
        //OnItemUnEquip = new();

        UnequipItem();
    }

    private void OnEnable()
    {
        EquipItem();
        WeaponButton.OnDoAction.AddListener(UseItem);
    }

    private void OnDisable()
    {
        WeaponButton.OnDoAction.RemoveListener(UseItem);
    }

    public void EquipItem()
    {
        Debug.Log("Equip Catapult");
        gameObject.SetActive(true);


    }

    public string GetDescription()
    {
        return "Une catapulte bricolée où la gomme sert de base et la règle comme levier." +
            " Conçue pour propulser le petit soldat lui-même, elle lui permet d’atteindre des endroits inaccessibles.";
    }

    public void UnequipItem()
    {
        Debug.Log("Unquip Catapult");
        gameObject.SetActive(false);

    }

    public void UseItem()
    {
        Debug.Log("Use Catapult");
    }

    public void Unlock()
    {
        if (IsUnlocked)
        {
            return;
        }

        IsUnlocked = true;
        OnItemUnlocked.Invoke(Identity);
    }
}
