using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneButtonScript : MonoBehaviour {
	private Button b;
	[SerializeField]
	public string scene;

	// Use this for initialization
	void Start () {
		b = GetComponent<Button>();
		b.onClick.AddListener (() =>ChangeScene());
	}

	void ChangeScene(){
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}
}
