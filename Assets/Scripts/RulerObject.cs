using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RulerObject : MonoBehaviour
{
    public int RotaDirection = 1;
    public float baseRotation = RulerItem.SpawnRotation;
    public float lifetime = RulerItem.TimeAlive;
    private Rigidbody2D rulerRb;
    private BoxCollider2D rulerCollider;

    bool firstCollision = true;
    [SerializeField] PhysicsMaterial2D bounceMaterial;

    void Start()
    {
        rulerRb = GetComponent<Rigidbody2D>();
        rulerCollider = GetComponent<BoxCollider2D>();
        //definir position par rapport au transform du joueur
    }

    private void OnEnable()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, baseRotation * RotaDirection);
        if(rulerRb == null)
        {
            rulerRb = GetComponent<Rigidbody2D>();
        }
        rulerRb.isKinematic = false;
    }


    void Update()
    {
        if (rulerRb.velocity.magnitude < 0.01f)
        {
            StartCoroutine(DeleteRuler());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (firstCollision)
        {
            firstCollision = false;
            rulerCollider.sharedMaterial = bounceMaterial;
            Debug.Log("boing");
        }
    }

    IEnumerator DeleteRuler()
    {
        
        yield return new WaitForSeconds(lifetime);

        // Désactiver le Rigidbody2D pour qu'il cesse d'interagir avec la physique
        if (rulerRb != null)
        {
            rulerRb.isKinematic = true;
        }
        
        // Après un certain temps de vie, désactiver l'objet
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        rulerRb.isKinematic = false;
        
    }
}
