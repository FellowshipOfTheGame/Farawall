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
    bool changing = false;

	// Use this for initialization
	void Start () {
        cam = this.GetComponent<AutoCam>();
        GameManager.mainCam = this.GetComponent<CameraControl>();
        pivot = transform.Find("Pivot");
        focus = cam.Target.Find("Pivot");
    }

    // Update is called once per frame
    void Update() {
        if (changing && pivot.position != focus.position || pivot.rotation != focus.rotation) {
            pivot.position = Vector3.Lerp(pivot.position, focus.position, transitionDelay);
            pivot.rotation = Quaternion.Lerp(pivot.rotation, focus.rotation, transitionDelay);

            if ((pivot.position - focus.position).magnitude < 0.001 && (pivot.eulerAngles - focus.eulerAngles).magnitude < 0.001)
                changing = false;
        }
    }

    public void focusOnObject(Transform target) {
        focus = target.Find("Pivot");
        changing = true;
        Invoke("stopChange", 0.5f);
    }

    void stopChange() {
        changing = false;
    }
}
