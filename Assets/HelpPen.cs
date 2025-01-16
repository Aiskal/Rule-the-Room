using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPen : MonoBehaviour
{
    [SerializeField] SpriteRenderer baseSprite, frameSprite, arrowSprite;
    CircleCollider2D collider;

    Color invisible = new(1, 1, 1, 0);
    Color visible = new(1, 1, 1, 0.8f);

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        collider.enabled = false;
        frameSprite.color = invisible;
        arrowSprite.color = invisible;

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Reveal());
    }

    private void OnEnable()
    {
        GameSettings.PencilItem.OnItemEquiped.AddListener(Activate);
        GameSettings.PencilItem.OnItemUnEquip.AddListener(Deactivate);
    }

    private void OnDisable()
    {
        GameSettings.PencilItem?.OnItemEquiped.RemoveListener(Activate);
        GameSettings.PencilItem?.OnItemUnEquip.RemoveListener(Deactivate);
    }

    void Activate(ItemIdentifier _)
    {
        collider.enabled = true;
    }

    void Deactivate(ItemIdentifier _)
    {
        if(collider != null)
        collider.enabled = false;
    }

    IEnumerator Reveal()
    {

        float elapsedtime = 0, time = 1.5f;
        var c = baseSprite.color;
        while(elapsedtime < time)
        {
            elapsedtime += Time.deltaTime;
            var progress = elapsedtime / time;
            baseSprite.color = Color.Lerp(c, invisible, progress);
            frameSprite.color = Color.Lerp(invisible, visible, progress);
            arrowSprite.color = Color.Lerp(invisible, visible, progress);
            yield return null;
        }
        this.enabled = false;
        collider.enabled = false;
    }

}
