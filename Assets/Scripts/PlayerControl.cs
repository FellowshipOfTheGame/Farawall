using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed, turnTime;
    public Animator playerAnime;
    public bool isTurning = false;
    Transform pivot;

	// Use this for initialization
	void Start () {
        pivot = this.transform.Find("Pivot");
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move() {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            playerAnime.SetTrigger("TurnBack");

        if (Input.GetKeyDown(KeyCode.RightArrow))
            playerAnime.SetTrigger("TurnRight");

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            playerAnime.SetTrigger("TurnLeft");

       Vector3 direction = Quaternion.Euler(pivot.Find("PlayerModel").eulerAngles) * Vector3.forward;

        if (Input.GetKey(KeyCode.UpArrow))
            this.GetComponent<Rigidbody>().velocity = direction * speed * Time.deltaTime;
    }
}
