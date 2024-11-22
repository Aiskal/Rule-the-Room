using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeButton : ButtonBehaviour
{
    private GameObject slider;

    void Start()
    {
        slider = transform.parent.Find("SliderSound")?.gameObject;

        if (slider == null)
        {
            Debug.LogError("SliderSound introuvable comme frère de " + gameObject.name);
        }
    }

    public void BS_ToggleSlider()
    {
        if (slider != null)
        {
            slider.SetActive(!slider.activeSelf);
        }
    }
}
