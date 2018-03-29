using System.Collections;
using System.IO;
using UnityEngine;
using UnityEditor;

public class Save_Load : MonoBehaviour {

			
	void Update(){
//		if (Input.GetKeyDown (KeyCode.M)) {
//			DataStorage.Save ();
//		} else if (Input.GetKeyDown (KeyCode.L)) {
//			DataStorage.Load ();
//		}
		if (Test.instance == null) {
			GameObject aux = new GameObject ();
			aux.gameObject.name = "Test";
			aux.gameObject.AddComponent<Test> ();
			Test.instance.Save ();
		} else {
			Test.instance.Load ();
		}
			Destroy (this.gameObject);
		}

}
