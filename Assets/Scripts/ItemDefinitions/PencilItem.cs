using UnityEngine;
using UnityEngine.Events;

public class PencilItem : MonoBehaviour, IItemBase
{
    public ItemIdentifier Identity { get; set; } = ItemIdentifier.Pencil;
    public bool IsUnlocked { get; set; }
    public UnityEvent<ItemIdentifier> OnItemUnlocked { get; set; } = new();
    public UnityEvent<ItemIdentifier> OnItemEquiped { get; set; } = new();
    public UnityEvent<ItemIdentifier> OnItemUnEquip { get; set; } = new();

    private void Awake()
    {
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
    public string GetDescription()
    {
        return "Ce crayon rouge vif a été taillé de manière maladroite, preuve des nombreuses aventures qu’il a déjà traversées dans les petites mains d’un artiste en herbe." +
            " Il représente l’imagination sans limite de l’enfant, une arme contre l’ennui et la solitude. Entre les lignes qu’il trace," +
            " il esquisse des mondes où tout est encore possible, même le retour d’un papa parti trop loin.";
    }

    public void EquipItem()
    {
        Debug.Log("Equip Pencil");
        gameObject.SetActive(true);
        //OnItemEquiped.Invoke(Identity);
        GameSettings.ActiveItem = this;

    }

    public void UnequipItem()
    {
        Debug.Log("Unequip Pencil");
        gameObject.SetActive(false);
        OnItemUnEquip.Invoke(Identity);
    }

    public void UseItem()
    {
        Debug.Log("Use Pencil");
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
    
