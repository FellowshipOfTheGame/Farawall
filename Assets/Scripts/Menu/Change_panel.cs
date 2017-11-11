using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_panel : MonoBehaviour {
	[SerializeField]
	private bool isOnFirstPanel;
	[SerializeField]
	private GameObject nextPanel;
	[SerializeField]
	private GameObject currentPanel;
	private Button self;

	// Use this for initialization
	void Start () {
		if (!isOnFirstPanel)
			currentPanel.SetActive (false);
		self = GetComponent<Button>();
		self.onClick.AddListener (() =>ChangePanel());
	}

	void ChangePanel () {
		currentPanel.SetActive (false);
		nextPanel.SetActive (true);
	}
}
