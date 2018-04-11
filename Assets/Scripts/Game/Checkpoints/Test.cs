using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Test : MonoBehaviour {
	//substitute for DataStorage
	public static Test instance = null;

	[HideInInspector]
	public Data data = new Data();
	public bool saveInFile = false;
	public string path = "/data";
	public bool encypt = false;
	//	private static bool saved = false;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else if (instance != null) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	public void Save(){
		//		saved = true;

		data.usedKeys.Clear ();//limpando listas
		data.foundKeys.Clear ();
		data.lockedDoors.Clear ();
		data.cantDrop.Clear ();
		data.notDestroyedKeys.Clear ();
		data.alreadyGivenInformation.Clear ();
		data.foundInformation.Clear ();
		data.givenUpgrades.Clear ();
		data.codes = new List<int> (GameManager.player.codes);//salvando lista de codigos do jogador
		data.startPosition = GameManager.player.transform.position;//salvando posicao so jogador
		data.canTranslate = GameManager.player.canTranslate;//salvado se jogador achou o tradutor
		data.dataButton = GameManager.menu.transform.Find ("MainTab").Find ("Buttons").Find ("DataButton").gameObject.activeSelf;//salvando se o jogador ja liberou o botão de data
		data.puzzleButton = GameManager.menu.transform.Find ("DataTab").Find ("Buttons").Find ("PuzzleButton").gameObject.activeSelf;//salvando se o jogador ja liberou o botão de informacoes dos quebra-cabecas
		Transform aux = GameManager.menu.keyFloor.Find ("Keys1").gameObject.transform;//salvando chaves ja utilizadas
		for (int i = 0; i < aux.childCount; i++) {
			if (aux.GetChild (i).gameObject.activeSelf) {
				data.usedKeys.Add (aux.GetChild(i).gameObject.name);
			}
		}
		aux = GameManager.menu.keyFloor.Find ("Keys2").gameObject.transform;//salvando chaves ja encontradas
		for (int i = 0; i < aux.childCount; i++) {
			if (aux.GetChild (i).gameObject.activeSelf) {
				data.foundKeys.Add (aux.GetChild (i).gameObject.name);
			}
		}
		Door[] doors = FindObjectsOfType<Door> ();//salvando portas ja destrancadas
		foreach(Door temp in doors){
			if (temp.hasKey && temp.isUnlocked()) {
				data.lockedDoors.Add (temp.code);
			}
		}
		DropItem[] dropitems = FindObjectsOfType<DropItem> ();//salvando itens ja coletados
		foreach (DropItem temp in dropitems) {
			if (!temp.canDrop) {
				data.cantDrop.Add (temp.name);
			}
		}
		Key[] keys = FindObjectsOfType<Key> ();//salvando chaves nao coletadas
		foreach (Key temp in keys) {
			data.notDestroyedKeys.Add (temp.name);
		}
		Informer[] informers = FindObjectsOfType<Informer> ();//salvando informacoes ja fornecidas
		foreach (Informer temp in informers) {
			if (!temp.isNew) {
				data.alreadyGivenInformation.Add (temp.name);
			}
		}
		Unlocker[] unlocked = FindObjectsOfType<Unlocker> ();//salvando upgrades ja obtidos
		foreach (Unlocker temp in unlocked) {
			if (temp.alreadyGive) {
				data.givenUpgrades.Add (temp.name);
			}
		}
		aux = GameManager.menu.transform.Find ("DataTab").Find ("PuzzleData").Find ("P1Tab").Find ("Infos").transform;//salvando informacoes ja obtidas
		for (int i = 0; i < aux.childCount; i++) {
			if (aux.GetChild (i).gameObject.activeSelf) {
				data.foundInformation.Add (aux.GetChild(i).GetChild(0).GetComponent<Text>().text);
			}
		}
		data.puzzleInformationCounter = GameManager.menu.transform.Find ("DataTab").Find ("PuzzleData").Find ("P1Tab").Find ("Counter").GetComponent<Text> ().text;//salvando o numero de informacoes ja obtidas

	}

	public void Load(){

		GameManager.player.codes = new List<int> (data.codes);//carregando lista de codigos do jogador
		GameManager.player.transform.position = data.startPosition;//carregando posicao so jogador
		GameManager.player.canTranslate = data.canTranslate;//carregando se jogador achou o tradutor
		GameManager.menu.transform.Find ("MainTab").Find ("Buttons").Find ("DataButton").gameObject.SetActive (data.dataButton);//carregando se o jogador ja liberou o botão de data
		GameManager.menu.transform.Find ("DataTab").Find ("Buttons").Find ("PuzzleButton").gameObject.SetActive (data.puzzleButton);//carregando se o jogador ja liberou o botão de informacoes dos quebra-cabecas
		Transform aux = GameManager.menu.keyFloor.Find ("Keys1").gameObject.transform;//carregando chaves ja utilizadas
		for (int i = 0; i < data.usedKeys.Count; i++) {
			GameObject temp = Instantiate(aux.GetChild(0).gameObject, aux);
			temp.name = data.usedKeys [i];
			temp.transform.GetChild(0).GetComponent<Text>().text = "K-" + data.usedKeys[i];
			temp.SetActive(true);
		}
		aux = GameManager.menu.keyFloor.Find ("Keys2").gameObject.transform;//carregando chaves ja encontradas
		for (int i = 0; i < data.foundKeys.Count; i++) {
			GameObject temp = Instantiate(aux.GetChild(0).gameObject, aux);
			temp.name = data.foundKeys [i];
			temp.transform.GetChild(0).GetComponent<Text>().text = "K-" + data.foundKeys[i];
			temp.SetActive(true);
		}
		Door[] doors = FindObjectsOfType<Door> ();//carregando portas ja destrancadas
		foreach (Door temp in doors) {
			if (temp.hasKey) {
				bool i = data.lockedDoors.Contains (temp.code);
				if (i) {
					temp.ToggleLock ();
				}
			}
		}
		DropItem[] dropitems = FindObjectsOfType<DropItem> ();//carregando itens ja coletados
		foreach (DropItem temp in dropitems) {
			if (data.cantDrop.Contains(temp.name)){
				temp.canDrop = false;
			}
		}
		Key[] keys = FindObjectsOfType<Key> ();//carregando chaves nao coletadas
		foreach (Key temp in keys) {
			if (!data.notDestroyedKeys.Contains (temp.name)) {
				Destroy (temp.gameObject);
			}
		}
		Informer[] informers = FindObjectsOfType<Informer> ();//carregando informacoes ja fornecidas
		foreach (Informer temp in informers) {
			if (data.alreadyGivenInformation.Contains (temp.name)) {
				temp.isNew = false;
			}
		}
		Unlocker[] unlocked = FindObjectsOfType<Unlocker> ();//carregando upgrades ja obtidos
		foreach (Unlocker temp in unlocked) {
			if (data.givenUpgrades.Contains (temp.name)) {
				temp.alreadyGive = true;
			}
		}
		aux = GameManager.menu.transform.Find ("DataTab").Find ("PuzzleData").Find ("P1Tab").Find ("Infos").transform;//carregando informacoes ja obtidas
		for (int i = 0; i < data.foundInformation.Count; i++) {
			GameObject temp = Instantiate(aux.GetChild(0).gameObject, aux);
			temp.transform.GetChild(0).GetComponent<Text>().text = data.foundInformation[i];
			temp.SetActive(true);
		}
		GameManager.menu.transform.Find ("DataTab").Find ("PuzzleData").Find ("P1Tab").Find ("Counter").GetComponent<Text> ().text = data.puzzleInformationCounter;//carregando o numero de informacoes ja obtidas

	}

	private string Encrypt(string text){
		char[] aux = new char[text.Length];
		string key = SystemInfo.deviceModel+SystemInfo.deviceName+SystemInfo.deviceType;
		for (int i = 0, j = 0; i < text.Length; i++, j = (j + 1) % key.Length)
			aux [i] = (char)(text [i] + key [j]);
		return new string(aux);
	}

	private string Decrypt(string text){
		char[] aux = new char[text.Length];
		string key = SystemInfo.deviceModel+SystemInfo.deviceName+SystemInfo.deviceType;
		for (int i = 0, j = 0; i < text.Length; i++, j = (j + 1) % key.Length)
			aux [i] = (char)(text [i] -key [j]);
		return new string(aux);
	}
	void Update () {
		string fp = Application.dataPath + path;
		if (Input.GetKeyDown (KeyCode.M)) {
			if (File.Exists (fp)) {
				string daj = File.ReadAllText (fp);
				if (encypt)
					daj = Decrypt (daj);
				Test.instance.data = JsonUtility.FromJson<Data> (daj);
				instance.Load ();
			} else
				Debug.Log ("File doesn't exist");
		} else if (Input.GetKeyDown (KeyCode.L)) {
			string daj = JsonUtility.ToJson (Test.instance.data);
			if (encypt)
				daj = Encrypt (daj);
			File.WriteAllText (fp,daj);
		}
	}

	/*	public static bool isSaved(){
		return saved;
	}*/
}