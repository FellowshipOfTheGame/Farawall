using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {
    GameManager gm;
    public GameObject mainTab;
    GameObject activeTab;
    GameObject activeData;

	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManager>() as GameManager;
        Reset();
	}
    public void Reset() {
        if (activeTab != null)
            activeTab.SetActive(false);

        mainTab.SetActive(true);
        activeTab = mainTab;
    }

    public void Resume() {
        gm.pausePlay();
    }

    public void ChangeScene(string scene) {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void Exit() {
        Application.Quit();
    }

    public void ChangeTab(GameObject tab) {
        activeTab.SetActive(false);
        tab.SetActive(true);
        activeTab = tab;
    }

    public void ChangeData(GameObject data) {
        if (activeData != null)
            activeData.SetActive(false);
        data.SetActive(true);
        activeData = data;
    }
}