using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponButton : ButtonBehaviour
{
    public static UnityEvent OnDoAction = new();
    public void BS_DoAction()
    {
        OnDoAction?.Invoke();
        //Debug.Log("Action exécutée !");
    }
}
