using System.Collections;
using System.IO;
using UnityEngine;

public class Save_Load : MonoBehaviour {
	//substitute for dataManager
	void Update(){
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
