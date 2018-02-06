using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateUnlocker : Interactable {

    GameManager GM;
    public Door door;
    Transform pivot;
    public float camDist, camHeight;

    // Use this for initialization
    void Start() {
        GM = FindObjectOfType<GameManager>() as GameManager;
        this.transform.Find("Eye").gameObject.SetActive(false);
        pivot = transform.Find("Pivot");
    }

    // Update is called once per frame
    void Update() {
        if (nearPlayer) {
            this.transform.Find("Eye").Rotate(0.0f, 10.0f * Time.deltaTime, 0.0f);
        }
    }

    public override void Interact() {
        GM.mainCam.focusOnObject(this.transform);
        Debug.Log("Now you can understand the statues...");
        GM.player.canTranslate = true;
    }

    public override void Close() {
        GM.mainCam.focusOnObject(GM.player.transform); /*
        GameObject temp = this.GetComponent<DropItem>().Drop();
        if (temp != null) {
            temp.GetComponent<Key>().door = this.door;
            this.GetComponent<DropItem>().canDrop = false;
        } */
    }

    public override void Near() {
        Vector3 dist = (GM.player.transform.position - transform.position).normalized * camDist;
        pivot.position = transform.position + new Vector3(dist.x, camHeight, dist.z);
        float aux = pivot.eulerAngles.x;
        pivot.transform.LookAt(this.transform);
        pivot.eulerAngles = new Vector3(aux, pivot.eulerAngles.y, pivot.eulerAngles.z);

        this.transform.Find("Eye").gameObject.SetActive(true);
        nearPlayer = true;
    }

    public override void Away() {
        this.transform.Find("Eye").gameObject.SetActive(false);
        nearPlayer = false;
    }
}
