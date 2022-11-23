using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Interactable : MonoBehaviour
{
    protected Outline m_outline;
    public bool isUsed;

    protected virtual void Awake()
    {
        
        m_outline = gameObject.AddComponent<Outline>();
        m_outline.enabled = false;
        m_outline.OutlineWidth = 5;
        m_outline.OutlineMode = global::Outline.Mode.OutlineVisible;

    }

    public virtual void OnUse()
    {
        isUsed = true;
        m_outline.enabled = false;
        UiManager.instance.DestroyPanel();
    }

    public Outline m_Outline;

    private void Start()
    {
        if (TryGetComponent(out Outline outline)) 
            m_Outline = outline;
    }

    public virtual void Outline(bool state)
    {
        m_Outline.enabled = state;
    }
    
}
