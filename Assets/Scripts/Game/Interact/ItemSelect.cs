﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour {

    public Dropdown drop;
    [HideInInspector] public ItemPlace place;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void refresh() {
        place.changeAnswer(drop);
    }
}