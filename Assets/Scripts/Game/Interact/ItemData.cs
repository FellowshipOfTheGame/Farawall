using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Item Data")]
public class ItemData : ScriptableObject {

    public string title;
    public int type;
    public Sprite image;
    public GameObject art3d;
}
