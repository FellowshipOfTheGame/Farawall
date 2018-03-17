using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataStorage : MonoBehaviour {

	public static DataStorage instance = null;

	private static Vector3 startPosition;
	private static List<string> foundKeys = new List<string> ();
	private static List<string> usedKeys = new List<string> ();
	private static List<int> lockedDoors = new List<int> ();
	private static List<string> cantDrop = new List<string> ();
	private static List<string> notDestroyedKeys = new List<string> ();
	private static List<string> alreadyGivenInformation = new List<string> ();
	private static List<string> foundInformation = new List<string> ();
	private static string puzzleInformationCounter;
	private static bool canTranslate;
	private static bool dataButton;
	private static bool puzzleButton;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else if (instance != null) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	public static void Save(){

		usedKeys.Clear ();
		foundKeys.Clear ();
		lockedDoors.Clear ();
		cantDrop.Clear ();
		notDestroyedKeys.Clear ();
		alreadyGivenInformation.Clear ();
		foundInformation.Clear ();
		startPosition = GameManager.player.transform.position;
		canTranslate = GameManager.player.canTranslate;
		dataButton = GameManager.menu.transform.Find ("MainTab").Find ("Buttons").Find ("DataButton").gameObject.activeSelf;
		puzzleButton = GameManager.menu.transform.Find ("DataTab").Find ("Buttons").Find ("PuzzleButton").gameObject.activeSelf;
		Transform aux = GameManager.menu.keyFloor.Find ("Keys1").gameObject.transform;
		for (int i = 0; i < aux.childCount; i++) {
			if (aux.GetChild (i).gameObject.activeSelf) {
				usedKeys.Add (aux.GetChild(i).gameObject.name);
			}
		}
		aux = GameManager.menu.keyFloor.Find ("Keys2").gameObject.transform;
		for (int i = 0; i < aux.childCount; i++) {
			if (aux.GetChild (i).gameObject.activeSelf) {
				foundKeys.Add (aux.GetChild (i).gameObject.name);
			}
		}
		Door[] doors = FindObjectsOfType<Door> ();
		foreach(Door temp in doors){
			if (temp.hasKey && temp.isUnlocked()) {
				lockedDoors.Add (temp.code);
			}
		}
		DropItem[] dropitems = FindObjectsOfType<DropItem> ();
		foreach (DropItem temp in dropitems) {
			if (!temp.canDrop) {
				cantDrop.Add (temp.name);
			}
		}
		Key[] keys = FindObjectsOfType<Key> ();
		foreach (Key temp in keys) {
			notDestroyedKeys.Add (temp.name);
		}
		Informer[] informers = FindObjectsOfType<Informer> ();
		foreach (Informer temp in informers) {
			if (!temp.isNew) {
				alreadyGivenInformation.Add (temp.name);
			}
		}
		aux = GameManager.menu.transform.Find ("DataTab").Find ("PuzzleData").Find ("P1Tab").Find ("Infos").transform;
		for (int i = 0; i < aux.childCount; i++) {
			if (aux.GetChild (i).gameObject.activeSelf) {
				foundInformation.Add (aux.GetChild(i).GetChild(0).GetComponent<Text>().text);
			}
		}
		puzzleInformationCounter = GameManager.menu.transform.Find ("DataTab").Find ("PuzzleData").Find ("P1Tab").Find ("Counter").GetComponent<Text> ().text;

	}

	public static void Load(){
		
		GameManager.player.transform.position = startPosition;
		GameManager.player.canTranslate = canTranslate;
		GameManager.menu.transform.Find ("MainTab").Find ("Buttons").Find ("DataButton").gameObject.SetActive (dataButton);
		GameManager.menu.transform.Find ("DataTab").Find ("Buttons").Find ("PuzzleButton").gameObject.SetActive (puzzleButton);
		Transform aux = GameManager.menu.keyFloor.Find ("Keys1").gameObject.transform;
		for (int i = 0; i < usedKeys.Count; i++) {
			GameObject temp = Instantiate(aux.GetChild(0).gameObject, aux);
			temp.name = usedKeys [i];
			temp.transform.GetChild(0).GetComponent<Text>().text = "K-" + usedKeys[i];
			temp.SetActive(true);
		}
		aux = GameManager.menu.keyFloor.Find ("Keys2").gameObject.transform;
		for (int i = 0; i < foundKeys.Count; i++) {
			GameObject temp = Instantiate(aux.GetChild(0).gameObject, aux);
			temp.name = foundKeys [i];
			temp.transform.GetChild(0).GetComponent<Text>().text = "K-" + foundKeys[i];
			temp.SetActive(true);
		}
		Door[] doors = FindObjectsOfType<Door> ();
		foreach (Door temp in doors) {
			if (temp.hasKey) {
				bool i = lockedDoors.Contains (temp.code);
				if (i) {
					temp.ToggleLock ();
				}
			}
		}
		DropItem[] dropitems = FindObjectsOfType<DropItem> ();
		foreach (DropItem temp in dropitems) {
			if (cantDrop.Contains(temp.name)){
				temp.canDrop = false;
			}
		}
		Key[] keys = FindObjectsOfType<Key> ();
		foreach (Key temp in keys) {
			if (!notDestroyedKeys.Contains (temp.name)) {
				Destroy (temp.gameObject);
			}
		}
		Informer[] informers = FindObjectsOfType<Informer> ();
		foreach (Informer temp in informers) {
			if (alreadyGivenInformation.Contains (temp.name)) {
				temp.isNew = false;
			}
		}
		aux = GameManager.menu.transform.Find ("DataTab").Find ("PuzzleData").Find ("P1Tab").Find ("Infos").transform;
		for (int i = 0; i < foundInformation.Count; i++) {
			GameObject temp = Instantiate(aux.GetChild(0).gameObject, aux);
			temp.transform.GetChild(0).GetComponent<Text>().text = foundInformation[i];
			temp.SetActive(true);
		}
		GameManager.menu.transform.Find ("DataTab").Find ("PuzzleData").Find ("P1Tab").Find ("Counter").GetComponent<Text> ().text = puzzleInformationCounter;

	}

}
