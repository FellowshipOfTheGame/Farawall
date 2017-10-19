using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	Neith Player;
	public GameObject Enemy;
	public float startTime = 1f;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;

	void Start(){
		spawnPoints = GetComponentsInChildren<Transform> ();
		Player = FindObjectOfType<Neith> ();
		InvokeRepeating ("Spawn", startTime, spawnTime);
	}

	void Spawn(){
		if (Player.currentHealth () <= 0f)
			return;
		int spawnPointIndex = Random.Range (1, spawnPoints.Length);
		Instantiate (Enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
	}

}
