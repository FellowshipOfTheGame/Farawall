using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable {
	public Door door;

    void Update() {
        this.transform.Find("Sprite").Rotate(0.0f, 30.0f * Time.deltaTime, 0.0f);
        if (nearPlayer)
            this.transform.Find("Sprite").Find("Eye").gameObject.SetActive(true);
        else
            this.transform.Find("Sprite").Find("Eye").gameObject.SetActive(false);
    }

	public override void Interact (){
        Camera.main.GetComponent<CameraControl>().currStatue = this.transform;
        Camera.main.GetComponent<CameraControl>().state = "statue";
        door.Unlock();
	}

	public override void Close(){
        Camera.main.GetComponent<CameraControl>().state = "player";
        Camera.main.GetComponent<CameraControl>().currStatue = null;
        Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider other){
        if (other.tag == "Player") 
            nearPlayer = true;
            
	}

	void OnTriggerExit(Collider other){
        if (other.tag == "Player")
            nearPlayer = false;
	}
}
