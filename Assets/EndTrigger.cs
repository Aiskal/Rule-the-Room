using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] GameObject Ui;
    [SerializeField] SpriteRenderer endScreen;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(EndScreen());
    }

    IEnumerator EndScreen()
    {
        GameSettings.PlayerObject.GetComponent<PlayerMovement>().StopMove();
        Ui.SetActive(false);
        endScreen.enabled = true;

        float elapsed = 0, time = 3;
        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            var progress = (elapsed / time);
            Color invisible = new(1, 1, 1, 0);
            Color visible = new(1, 1, 1, 1);
            endScreen.color = Color.Lerp(invisible, visible, progress);
            yield return null;
        }
    }
}
