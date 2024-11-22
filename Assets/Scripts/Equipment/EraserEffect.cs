
using UnityEngine;

public class EraserEffect : MonoBehaviour
{
    [SerializeField] private ApplyMaterial eraserEffect;
    [SerializeField] GameObject eraserSprite;

    private void Start()
    {
        UnequipEraser();
    }


    private void OnEnable()
    {
        EraserItem.OnItemEquiped.AddListener(EquipEraser);
        EraserItem.OnItemUnEquip.AddListener(UnequipEraser);
    }

    private void OnDisable()
    {
        EraserItem.OnItemEquiped.RemoveListener(EquipEraser);
        EraserItem.OnItemUnEquip.RemoveListener(UnequipEraser);
    }

    void EquipEraser()
    {
        eraserEffect.enabled = true;
        eraserSprite.SetActive(true);
    }

    void UnequipEraser()
    {
        eraserEffect.enabled = false;
        eraserSprite.SetActive(false);
    }
}
