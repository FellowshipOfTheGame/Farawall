using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateUnlocker : Interactable {

    GameManager GM;

    // Use this for initialization
    void Start() {
        GM = FindObjectOfType<GameManager>() as GameManager;
        this.transform.Find("Eye").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (nearPlayer) {
            this.transform.Find("Eye").Rotate(0.0f, 10.0f * Time.deltaTime, 0.0f);
        }
    }

    public override void Interact() {
        Camera.main.GetComponent<CameraControl>().currStatue = this.transform;
        Camera.main.GetComponent<CameraControl>().state = "statue";
        Debug.Log("Now you can understand the statues...");
        GM.player.canTranslate = true;
    }

    public override void Close() {
        Camera.main.GetComponent<CameraControl>().state = "player";
        Camera.main.GetComponent<CameraControl>().currStatue = null;
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            this.transform.Find("Eye").gameObject.SetActive(true);
            nearPlayer = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            this.transform.Find("Eye").gameObject.SetActive(false);
            nearPlayer = false;
        }
    }
}
