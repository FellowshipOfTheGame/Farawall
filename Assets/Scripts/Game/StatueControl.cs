using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatueControl : Interactable {

    GameManager GM;
    public StatueData data;
    public Color onColor, offColor;
    public GameObject genericBallon;
    GameObject myBallon = null;
    public float ballonOffset, ballonHeight;
    public Canvas canvas;
    public float camDist, camHeight;
    Transform pivot;

	// Use this for initialization
	void Start () {
        GM = FindObjectOfType<GameManager>() as GameManager;
        this.transform.Find("Model3D").Find("Eye").gameObject.SetActive(false);
        pivot = transform.Find("Pivot");
    }
	
	// Update is called once per frame
	void Update () {

	}

    public override void Interact() {
        GM.mainCam.focusOnObject(this.transform);
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
        GM.mainCam.focusOnObject(GM.player.transform);
        Destroy(myBallon);
        myBallon = null;
    }

    public override void Near() {
        Vector3 dist = (GM.player.transform.position - transform.position).normalized * camDist;
        pivot.position = transform.position + new Vector3(dist.x, camHeight, dist.z);
        float aux = pivot.eulerAngles.x;
        pivot.transform.LookAt(this.transform);
        pivot.eulerAngles = new Vector3 (aux, pivot.eulerAngles.y, pivot.eulerAngles.z);

        this.transform.Find("Model3D").Find("Shine").GetComponent<MeshRenderer>().material.color = onColor;
        this.transform.Find("Model3D").Find("Eye").gameObject.SetActive(true);
    }

    public override void Away() {
        this.transform.Find("Model3D").Find("Shine").GetComponent<MeshRenderer>().material.color = offColor;
        this.transform.Find("Model3D").Find("Eye").gameObject.SetActive(false);
    }
}
