using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {
	
	void Update(){
		if (DataStorage.instance == null) {
			GameObject aux = new GameObject ();
			aux.gameObject.name = "DataStorage";
			aux.gameObject.AddComponent<DataStorage> ();
			DataStorage.instance.Save ();
		} else {
			DataStorage.instance.Load ();
		}
		Destroy (this.gameObject);
	}
}
