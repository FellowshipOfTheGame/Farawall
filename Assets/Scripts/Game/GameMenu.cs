using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu: MonoBehaviour {
    public GameObject menu;
    public GameObject map;
    private bool menuActive;
    private bool mapActive;


	// Use this for initialization
	void Start () {
        menuActive = false;
        mapActive = false;
        menu.SetActive(menuActive);
        map.SetActive(mapActive);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !mapActive)
        {
            menuActive = !menuActive;
            menu.SetActive(menuActive);
        }else if (Input.GetKeyDown(KeyCode.M) && !menuActive){
            mapActive = !mapActive;
            map.SetActive(mapActive);
        }
	}

    public void ResetGame() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void BackMenu() {
        SceneManager.LoadScene("Menu");
    }
}
