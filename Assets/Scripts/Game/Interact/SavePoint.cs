﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : Interactable{

	public Door doorToLock = null;
	public Color onColor, offColor;
	public GameObject genericBallon;
	[Space(10)]

	public float ballonOffset, ballonHeight;
	public float camDist, camHeight;
	public GameObject message;
	[Space(10)]
	public GameObject myBallon = null;
	Transform pivot;

	private GameManager GM;
	private bool alreadyLockedDoor = false;

	void Start(){
		GM = GameManager.instance;
		pivot = transform.Find ("Pivot");
		this.transform.Find("Model3D").Find("Eye").gameObject.SetActive(false);
	}

	public override void Interact ()
	{
		GM.mainCam.focusOnObject (this.transform);
		if (doorToLock != null && !alreadyLockedDoor) {
			doorToLock.ToggleLock ();
			alreadyLockedDoor = true;
		}
		DataStorage.Save ();
	}

	public override void Close ()
	{
		GM.mainCam.focusOnObject (GM.player.transform);
	}

	public override void Near()
	{
		Vector3 dist = (GM.player.transform.position - transform.position).normalized * camDist;
		pivot.position = transform.position + new Vector3(dist.x, camHeight, dist.z);
		float aux = pivot.eulerAngles.x;
		pivot.transform.LookAt(this.transform);
		pivot.eulerAngles = new Vector3(aux, pivot.eulerAngles.y, pivot.eulerAngles.z);

		Vector3 temp = new Vector3(GM.player.transform.position.x - transform.position.x, 0.0f, GM.player.transform.position.z - transform.position.z).normalized;
		message.transform.localPosition = temp;
		message.transform.forward = temp;
		message.SetActive(true);
		this.transform.Find("Model3D").Find("Shine").GetComponent<MeshRenderer>().material.color = onColor;
		this.transform.Find("Model3D").Find("Eye").gameObject.SetActive(true);
	}

	public override void Away ()
	{
		message.SetActive(false);
		this.transform.Find("Model3D").Find("Shine").GetComponent<MeshRenderer>().material.color = offColor;
		this.transform.Find("Model3D").Find("Eye").gameObject.SetActive(false);
	}
}
