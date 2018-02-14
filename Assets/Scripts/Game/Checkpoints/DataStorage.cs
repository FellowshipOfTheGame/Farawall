using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour {
	
	public static DataStorage instance = null;
	private static Vector3 startPosition;
	private static List<DoorInfo> doorsInfo;

	void Awake(){
		if (instance == null) {
			instance = this;
			doorsInfo = new List<DoorInfo>();
		} else if (instance != null) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	public static void Save(){
		startPosition = GameObject.Find("Player").transform.position;
		foreach (Door aux in Resources.FindObjectsOfTypeAll<Door>()) {
			if (aux.hasKey) {
				doorsInfo.Add (new DoorInfo(aux.code,aux));
			}
		}
	}

	public static void Load(){
		GameObject.Find ("Player").transform.position = DataStorage.Player ();
		foreach(Door aux in Resources.FindObjectsOfTypeAll<Door>()){
			if (aux.hasKey && DataStorage.Door(aux.code)) {
				aux.Unlock();
			}
		}
	}

	public static Vector3 Player(){
		return startPosition;
	}

	public static bool Door(int code){
		foreach(DoorInfo aux in doorsInfo){
			if (aux.code == code)
				return aux.unlocked;
		}
		return false;
	}

}
