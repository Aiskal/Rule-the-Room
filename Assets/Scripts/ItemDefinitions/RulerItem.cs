using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class RulerItem : MonoBehaviour, IItemBase
{
    [SerializeField] RulerObject ruler;
    [SerializeField] Transform spawnPoint;

    SpriteRenderer spriteRenderer;
    bool usingItem = false;

    

    public ItemIdentifier Identity { get; set; } = ItemIdentifier.Ruler;
    public bool IsUnlocked { get; set; }
    public UnityEvent<ItemIdentifier> OnItemUnlocked { get; set; } = new();
    public UnityEvent<ItemIdentifier> OnItemEquiped { get; set; } = new();
    public UnityEvent<ItemIdentifier> OnItemUnEquip { get; set; } = new();


    private void Awake()
    {
        //OnItemUnlocked = new();
        //OnItemEquiped = new();
        //OnItemUnEquip = new();

        spriteRenderer = GetComponent<SpriteRenderer>();
        UnequipItem();
    }
    private void OnEnable()
    {
        EquipItem();
        WeaponButton.OnDoAction.AddListener(UseItem);
        ruler.OnFinish.AddListener(OnUsingFinish);
    }

    private void OnDisable()
    {
        WeaponButton.OnDoAction.RemoveListener(UseItem);
        ruler.OnFinish.RemoveAllListeners();
        OnUsingFinish();
    }
    public string GetDescription()
    {
        return "Cette r�gle en plastique transparent, avec des chiffres l�g�rement effac�s, est un guide pr�cieux pour maintenir les choses droites et align�es." +
            " Dans l�esprit de l�enfant, elle devient une passerelle entre l�ordre et le chaos, un outil pour construire quelque chose de solide malgr� l�incertitude." +
            " Peut-�tre, avec un peu de magie, elle pourrait servir � b�tir un chemin pour le retour de son h�ros";
    }

    public void EquipItem()
    {
        Debug.Log("Equip Ruler");
        gameObject.SetActive(true);


    }

    public void UnequipItem()
    {
        Debug.Log("Unquip Ruler");
        gameObject.SetActive(false);

    }

    public void UseItem()
    {
        if (usingItem) return;

        Debug.Log("Use Ruler");
        usingItem = true;
        ruler.transform.position = spawnPoint.position;
        ruler.gameObject.SetActive(true);
        spriteRenderer.enabled = false;

    }

    void OnUsingFinish()
    {
        usingItem = false;
        spriteRenderer.enabled = true;
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
    
