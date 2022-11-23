using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Testing : MonoBehaviour
{
    GameEvents gameEvents;

    private void Awake()
    {
        if (TryGetComponent(out GameEvents events))
            gameEvents = events;
    }



}
