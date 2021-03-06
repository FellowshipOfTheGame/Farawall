﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door: Interactable {
    Transform pivot;
    public float camDistance;
	public Transform startPosition;
	public Transform endPosition;
	public Transform door;
    [Space(10)]
    public int code;
	public bool hasKey;
	public float speed;
	private float startTime;
    [Space(10)]
    public Sprite normalIcon;
    public Sprite lockIcon, unlockIcon;
    public Color offColor, onColor, lockColor, unlockColor;
    public TextMesh[] codePlaces;
    public SpriteRenderer[] iconPlaces;

	private float distance;
	private bool isOpen = false;
	private bool openDoor = false;
	private bool closeDoor = false;
	private bool inMovement = false;
	private bool unlocked;

	void Start () {
        pivot = transform.Find("Pivot");
		distance = Vector3.Distance (startPosition.position, endPosition.position);
		unlocked = !hasKey;
        codePlaces[0].text = code.ToString();
        codePlaces[1].text = code.ToString();

        if (hasKey)
            setIcon(lockIcon);
        else
            setIcon(normalIcon);

        setColor(offColor);
    }

	void Update () {
		float coveredDistance;
		float currentPosition;
		if (openDoor) {
			coveredDistance = (Time.time - startTime) * speed;
			currentPosition = coveredDistance / distance;
			door.position = Vector3.Lerp (startPosition.position, endPosition.position, currentPosition);
			if (door.position == endPosition.position) {
				isOpen = true;
				openDoor = false;
				inMovement = false;
			}
		} else if (closeDoor) {
            if (iconPlaces[0].sprite == unlockIcon) 
                setIcon(normalIcon);

			coveredDistance = (Time.time - startTime) * speed;
			currentPosition = coveredDistance / distance;
			door.position = Vector3.Lerp (endPosition.position, startPosition.position, currentPosition);
			if (door.position == startPosition.position) {
				isOpen = false;
				closeDoor = false;
				inMovement = false;
			}
		}
	}

	public override void Interact (){
		GameManager.mainCam.focusOnObject(this.transform);
		if (!inMovement) {
			startTime = Time.time;
            if (isOpen)
                closeDoor = true;
            else if (!hasKey || unlocked)
                openDoor = true;
			else if (hasKey && GameManager.player.haveKey(code))
                Unlock();

            inMovement = closeDoor || openDoor;
		}
	}

	public override void Close (){
		GameManager.mainCam.focusOnObject(GameManager.player.transform);
    }

    public override void Near() {
		if (Vector3.Distance(GameManager.player.transform.position, transform.position) < Vector3.Distance(GameManager.player.transform.position, pivot.position)) {
            pivot.localPosition = -pivot.localPosition;
            pivot.Rotate(Vector3.up, 180.0f);
        }

        if (unlocked)
            setColor(onColor);
		else if (GameManager.player.haveKey(code)) {
            setColor(unlockColor);
            setIcon(unlockIcon);
        } else
            setColor(lockColor);
        
        nearPlayer = true;
	}

    public override void Away() {
        nearPlayer = false;
        if (isOpen) {
            startTime = Time.time;
            closeDoor = true;
            inMovement = true;
        }
        if (!unlocked)
            setIcon(lockIcon);

        setColor(offColor);
    }

	public void Unlock(){
		unlocked = true;
		Destroy(GameManager.menu.keyFloor.Find("Keys2").Find(code.ToString()).gameObject);
		GameObject temp = Instantiate(GameManager.menu.keyFloor.Find("Keys1").GetChild(0).gameObject, GameManager.menu.keyFloor.Find("Keys1"));
        temp.name = code.ToString();
        temp.transform.GetChild(0).GetComponent<Text>().text = "K-" + code.ToString();
        temp.SetActive(true);
        openDoor = true;
    }

	public void ToggleLock(){
		unlocked = !unlocked;
		if (unlocked == false) {
			try{
				GameManager.player.removeKey (code);
			}catch{
			}
		}
		setIcon (unlocked?normalIcon:lockIcon);
	}

    void setColor(Color c) {
        iconPlaces[0].color = c;
        iconPlaces[1].color = c;
        codePlaces[0].color = c;
        codePlaces[1].color = c;
    }

    void setIcon(Sprite s) {
        iconPlaces[0].sprite = s;
        iconPlaces[1].sprite = s;
    }

	public bool isUnlocked(){
		return unlocked;
	}
}