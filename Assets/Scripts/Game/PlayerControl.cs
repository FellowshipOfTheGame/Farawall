using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerControl : MonoBehaviour {

    ThirdPersonUserControl movement;
    bool isTalking = false;

	public int maxLife;
	[SerializeField]
	private int currentLife;
    public bool canPlay = false;
    public bool canTranslate = false;
    public 
    List<int> codes;

    Interactable currInter = null;
    // Use this for initialization
    void Start () {
		GameManager.player = this.GetComponent<PlayerControl>();
        movement = this.GetComponent<ThirdPersonUserControl>();
        codes = new List<int>();
		currentLife = maxLife;
	}

    // Update is called once per frame
    void Update() {
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

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Interactable") {
            if (currInter != null)
                currInter.Away();
            currInter = other.GetComponent<Interactable>();
            currInter.Near();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Interactable") {
            Interactable aux = other.GetComponent<Interactable>();
            aux.Away();
            if (currInter == aux)
                currInter = null;
        }
    }

    public void addKey(int code) {
        codes.Add(code);
    }

	public void removeKey(int code){
		codes.Remove (code);
	}

    public bool haveKey(int code) {
        for (int i = 0; i < codes.Count; i++) {
            if (codes[i] == code)
                return true;
        }
        return false;
    }

	public void TakeDamage(int damage) {
		currentLife -= damage;
		if (currentLife <= 0) {
			GameManager.ShowGameOver ();
		}
    }
}
