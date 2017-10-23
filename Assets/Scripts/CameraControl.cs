using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform player, currStatue;
    public float delay, offset, height;
    public float statueOffset, statueHeight;
    public string state = "player";
    GameObject target;
    Vector3 wallChecker;

    public LayerMask wallLayer;

	// Use this for initialization
	void Start () {
        target = new GameObject();
        target.transform.position = player.Find("Pivot").position;
        wallChecker = player.position - Quaternion.Euler(player.Find("Pivot").Find("PlayerModel").eulerAngles) * Vector3.forward * 0.8f;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 destiny = new Vector3();
        if(state == "player") {
            Vector3 dir = Quaternion.Euler(player.Find("Pivot").eulerAngles + new Vector3(0.0f, player.GetComponent<PlayerControl>().lastTurn, 0.0f)) * Vector3.forward * 0.8f;
            Collider[] aux = Physics.OverlapSphere(player.transform.position - dir, 0.3f, wallLayer);
            if (player.GetComponent<PlayerControl>().isTurning && aux.Length == 0)
                wallChecker = player.position - Quaternion.Euler(player.Find("Pivot").Find("PlayerModel").eulerAngles) * Vector3.forward * 0.8f;
            Collider[] col = Physics.OverlapSphere(wallChecker, 0.3f, wallLayer);
            Debug.Log(col.Length);
            Vector3 wallChecker2 = new Vector3();
            if (player.GetComponent<PlayerControl>().isTurning && aux.Length == 0 && col.Length > 0) {
                float ajust = Vector3.Angle(Vector3.forward,(player.position - col[0].transform.position).normalized);
                wallChecker2 = player.position - Quaternion.Euler(0.0f, ajust, 0.0f) * Quaternion.Euler(-2 * player.Find("Pivot").Find("PlayerModel").eulerAngles) * Vector3.left * 0.8f * Mathf.Sign(player.GetComponent<PlayerControl>().lastTurn);
            } else {
                while (col.Length > 0 && aux.Length == 0) {
                    if (player.GetComponent<PlayerControl>().lastTurn == -90.0f)
                        wallChecker = Quaternion.Euler(0.0f, 15.0f, 0.0f) * (wallChecker - player.position) + player.position;
                    else
                        wallChecker = Quaternion.Euler(0.0f, -15.0f, 0.0f) * (wallChecker - player.position) + player.position;
                    col = Physics.OverlapSphere(wallChecker, 0.3f, wallLayer);
                }
                wallChecker2 = wallChecker;
            }
            destiny = player.position + (wallChecker2 - player.position).normalized * offset + Vector3.up * height;

            target.transform.position = Vector3.Lerp(target.transform.position, player.Find("Pivot").position, delay);
        }else if(state == "statue") {
            destiny = currStatue.position - new Vector3(currStatue.position.x - player.position.x, 0.0f, currStatue.position.z - player.position.z).normalized * 1.5f * statueOffset + Vector3.up * statueHeight;
            target.transform.position = Vector3.Lerp(target.transform.position, currStatue.position, delay / 2);
        }
        this.transform.position = Vector3.Lerp(this.transform.position, destiny, delay);
        this.transform.LookAt(target.transform);
    }
}
