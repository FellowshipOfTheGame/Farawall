using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour {

    protected GameManager GM;
    public Door door;
    public string returnMsg;
    protected StatueControl myStatue;
    protected bool alreadyGive = false;

    // Use this for initialization
    void Start() {
        GM = GameManager.instance;
        myStatue = this.GetComponent<StatueControl>();
    }

    public virtual void GiveUpgrade() { }
}
