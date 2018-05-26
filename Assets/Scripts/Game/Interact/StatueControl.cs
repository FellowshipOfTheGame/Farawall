using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatueControl : Interactable {

    public StatueData data;
    public Color onColor, offColor;
    public GameObject genericBallon;
    public Font normalFont, emojiFont;
    public bool locked;
    [Space(10)]
    
    public float ballonOffset, ballonHeight;
    public float camDist, camHeight;
    public GameObject message;
    [Space(10)]
    public GameObject myBallon = null;
    Transform pivot;

    //Aux vars
    Informer inf;
    Asker ask;
    Solutioner sol;
    Unlocker ul;
    Inquisitor inq;
	// Use this for initialization
	void Start () {
        this.transform.Find("Model3D").Find("Eye").gameObject.SetActive(false);
        pivot = transform.Find("Pivot");
        inf = this.GetComponent<Informer>();
        ask = this.GetComponent<Asker>();
        sol = this.GetComponent<Solutioner>();
        ul = this.GetComponent<Unlocker>();
        inq = this.GetComponent<Inquisitor>();
        if (sol != null)
            message.transform.Find("Text").GetComponent<TextMesh>().text = sol.answer;

        this.name = data.name;
        message.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if(nearPlayer && sol!= null && sol.places.Length > 0) {
            if (Input.GetKeyDown(KeyCode.RightArrow)) ItemPlace.selected.turnOff(1, false);

            if (Input.GetKeyDown(KeyCode.LeftArrow)) ItemPlace.selected.turnOff(-1, false);
        }
	}

    public override void Interact() {
        if (!locked) {
            message.SetActive(false);
			GameManager.mainCam.focusOnObject(this.transform);
			myBallon = Instantiate(genericBallon, GameManager.mainCam.canvas.transform);
			if (GameManager.player.canTranslate) {
                myBallon.transform.Find("Text").GetComponent<Text>().text = data.normalMessage;
                myBallon.transform.Find("Text").GetComponent<Text>().font = normalFont;

                if (inf != null)
                    inf.sendMessage();
                if (ask != null)
                    ask.activePuzzle();
                if (sol != null)
                    sol.chooseThis();
                if (ul != null)
                    ul.GiveUpgrade();
                if (inq != null)
                    inq.getAnswer();
            } else {
                myBallon.transform.Find("Text").GetComponent<Text>().text = data.emojiMessage;
                myBallon.transform.Find("Text").GetComponent<Text>().font = emojiFont;
                if (ul != null && this.GetComponent<TranslateUnlocker>() != null)
                    ul.GiveUpgrade();
            }
        }
    }

    public override void Close() {
        if (!locked) {
            message.SetActive(true);
			GameManager.mainCam.focusOnObject(GameManager.player.transform);
            Destroy(myBallon);
            myBallon = null;
            if (inf != null)
                inf.checkPuzzle();
            if (sol != null)
                sol.send();
        }
    }

    public override void Near() {
        if (!locked) {
			Vector3 dist = (GameManager.player.transform.position - transform.position).normalized * camDist;
            pivot.position = transform.position + new Vector3(dist.x, camHeight, dist.z);
            float aux = pivot.eulerAngles.x;
            pivot.transform.LookAt(this.transform);
            pivot.eulerAngles = new Vector3(aux, pivot.eulerAngles.y, pivot.eulerAngles.z);

			Vector3 temp = new Vector3(GameManager.player.transform.position.x - transform.position.x, 0.0f, GameManager.player.transform.position.z - transform.position.z).normalized;
            message.transform.localPosition = temp;
            message.transform.forward = temp;
            message.SetActive(true);

            if (Solutioner.chosen == null || Solutioner.chosen.gameObject != this.gameObject)
                this.transform.Find("Model3D").Find("Shine").GetComponent<MeshRenderer>().material.color = onColor;
            this.transform.Find("Model3D").Find("Eye").gameObject.SetActive(true);
        }
    }

    public override void Away() {
        if (!locked) {
            if (Solutioner.chosen == null || Solutioner.chosen.gameObject != this.gameObject) {
                message.SetActive(false);
                this.transform.Find("Model3D").Find("Shine").GetComponent<MeshRenderer>().material.color = offColor;
            }
            this.transform.Find("Model3D").Find("Eye").gameObject.SetActive(false);
        }
    }
}
