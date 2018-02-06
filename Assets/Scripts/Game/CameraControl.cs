using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class CameraControl : MonoBehaviour {

    AutoCam cam;
    public string state;
    public Transform currStatue;
    public float transitionDelay;
    Transform pivot;
    Vector3 pivotPos, pivotAngles;
    Quaternion pivotRot;

	// Use this for initialization
	void Start () {
        cam = this.GetComponent<AutoCam>();
        pivot = transform.Find("Pivot");
        pivotPos = pivot.localPosition;
        pivotAngles = pivot.localEulerAngles;
    }

    // Update is called once per frame
    void Update() {
        if (pivot.localPosition != pivotPos || pivot.localEulerAngles != pivotAngles) {
            pivot.localPosition = Vector3.Lerp(pivot.localPosition, pivotPos, transitionDelay);
            pivot.localRotation = Quaternion.Lerp(pivot.localRotation, pivotRot, transitionDelay);
        }
    }

    public void focusOnObject(Transform target) {
        pivotPos = target.Find("Pivot").localPosition;
        pivotRot = target.Find("Pivot").localRotation;
        cam.SetTarget(target);
    }
}
