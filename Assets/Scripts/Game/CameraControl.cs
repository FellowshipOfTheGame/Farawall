using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class CameraControl : MonoBehaviour {

    AutoCam cam;
    public Canvas canvas;
    public string state;
    public Transform currStatue, focus;
    public float transitionDelay;
    Transform pivot;

	// Use this for initialization
	void Start () {
        cam = this.GetComponent<AutoCam>();
        GameManager.mainCam = this.GetComponent<CameraControl>();
        pivot = transform.Find("Pivot");
        focus = cam.Target.Find("Pivot");
    }

    // Update is called once per frame
    void Update() {
        if (pivot.position != focus.position || pivot.rotation != focus.rotation) {
            pivot.position = Vector3.Lerp(pivot.position, focus.position, transitionDelay);
            pivot.rotation = Quaternion.Lerp(pivot.rotation, focus.rotation, transitionDelay);
        }
    }

    public void focusOnObject(Transform target) {
        focus = target.Find("Pivot");
    }
}
