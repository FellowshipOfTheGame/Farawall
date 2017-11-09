using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameEnter : Interactable {

    void Start() {
        this.transform.Find("Eye").GetComponent<SpriteRenderer>().color = Color.black;
    }

    public override void Interact() {
        Camera.main.GetComponent<CameraControl>().currStatue = this.transform;
        Camera.main.GetComponent<CameraControl>().state = "statue";
        Debug.Log("Just a big eye in the wall!");
    }

    public override void Close() {
        Camera.main.GetComponent<CameraControl>().state = "player";
        Camera.main.GetComponent<CameraControl>().currStatue = null;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            this.transform.Find("Eye").GetComponent<SpriteRenderer>().color = Color.white;
            nearPlayer = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            this.transform.Find("Eye").GetComponent<SpriteRenderer>().color = Color.black;
            nearPlayer = false;
        }
    }
}
