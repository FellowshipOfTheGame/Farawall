using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataStorage : MonoBehaviour {

	public static DataStorage instance = null;

//	private static bool saved = false;
	private static Vector3 startPosition;
	private static List<string> foundKeys = new List<string> ();
	private static List<string> usedKeys = new List<string> ();
	private static List<int> lockedDoors = new List<int> ();
	private static List<string> cantDrop = new List<string> ();
	private static List<string> notDestroyedKeys = new List<string> ();
	private static List<string> alreadyGivenInformation = new List<string> ();
	private static List<string> foundInformation = new List<string> ();
	private static List<string> givenUpgrades = new List<string>();
	private static List<int> codes;
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
//		saved = true;

		usedKeys.Clear ();//limpando listas
		foundKeys.Clear ();
		lockedDoors.Clear ();
		cantDrop.Clear ();
		notDestroyedKeys.Clear ();
		alreadyGivenInformation.Clear ();
		foundInformation.Clear ();
		givenUpgrades.Clear ();
		codes = new List<int> (GameManager.player.codes);//salvando lista de codigos do jogador
		startPosition = GameManager.player.transform.position;//salvando posicao so jogador
		canTranslate = GameManager.player.canTranslate;//salvado se jogador achou o tradutor
		dataButton = GameManager.menu.transform.Find ("MainTab").Find ("Buttons").Find ("DataButton").gameObject.activeSelf;//salvando se o jogador ja liberou o botão de data
		puzzleButton = GameManager.menu.transform.Find ("DataTab").Find ("Buttons").Find ("PuzzleButton").gameObject.activeSelf;//salvando se o jogador ja liberou o botão de informacoes dos quebra-cabecas
		Transform aux = GameManager.menu.keyFloor.Find ("Keys1").gameObject.transform;//salvando chaves ja utilizadas
		for (int i = 0; i < aux.childCount; i++) {
			if (aux.GetChild (i).gameObject.activeSelf) {
				usedKeys.Add (aux.GetChild(i).gameObject.name);
			}
		}
		aux = GameManager.menu.keyFloor.Find ("Keys2").gameObject.transform;//salvando chaves ja encontradas
		for (int i = 0; i < aux.childCount; i++) {
			if (aux.GetChild (i).gameObject.activeSelf) {
				foundKeys.Add (aux.GetChild (i).gameObject.name);
			}
		}
		Door[] doors = FindObjectsOfType<Door> ();//salvando portas ja destrancadas
		foreach(Door temp in doors){
			if (temp.hasKey && temp.isUnlocked()) {
				lockedDoors.Add (temp.code);
			}
		}
		DropItem[] dropitems = FindObjectsOfType<DropItem> ();//salvando itens ja coletados
		foreach (DropItem temp in dropitems) {
			if (!temp.canDrop) {
				cantDrop.Add (temp.name);
			}
		}
		Key[] keys = FindObjectsOfType<Key> ();//salvando chaves nao coletadas
		foreach (Key temp in keys) {
			notDestroyedKeys.Add (temp.name);
		}
		Informer[] informers = FindObjectsOfType<Informer> ();//salvando informacoes ja fornecidas
		foreach (Informer temp in informers) {
			if (!temp.isNew) {
				alreadyGivenInformation.Add (temp.name);
			}
		}
		Unlocker[] unlocked = FindObjectsOfType<Unlocker> ();//salvando upgrades ja obtidos
		foreach (Unlocker temp in unlocked) {
			if (temp.alreadyGive) {
				givenUpgrades.Add (temp.name);
			}
		}
		aux = GameManager.menu.transform.Find ("DataTab").Find ("PuzzleData").Find ("P1Tab").Find ("Infos").transform;//salvando informacoes ja obtidas
		for (int i = 0; i < aux.childCount; i++) {
			if (aux.GetChild (i).gameObject.activeSelf) {
				foundInformation.Add (aux.GetChild(i).GetChild(0).GetComponent<Text>().text);
			}
		}
		puzzleInformationCounter = GameManager.menu.transform.Find ("DataTab").Find ("PuzzleData").Find ("P1Tab").Find ("Counter").GetComponent<Text> ().text;//salvando o numero de informacoes ja obtidas

	}

	public static void Load(){

		GameManager.player.codes = new List<int> (codes);//carregando lista de codigos do jogador
		GameManager.player.transform.position = startPosition;//carregando posicao so jogador
		GameManager.player.canTranslate = canTranslate;//carregando se jogador achou o tradutor
		GameManager.menu.transform.Find ("MainTab").Find ("Buttons").Find ("DataButton").gameObject.SetActive (dataButton);//carregando se o jogador ja liberou o botão de data
		GameManager.menu.transform.Find ("DataTab").Find ("Buttons").Find ("PuzzleButton").gameObject.SetActive (puzzleButton);//carregando se o jogador ja liberou o botão de informacoes dos quebra-cabecas
		Transform aux = GameManager.menu.keyFloor.Find ("Keys1").gameObject.transform;//carregando chaves ja utilizadas
		for (int i = 0; i < usedKeys.Count; i++) {
			GameObject temp = Instantiate(aux.GetChild(0).gameObject, aux);
			temp.name = usedKeys [i];
			temp.transform.GetChild(0).GetComponent<Text>().text = "K-" + usedKeys[i];
			temp.SetActive(true);
		}
		aux = GameManager.menu.keyFloor.Find ("Keys2").gameObject.transform;//carregando chaves ja encontradas
		for (int i = 0; i < foundKeys.Count; i++) {
			GameObject temp = Instantiate(aux.GetChild(0).gameObject, aux);
			temp.name = foundKeys [i];
			temp.transform.GetChild(0).GetComponent<Text>().text = "K-" + foundKeys[i];
			temp.SetActive(true);
		}
		Door[] doors = FindObjectsOfType<Door> ();//carregando portas ja destrancadas
		foreach (Door temp in doors) {
			if (temp.hasKey) {
				bool i = lockedDoors.Contains (temp.code);
				if (i) {
					temp.ToggleLock ();
				}
			}
		}
		DropItem[] dropitems = FindObjectsOfType<DropItem> ();//carregando itens ja coletados
		foreach (DropItem temp in dropitems) {
			if (cantDrop.Contains(temp.name)){
				temp.canDrop = false;
			}
		}
		Key[] keys = FindObjectsOfType<Key> ();//carregando chaves nao coletadas
		foreach (Key temp in keys) {
			if (!notDestroyedKeys.Contains (temp.name)) {
				Destroy (temp.gameObject);
			}
		}
		Informer[] informers = FindObjectsOfType<Informer> ();//carregando informacoes ja fornecidas
		foreach (Informer temp in informers) {
			if (alreadyGivenInformation.Contains (temp.name)) {
				temp.isNew = false;
			}
		}
		Unlocker[] unlocked = FindObjectsOfType<Unlocker> ();//carregando upgrades ja obtidos
		foreach (Unlocker temp in unlocked) {
			if (givenUpgrades.Contains (temp.name)) {
				temp.alreadyGive = true;
			}
		}
		aux = GameManager.menu.transform.Find ("DataTab").Find ("PuzzleData").Find ("P1Tab").Find ("Infos").transform;//carregando informacoes ja obtidas
		for (int i = 0; i < foundInformation.Count; i++) {
			GameObject temp = Instantiate(aux.GetChild(0).gameObject, aux);
			temp.transform.GetChild(0).GetComponent<Text>().text = foundInformation[i];
			temp.SetActive(true);
		}
		GameManager.menu.transform.Find ("DataTab").Find ("PuzzleData").Find ("P1Tab").Find ("Counter").GetComponent<Text> ().text = puzzleInformationCounter;//carregando o numero de informacoes ja obtidas

	}

/*	public static bool isSaved(){
		return saved;
	}*/
}
