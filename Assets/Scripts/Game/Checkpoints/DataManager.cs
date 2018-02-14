using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

	void Awake() {
		if (DataStorage.instance == null) {
			GameObject aux = new GameObject ();
			aux.gameObject.name = "DataStorage";
			aux.gameObject.AddComponent<DataStorage> ();
			DataStorage.Save ();
		}
	}

	void Start(){
		DataStorage.Load ();
	}

}
