using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameUnlocker : Unlocker {

    public override void GiveUpgrade() {
        if (!alreadyGive) {
            GM.player.canPlay = true;
        } else
            myStatue.myBallon.transform.Find("Text").GetComponent<Text>().text = returnMsg;
    }
}
