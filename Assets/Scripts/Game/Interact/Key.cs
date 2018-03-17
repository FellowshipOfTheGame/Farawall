using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : Interactable {
	public Door door;
    Transform keyModel;
    public TextMesh codePlace;
    void Start() {
        keyModel = transform.Find("3dModel");
        codePlace.text = "K-" + door.code.ToString();
        codePlace.gameObject.SetActive(false);
    }

    void Update() {
        keyModel.Rotate(Vector3.up, 30.0f * Time.deltaTime);
        if (nearPlayer)
			codePlace.transform.forward = GameManager.player.transform.forward;
    }

	public override void Interact (){
		GameManager.player.addKey(door.code);
        Debug.Log("Got key " + door.code);
		GameObject temp = Instantiate(GameManager.menu.keyFloor.Find("Keys2").GetChild(0).gameObject, GameManager.menu.keyFloor.Find("Keys2"));
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
