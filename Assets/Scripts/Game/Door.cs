using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door: Interactable {
    GameManager gm;
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
        gm = FindObjectOfType<GameManager>() as GameManager;
        pivot = transform.Find("Pivot");
		distance = Vector3.Distance (startPosition.position, endPosition.position);
		unlocked = !hasKey;
        codePlaces[0].text = code.ToString();
        codePlaces[1].text = code.ToString();

        if (hasKey)
            setIcon(lockIcon);
        else
            setIcon(lockIcon);

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
        gm.mainCam.focusOnObject(this.transform);
		if (!inMovement) {
			startTime = Time.time;
            if (isOpen)
                closeDoor = true;
            else if (!hasKey || unlocked)
                openDoor = true;
            else if (hasKey && gm.player.haveKey(code))
                Unlock();

            inMovement = closeDoor || openDoor;
		}
	}

	public override void Close (){
        gm.mainCam.focusOnObject(gm.player.transform);
    }

    public override void Near() {
        if (Vector3.Distance(gm.player.transform.position, transform.position) < Vector3.Distance(gm.player.transform.position, pivot.position))
            pivot.localPosition = -pivot.localPosition;

        pivot.transform.LookAt(this.transform);
        if (unlocked)
            setColor(onColor);
        else if (gm.player.haveKey(code)) {
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
        openDoor = true;
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
}