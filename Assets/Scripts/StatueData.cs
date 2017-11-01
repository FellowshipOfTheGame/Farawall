﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Statue Data", menuName = "Statue Data")]
public class StatueData : ScriptableObject {

    public string title;
    public string normalMessage;
    public string emojiMessage;
    public Font normalFont;
    public Font emojiFont;
}
