using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {
	
	void Update(){
//		if (Input.GetKeyDown (KeyCode.M)) {
//			DataStorage.Save ();
//		} else if (Input.GetKeyDown (KeyCode.L)) {
//			DataStorage.Load ();
//		}
		if (DataStorage.instance == null) {
			GameObject aux = new GameObject ();
			aux.gameObject.name = "DataStorage";
			aux.gameObject.AddComponent<DataStorage> ();
			DataStorage.Save ();
		} else {
			DataStorage.Load ();
		}
		Destroy (this.gameObject);
	}
}
