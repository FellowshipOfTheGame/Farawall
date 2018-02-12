using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatueControl : Interactable {

    GameManager GM;
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

	// Use this for initialization
	void Start () {
        GM = FindObjectOfType<GameManager>() as GameManager;
        this.transform.Find("Model3D").Find("Eye").gameObject.SetActive(false);
        pivot = transform.Find("Pivot");
        inf = this.GetComponent<Informer>();
        ask = this.GetComponent<Asker>();
        sol = this.GetComponent<Solutioner>();
        if (sol == null)
            message.transform.Find("Text").GetComponent<TextMesh>().text = "Talk";
        else
            message.transform.Find("Text").GetComponent<TextMesh>().text = sol.answer;
        this.name = data.name;
        message.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

	}

    public override void Interact() {
        if (!locked) {
            message.SetActive(false);
            GM.mainCam.focusOnObject(this.transform);
            myBallon = Instantiate(genericBallon, GM.canvas.transform);
            if (GM.player.canTranslate) {
                myBallon.transform.Find("Text").GetComponent<Text>().text = data.normalMessage;
                myBallon.transform.Find("Text").GetComponent<Text>().font = normalFont;

                if (inf != null)
                    inf.sendMessage();
                else if (ask != null)
                    ask.talk();
                else if (sol != null)
                    sol.chooseThis();
            } else {
                myBallon.transform.Find("Text").GetComponent<Text>().text = data.emojiMessage;
                myBallon.transform.Find("Text").GetComponent<Text>().font = emojiFont;
            }
        }
    }

    public override void Close() {
        if (!locked) {
            message.SetActive(true);
            GM.mainCam.focusOnObject(GM.player.transform);
            Destroy(myBallon);
            myBallon = null;
            if (inf != null)
                inf.checkPuzzle();
        }
    }

    public override void Near() {
        if (!locked) {
            Vector3 dist = (GM.player.transform.position - transform.position).normalized * camDist;
            pivot.position = transform.position + new Vector3(dist.x, camHeight, dist.z);
            float aux = pivot.eulerAngles.x;
            pivot.transform.LookAt(this.transform);
            pivot.eulerAngles = new Vector3(aux, pivot.eulerAngles.y, pivot.eulerAngles.z);

            Vector3 temp = new Vector3(GM.player.transform.position.x - transform.position.x, 0.0f, GM.player.transform.position.z - transform.position.z).normalized;
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
