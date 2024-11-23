
using Unity.VisualScripting;
using UnityEngine;

public class SkotchEffect : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] GameObject skotchSprite;
    WallJumpa wallJump;

    private void Start()
    {
        wallJump = playerMovement.gameObject.AddComponent<WallJumpa>();
        UnequipSkotch();
        EquipSkotch(ItemIdentifier.Skotch);
    }


    private void OnEnable()
    {
        EraserItem.OnItemEquiped.AddListener(EquipSkotch);
        EraserItem.OnItemUnEquip.AddListener(UnequipSkotch);
    }

    private void OnDisable()
    {
        EraserItem.OnItemEquiped.RemoveListener(EquipSkotch);
        EraserItem.OnItemUnEquip.RemoveListener(UnequipSkotch);
    }

    void EquipSkotch(ItemIdentifier item)
    {
        if (item != ItemIdentifier.Skotch) return;

        skotchSprite.SetActive(true);
        wallJump.enabled = true;
    }

    void UnequipSkotch(ItemIdentifier item)
    {
        if (item != ItemIdentifier.Skotch) return;

        skotchSprite.SetActive(false);
        wallJump.enabled = false;
    }
}
