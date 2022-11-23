using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    
    [SerializeField] Transform interactPoint;

    public new void Awake()
    {
        base.Awake();
    }

    
    public override void Outline(bool state)
    {
        if (!isUsed)
        {
            base.Outline(state);
            UiManager.instance.CreateInteractPanel(interactPoint, state);
        }
    }

    public override void OnUse()
    {
        base.OnUse();
        LeanTween.rotateLocal(gameObject, new Vector3(0, 130, 0), 1f);
    }
}
