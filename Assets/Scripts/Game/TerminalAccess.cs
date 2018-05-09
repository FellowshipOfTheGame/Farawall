using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerminalAccess : Interactable {

    SpriteRenderer icon;
    public Sprite onSpr, offSpr;
    public int index;
    public List<ForceFieldTrap> forceFields;
    bool activated = true;

    void Start() {
        icon = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        icon.sprite = offSpr;
    }

    void open() {
        icon.sprite = offSpr;
        SceneManager.LoadScene("TerminalAccess" + index, LoadSceneMode.Additive);
    }

    public void endAccess() {
        Close();
        activated = false;
        foreach (ForceFieldTrap ff in forceFields) ff.activated = false;
        GameManager.player.unlock();
    }

    public override void Interact() {
        if (activated) {
            GameManager.mainCam.focusOnObject(this.transform);
            GameManager.activedTerminal = this;
            Invoke("open", 10 * Time.deltaTime);
        }
    }

    public override void Close() {
        if (activated) {
            GameManager.mainCam.focusOnObject(GameManager.player.transform);
            GameManager.activedTerminal = null;
            SceneManager.UnloadSceneAsync("TerminalAccess" + index);
            icon.sprite = onSpr;
        }
    }

    public override void Near() {
        if (activated)
            icon.sprite = onSpr;
    }

    public override void Away() {
        if (activated)
            icon.sprite = offSpr;
    }
}
