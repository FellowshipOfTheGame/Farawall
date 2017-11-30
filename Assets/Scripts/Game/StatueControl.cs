using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatueControl : Interactable {

    GameManager GM;
    public StatueData data;
    public Color onColor, offColor;
    Transform playerPivot;
    public GameObject genericBallon;
    GameObject myBallon = null;
    public float ballonOffset, ballonHeight;
    public Canvas canvas;

	// Use this for initialization
	void Start () {
        GM = FindObjectOfType<GameManager>() as GameManager;
        this.transform.Find("Eye").gameObject.SetActive(false);
        playerPivot = FindObjectOfType<PlayerControl>().transform.Find("Pivot");
    }
	
	// Update is called once per frame
	void Update () {
		if (nearPlayer) {
            this.transform.Find("Eye").eulerAngles = playerPivot.Find("PlayerModel").eulerAngles;
        }
	}

    public override void Interact() {
        Camera.main.GetComponent<CameraControl>().currStatue = this.transform;
        Camera.main.GetComponent<CameraControl>().state = "statue";
        myBallon = Instantiate(genericBallon, canvas.transform);
        if (GM.player.canTranslate) {
            myBallon.transform.Find("Text").GetComponent<Text>().text = data.normalMessage;
            myBallon.transform.Find("Text").GetComponent<Text>().font = data.normalFont;
        }else {
            myBallon.transform.Find("Text").GetComponent<Text>().text = data.emojiMessage;
            myBallon.transform.Find("Text").GetComponent<Text>().font = data.emojiFont;
        }
    }

    public override void Close() {
        Camera.main.GetComponent<CameraControl>().state = "player";
        Camera.main.GetComponent<CameraControl>().currStatue = null;
        Destroy(myBallon);
        myBallon = null;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            this.transform.Find("Shine").GetComponent<MeshRenderer>().material.color = onColor;
            this.transform.Find("Eye").gameObject.SetActive(true);
            nearPlayer = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            this.transform.Find("Shine").GetComponent<MeshRenderer>().material.color = offColor;
            this.transform.Find("Eye").gameObject.SetActive(false);
            nearPlayer = false;
        }
    }
}
