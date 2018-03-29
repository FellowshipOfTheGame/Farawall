using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data{
	public Vector3 startPosition;
	public  List<string> foundKeys = new List<string> ();
	public  List<string> usedKeys = new List<string> ();
	public List<int> lockedDoors = new List<int> ();
	public  List<string> cantDrop = new List<string> ();
	public  List<string> notDestroyedKeys = new List<string> ();
	public  List<string> alreadyGivenInformation = new List<string> ();
	public  List<string> foundInformation = new List<string> ();
	public  List<string> givenUpgrades = new List<string>();
	public  List<int> codes;
	public string puzzleInformationCounter;
	public  bool canTranslate;
	public  bool dataButton;
	public  bool puzzleButton;
}
