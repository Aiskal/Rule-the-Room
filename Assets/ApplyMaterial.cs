using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ApplyMaterial : MonoBehaviour
{

    [SerializeField] private PhysicsMaterial2D Material;
    [SerializeField] private Collider2D Collider;

    private void Awake()
    {
        Collider = GameSettings.PlayerObject.GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        Collider.sharedMaterial = Material;
        Debug.Log("PlayerBounce added");
    }

    private void OnDisable()
    {
        Collider.sharedMaterial = null;
        Debug.Log("PlayerBounce removed");
    }
}
