using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrap : MonoBehaviour {

	public Spawner spawner;

	void Start(){

	}

	void OnTriggerEnter(Collider other){
		spawner.Spawn ();
	}
}
