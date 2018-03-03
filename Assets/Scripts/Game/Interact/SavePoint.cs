using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : Interactable{

	private GameManager gm;

	void Start(){
		gm = GameManager.instance;
		isItem = false;
	}

	public override void Interact ()
	{
		gm.mainCam.focusOnObject (this.transform);
		DataStorage.Save ();
	}

	public override void Close ()
	{
		gm.mainCam.focusOnObject (gm.player.transform);
	}

	public override void Near(){
		nearPlayer = true;
	}

	public override void Away ()
	{
		nearPlayer = false;
	}
}
