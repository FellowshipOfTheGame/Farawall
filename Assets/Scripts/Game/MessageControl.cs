using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageControl : MonoBehaviour {

    public float delay;
    float currTime, startTime;

	// Use this for initialization
	void Start () {
        this.GetComponent<Image>().enabled = false;
        this.transform.Find("Text").GetComponent<Text>().enabled = false;
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        currTime = Time.time;
        if (currTime - startTime >= delay) {
            this.GetComponent<Image>().enabled = true;
            this.transform.Find("Text").GetComponent<Text>().enabled = true;
        }
	}
}
