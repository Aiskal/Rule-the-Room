using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Nécessaire pour manipuler Slider et UI

public class VolumeSliderBehaviour : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;

    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

        if (slider == null)
        {
            Debug.LogError("Aucun composant Slider trouvé sur " + gameObject.name);
            return;
        }

        slider.onValueChanged.AddListener(BS_UpdateMusicVolume);

        if (musicSource != null)
        {
            musicSource.volume = slider.value;
        }
        else
        {
            Debug.LogError("Aucune source audio assignée pour " + gameObject.name);
        }
    }

    private void BS_UpdateMusicVolume(float value)
    {
        if (musicSource != null)
        {
            musicSource.volume = value;
        }
    }
}
