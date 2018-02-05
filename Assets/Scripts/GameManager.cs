using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]    GameObject[] cameras;
    public PlayerControl player;
    public GameObject menu;
    public GameObject gameOver;
    public bool paused = false;

    // Use this for initialization
    void Start () {
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowGameOver() {
        paused = true;
        gameOver.SetActive(true);
    }

    public void RotateCamera(int rot) {
        int i = 0, cont = 0;
        while(!cameras[i++].activeInHierarchy && cont++ < 4) {}
        if (cameras[i - 1].activeInHierarchy) {
            int previousI = i - 1;
            i = previousI + rot;
            if (i < 0)
                i += cameras.Length;

            if (i >= cameras.Length)
                i -= cameras.Length;

            cameras[i].SetActive(true);
            cameras[previousI].SetActive(false); Debug.Log(i + "," + previousI + "," + rot);
        }

    }
}
