using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform player, currStatue;
    public float delay, offset, height;
    public float statueOffset, statueHeight;
    public string state = "player";
    GameObject target;

	// Use this for initialization
	void Start () {
        target = new GameObject();
        target.transform.position = player.Find("Pivot").position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 destiny = new Vector3();
        if(state == "player") {
            destiny = player.position - Quaternion.Euler(player.Find("Pivot").Find("PlayerModel").eulerAngles) * Vector3.forward * offset + Vector3.up * height;
            target.transform.position = Vector3.Lerp(target.transform.position, player.Find("Pivot").position, delay);
        }else if(state == "statue") {
            destiny = currStatue.position - new Vector3(currStatue.position.x - player.position.x, 0.0f, currStatue.position.z - player.position.z).normalized * 1.5f * statueOffset + Vector3.up * statueHeight;
            target.transform.position = Vector3.Lerp(target.transform.position, currStatue.position, delay / 2);
        }
        this.transform.position = Vector3.Lerp(this.transform.position, destiny, delay);
        this.transform.LookAt(target.transform);


    }
}
