using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    protected bool nearPlayer;
    public bool isItem;
    public virtual void Interact() { }
    public virtual void Close() { }
    public virtual void Near() { }
    public virtual void Away() { }

}