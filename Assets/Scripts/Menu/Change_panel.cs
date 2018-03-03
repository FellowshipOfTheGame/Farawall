using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_panel : MonoBehaviour {
	[SerializeField]
	private GameObject nextPanel;
	private Button self;

	// Use this for initialization
	void Start () {
		self = GetComponent<Button>();
		self.onClick.AddListener (() =>ChangePanel());
	}

	void ChangePanel () {
		transform.parent.gameObject.SetActive (false);
		nextPanel.SetActive (true);
	}
}
