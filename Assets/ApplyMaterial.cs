using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ApplyMaterial : MonoBehaviour
{

    [SerializeField] private PhysicsMaterial2D Material;
    [SerializeField] private Collider2D Collider;

    private void OnEnable()
    {
        Collider.sharedMaterial = Material;
    }

    private void OnDisable()
    {
        Collider.sharedMaterial = null;
    }
}
