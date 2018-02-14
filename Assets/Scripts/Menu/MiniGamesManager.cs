using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamesManager : MonoBehaviour {

	public static MiniGamesManager instance = null;
	public int numberOfMinigames;
	private static bool[] vec;

	void Awake(){
		if (instance == null) {
			instance = this;
			vec = new bool[numberOfMinigames];
		} else if (instance != this){
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	void Start () {
		for (int i = 0; i < numberOfMinigames; i++)
			vec[i] = false;
	}

	public static void UnlockMiniGame(int n){
		try{
			vec[n] = true;
		}catch{
		}
	}

	public static bool IsLocked(int n){
		return vec [n];
	}
}
