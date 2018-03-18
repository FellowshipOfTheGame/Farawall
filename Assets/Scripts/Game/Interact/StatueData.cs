using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Statue Data", menuName = "Statue Data")]
public class StatueData : ScriptableObject {

    new public string name;
    public string normalMessage;
    public string emojiMessage;
}
