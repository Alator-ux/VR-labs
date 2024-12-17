using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Key : XRGrabInteractable
{
    [SerializeField]
    string id;
    public string Id { get => id; }

    public Action<Key> OnKeyUsed;

    public bool CanOpenSameDoorAs(Key key)
    {
        return key != null && id == key.Id;
    }

    
}
