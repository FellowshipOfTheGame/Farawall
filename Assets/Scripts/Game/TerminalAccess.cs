using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerminalAccess : Interactable {

    public SpriteRenderer icon;
    public int index;
    void Start() {
        icon.color = Color.black;
    }

    void open() {
        icon.color = Color.black;
        SceneManager.LoadScene("TerminalAccess" + index, LoadSceneMode.Additive);
    }

    public override void Interact() {
        GameManager.mainCam.focusOnObject(this.transform);
        Invoke("open", 0.5f);
    }

    public override void Close() {
        GameManager.mainCam.focusOnObject(GameManager.player.transform);
        SceneManager.UnloadSceneAsync("TerminalAccess" + index);
        icon.color = Color.white;
    }

    public override void Near() {
        icon.color = Color.white;
    }

    public override void Away() {
        icon.color = Color.black;
    }
}
