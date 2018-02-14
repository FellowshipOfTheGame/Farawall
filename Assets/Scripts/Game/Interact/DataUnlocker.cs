using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataUnlocker : Unlocker {
    public GameObject dataButton;

    public override void GiveUpgrade() {
        if (!alreadyGive) {
            dataButton.SetActive(true);
            Key k = this.GetComponent<DropItem>().Drop().GetComponent<Key>();
            k.door = door;
            alreadyGive = true;
        } else
            myStatue.myBallon.transform.Find("Text").GetComponent<Text>().text = returnMsg;
    }
}
