using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerControl : MonoBehaviour {

    GameManager gm;
    ThirdPersonUserControl movement;
    bool isTalking = false;
    public bool nearWall = false;
    public bool canTranslate = false;
    List<int> codes;

    Interactable currInter = null;
    // Use this for initialization
    void Start () {
        gm = FindObjectOfType<GameManager>();
        movement = this.GetComponent<ThirdPersonUserControl>();
        codes = new List<int>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!gm.paused) {
            if (currInter != null && Input.GetKeyDown(KeyCode.X)) {
                if (!isTalking) {
                    if (!currInter.isItem) {
                        isTalking = true;
                        movement.setCanMove(false);
                    }
                    currInter.Interact();
                } else {
                    isTalking = false;
                    movement.setCanMove(true);
                    currInter.Close();
                }
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Interactable") {
            currInter = other.GetComponent<Interactable>();
            currInter.Near();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Interactable") {
            currInter.Away();
            currInter = null;
        }
    }

    public void addKey(int code) {
        codes.Add(code);
    }

    public bool haveKey(int code) {
        for (int i = 0; i < codes.Count; i++) {
            if (codes[i] == code)
                return true;
        }
        return false;
    }

    public void TakeDamage() {
        gm.ShowGameOver();
    }
}
