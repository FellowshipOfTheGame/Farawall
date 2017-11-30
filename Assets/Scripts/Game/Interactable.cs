using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    protected bool nearPlayer;
    public virtual void Interact() { }
    public virtual void Close() { }
    
}