using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemPlace : MonoBehaviour {

    public static ItemPlace selected;
    public static string globalAnswer;
    Solutioner statue;
    public int index, type;
    public GameObject genMenu;
    ItemSelect menu = null;
    List<Dropdown.OptionData> aux;
    int value = -1;
    float offset;
    
    // Use this for initialization
    void Start () {
        statue = this.transform.parent.GetComponent<Solutioner>();
        aux = new List<Dropdown.OptionData>();
        offset = ((index % statue.places.Length) - (statue.places.Length - 1) / 2) * 50.0f;
	}
	
    public void setOp() {
        aux.Add(new Dropdown.OptionData("---"));
        foreach (ItemPuzzle ip in GameManager.instance.activedPuzzles[statue.puzzleId].itemList) {
            if (ip.info.type == type)
                aux.Add(new Dropdown.OptionData(ip.info.title));
        }
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void turnOn() {
        ItemPlace.selected = this;
        menu = Instantiate(genMenu, GameManager.instance.canvas.transform).GetComponent<ItemSelect>();
        menu.transform.position += offset * Vector3.right;
        menu.drop.AddOptions(aux);
        menu.place = this;
        if (value != -1)
            menu.drop.value = value;
    }

    public void turnOff(int dir, bool finish) {
        if (!finish) {
            int i = index % statue.places.Length + dir;
            if (i < 0) i = statue.places.Length - 1;
            if (i >= statue.places.Length) i = 0;
            statue.places[i].turnOn();
        }
        Destroy(menu.gameObject);
    }

    public void changeAnswer(Dropdown drop) {
        value = drop.value;
        ItemPlace.globalAnswer = ItemPlace.globalAnswer.Substring(0, index) + drop.value.ToString() + ItemPlace.globalAnswer.Substring(index + 1);
    }
}