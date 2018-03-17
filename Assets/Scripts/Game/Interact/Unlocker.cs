using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour {

    public Door door;
    public string returnMsg;
    protected StatueControl myStatue;
    protected bool alreadyGive = false;

    // Use this for initialization
    void Start() {
        myStatue = this.GetComponent<StatueControl>();
    }

    public virtual void GiveUpgrade() { }
}
