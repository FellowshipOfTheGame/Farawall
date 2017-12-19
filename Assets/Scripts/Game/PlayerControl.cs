using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    GameManager gm;
    public float lastTurn = 0.0f;
    public float speed, turnTime;
    public Animator playerAnime;
    public bool isTurning = false;
    Transform pivot;
    bool isTalking = false;
    public int[] wallDetect;
    public bool nearWall = false;
    public LayerMask wallLayer;
    public bool canTranslate = false, canTurn;

    Interactable currInter = null;
    // Use this for initialization
    void Start () {
        gm = FindObjectOfType<GameManager>();
        wallDetect = new int[4];
        pivot = this.transform.Find("Pivot");
	}
	
	// Update is called once per frame
	void Update () {
        if (!gm.paused) {
            if (currInter != null && Input.GetKeyDown(KeyCode.X)) {
                if (!isTalking) {
                    isTalking = true;
                    currInter.Interact();
                } else {
                    isTalking = false;
                    currInter.Close();
                }
            }

            if (!isTalking)
                Move();
        }
    }

    void Move() {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (!isTurning) {
                Vector3 dir = Quaternion.Euler(pivot.eulerAngles + new Vector3(0.0f, 90.0f, 0.0f)) * Vector3.forward * 0.8f;
                if (Physics.OverlapSphere(this.transform.position - dir, 0.3f, wallLayer).Length == 0)
                    playerAnime.SetTrigger("TurnBack");
                else
                    playerAnime.SetTrigger("TurnBack2");

                lastTurn = 180.0f;
                isTurning = true;
            }
            CancelInvoke();
            Invoke("ResetTurn", 17.0f * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (!isTurning) {
                playerAnime.SetTrigger("TurnRight");
                lastTurn = 90.0f;
                isTurning = true;
            }
            CancelInvoke();
            Invoke("ResetTurn", 17.0f * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (!isTurning) {
                playerAnime.SetTrigger("TurnLeft");
                lastTurn = -90.0f;
                isTurning = true;
            }
            CancelInvoke();
            Invoke("ResetTurn", 17.0f * Time.deltaTime);
        }

       Vector3 direction = Quaternion.Euler(pivot.Find("PlayerModel").eulerAngles) * Vector3.forward;

        if (Input.GetKey(KeyCode.UpArrow))
            this.GetComponent<Rigidbody>().velocity = direction * speed * Time.deltaTime;
    }

    void ResetTurn() {
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow))
            isTurning = false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Interactable") {
            currInter = other.GetComponent<Interactable>();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Interactable") {
            currInter = null;
        }
    }

    public void TakeDamage() {
        gm.ShowGameOver();
    }
}
