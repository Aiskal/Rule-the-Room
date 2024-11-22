using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaneObject : MonoBehaviour
{

    [SerializeField] private float speed, fadeSpeed;


    
    private Transform m_transform;
    private Material m_material;
    private int layerToIgnore = 3;


    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
        m_material = GetComponent<Renderer>().material;
        int layerObject = gameObject.layer;
        Physics.IgnoreLayerCollision(layerObject, layerToIgnore, true);
    }

    void FixedUpdate()
    {

        m_transform.position += new Vector3(1 * speed * Time.fixedDeltaTime, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        StartCoroutine(DestroyCoroutine());
    }

    IEnumerator DestroyCoroutine()
    {
        int i = 0;
        i++;
        if (m_material != null)
        {
           
            Color currentColor = m_material.color;

           
            while (currentColor.a > 0)
            {
                
                currentColor.a -= fadeSpeed * Time.deltaTime;

                
                currentColor.a = Mathf.Max(currentColor.a, 0);

                
                m_material.color = currentColor;

                
                yield return null;
            }
        }
      
        Destroy(gameObject);     
        
    }
}
