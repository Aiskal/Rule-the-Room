using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaneObject : MonoBehaviour
{
    public int RotaDirection;
    //public float baseRotation;
    private float speed;
    private float fadeSpeed;
    //Coroutine planeCoroutine=StartCoroutine(DestroyCoroutine());  
    private Rigidbody2D planeRb;
    private Transform m_transform;
    private Material m_material;
    


    // Start is called before the first frame update
    void Start()
    {
        planeRb = GetComponent<Rigidbody2D>();
        m_transform = GetComponent<Transform>();
        m_material = GetComponent<Renderer>().material;

        RotaDirection = -1;
        //baseRotation = PlaneItem.SpawnRotation;
        speed = PlaneItem.FlightSpeed;
        fadeSpeed = PlaneItem.FadeTime;

}

    void FixedUpdate()
    {
        m_transform.position += new Vector3(1 * speed * Time.fixedDeltaTime, 0, 0);
    }
    private void OnEnable()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, RotaDirection);
        if (planeRb == null)
        {
            planeRb = GetComponent<Rigidbody2D>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
        
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
