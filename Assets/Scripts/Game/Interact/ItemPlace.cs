using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemPlace : MonoBehaviour {

    public static ItemPlace selected;
    public static string globalAnswer;
    Solutioner statue;
    public int index, type, localIndex;
    public SolutionMenu menu;
    public Dropdown drop;
    
    // Use this for initialization
    void Start () {
        statue = this.transform.parent.GetComponent<Solutioner>();
        menu.gameObject.SetActive(false);
        List<Dropdown.OptionData> aux = new List<Dropdown.OptionData>();
        foreach (ItemPuzzle ip in GameManager.activedPuzzles[statue.puzzleId].itemList) {
            if (ip.type == type)
                aux.Add(new Dropdown.OptionData(ip.title));
        }
        drop.AddOptions(aux);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void turnOn() {
        menu.gameObject.SetActive(true);
    }

    public void turnOff(int dir, bool finish) {
        if (finish) {
            statue.places[Mathf.Clamp(localIndex + dir, 0, statue.places.Length)].turnOn();
        }
        menu.gameObject.SetActive(false);
    }

    public void changeAnswer() {
        ItemPlace.globalAnswer = ItemPlace.globalAnswer.Substring(0, index) + drop.value.ToString() + ItemPlace.globalAnswer.Substring(index + 1);
    }
}