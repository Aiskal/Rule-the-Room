using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEffect : MonoBehaviour
{
    [SerializeField] GameObject planeSprite;
    [SerializeField] GameObject PreFabPlane;
    [SerializeField] PlayerMovement player;
    Coroutine planeCoroutine;

    GameObject planeObject;
    

    private void Start()
    {
        UnEquipPlane(ItemIdentifier.Plane);
        planeObject = Instantiate(PreFabPlane);
        planeObject.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        PlaneItem.OnItemEquiped.AddListener(EquipPlane);
        PlaneItem.OnItemUnEquip.AddListener(UnEquipPlane);
        WeaponButton.OnDoAction += spawnPlane;
    }
    private void OnDisable()
    {
        PlaneItem.OnItemEquiped.RemoveListener(EquipPlane);
        PlaneItem.OnItemUnEquip.RemoveListener(UnEquipPlane);
        WeaponButton.OnDoAction -= spawnPlane;
    }

    void EquipPlane(ItemIdentifier item)
    {
        if (item != ItemIdentifier.Plane) return;

        planeSprite.SetActive(true);
    }

    void UnEquipPlane(ItemIdentifier item)
    {
        if (item != ItemIdentifier.Plane) return;

        planeSprite.SetActive(false);
    }

    void spawnPlane()
    {
        if (planeCoroutine == null)
        {
            planeCoroutine = StartCoroutine(PlaneSpawnProcedure());

        }

    }

    IEnumerator PlaneSpawnProcedure()
    {
        UnEquipPlane(ItemIdentifier.Plane);
        int playerDirection = player.PlayerDirection;
        Vector3 playerposition = player.transform.position;

        int distance = 2;
        int height = 2;

        Vector3 spawnPosition = new Vector3(playerDirection * distance, height, 0);

        if (PreFabPlane != null)
        {
            planeObject.gameObject.SetActive(true);
            planeObject.transform.position = spawnPosition;
        }

        yield return new WaitForSeconds(7);

        EquipPlane(ItemIdentifier.Plane);


        planeCoroutine = null;

    }
}
