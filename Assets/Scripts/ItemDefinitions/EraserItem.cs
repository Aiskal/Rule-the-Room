using UnityEngine;
using UnityEngine.Events;

public class EraserItem : MonoBehaviour, IItemBase
{
    [SerializeField] private ApplyMaterial eraserEffect;


    public ItemIdentifier Identity { get ; set ; } = ItemIdentifier.Eraser;
    public bool IsUnlocked { get ; set; }
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
        Debug.Log("Equip Eraser");
        eraserEffect.enabled = true;
        gameObject.SetActive(true);

    }

    public string GetDescription()
    {
        return "Une gomme blanche, marqu�e par des petites t�ches et us�e � ses coins, t�moigne des erreurs corrig�es avec soin. Pour l�enfant, elle est plus qu�un simple outil : " +
                "elle symbolise la possibilit� de tout recommencer, d�effacer les mauvais souvenirs et de redessiner une r�alit� meilleure.";
    }

    public void UnequipItem()
    {
        Debug.Log("Unquip Eraser");

        eraserEffect.enabled = false;
        gameObject.SetActive(false);
    }

    public void UseItem()
    {
        Debug.Log("Use Eraser");
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
    
