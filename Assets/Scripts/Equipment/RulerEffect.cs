using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RulerEffect : MonoBehaviour
{
    [SerializeField] GameObject rulerSprite;
    [SerializeField] GameObject PreFabRuler;
    [SerializeField] PlayerMovement player;
    Coroutine rulerCoroutine;

    GameObject rulerObject;

    private void Start()
    {
        UnEquipRuler(ItemIdentifier.Ruler);
        rulerObject = Instantiate(PreFabRuler);
        rulerObject.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        RulerItem.OnItemEquiped.AddListener(EquipRuler);
        RulerItem.OnItemUnEquip.AddListener(UnEquipRuler);
        WeaponButton.OnDoAction += spawnRuler;
    }
    private void OnDisable()
    {
        RulerItem.OnItemEquiped.RemoveListener(EquipRuler);
        RulerItem.OnItemUnEquip.RemoveListener(UnEquipRuler);
    }

    void EquipRuler(ItemIdentifier item)
    {
        if (item != ItemIdentifier.Ruler) return;
        rulerSprite.SetActive(true);
    }

    void UnEquipRuler(ItemIdentifier item)
    {
        if (item != ItemIdentifier.Ruler) return;
        rulerSprite.SetActive(false);
    }

    void spawnRuler()
    {
        if (rulerCoroutine == null)
        {
            rulerCoroutine = StartCoroutine(RulerSpawnProcedure());

        }

    }

    IEnumerator RulerSpawnProcedure()
    {
        UnEquipRuler(ItemIdentifier.Ruler);
        int playerDirection = player.PlayerDirection;
        Vector3 playerposition = player.transform.position;

        int distance = 4;
        int height = 5;

        Vector3 spawnPosition = new Vector3(playerDirection * distance, height, 0);

        if (PreFabRuler != null)
        {
            rulerObject.gameObject.SetActive(true);
            rulerObject.transform.position = spawnPosition;
        }

        yield return new WaitForSeconds(7);
        
        EquipRuler(ItemIdentifier.Ruler);

        
        rulerCoroutine = null;
        
    }
}
