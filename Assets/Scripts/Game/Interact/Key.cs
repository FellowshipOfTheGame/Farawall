﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : Interactable {
    GameManager gm;
	public Door door;
    Transform keyModel;
    public TextMesh codePlace;
    Transform keyList;
    GameObject genInfo;
    void Start() {
        gm = FindObjectOfType<GameManager>();
        keyModel = transform.Find("3dModel");
        codePlace.text = "K-" + door.code.ToString();
        codePlace.gameObject.SetActive(false);
        keyList = gm.keyFloor.Find("Keys2");
        genInfo = keyList.GetChild(0).gameObject;
    }

    void Update() {
        keyModel.Rotate(Vector3.up, 30.0f * Time.deltaTime);
        if (nearPlayer)
            codePlace.transform.forward = gm.player.transform.forward;
    }

	public override void Interact (){
        gm.player.addKey(door.code);
        Debug.Log("Got key " + door.code);
        GameObject temp = Instantiate(genInfo, keyList);
        temp.name = door.code.ToString();
        temp.transform.GetChild(0).GetComponent<Text>().text = "K-" + door.code.ToString();
        temp.SetActive(true);
        Close();
	}

	public override void Close(){
        Destroy(this.gameObject);
    }

    public override void Near() {
        codePlace.gameObject.SetActive(true);
        nearPlayer = true;      
	}

	public override void Away(){
        codePlace.gameObject.SetActive(false);
        nearPlayer = false;
	}
}