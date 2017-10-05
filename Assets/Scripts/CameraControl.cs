using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform player;
    public float delay, offset, height;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 destiny = player.position - Quaternion.Euler(player.Find("Pivot").Find("PlayerModel").eulerAngles) * Vector3.forward * offset + Vector3.up * height;
        this.transform.position = Vector3.Lerp(this.transform.position, destiny, delay);
        this.transform.LookAt(player.Find("Pivot"));

    }
}
