using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour {

	void Start(){

	}

	public void changeScene(string scene){
		GameManager.loadGameScene (scene);
	}
}
