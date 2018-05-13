using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleInfo : MonoBehaviour {
    public int id;
    public GameObject tab;
    Transform infoTab, itemTab;
    public string intro, answer;
    public StatueControl[] statues, solutions;
    public Inquisitor finalStatue;
    public ItemPuzzle[] itemList;
    public Door startDoor, endDoor;
    public List<string> infos;
    public List<MinItemP> items;
    GameObject genInfo;
    Text counter;

	// Use this for initialization
	void Start () {
        infos = new List<string>();
        infoTab = tab.transform.Find("Infos");
        genInfo = infoTab.GetChild(0).gameObject;
        counter = tab.transform.Find("Counter").GetComponent<Text>();
        counter.text = "infos. 0/" + statues.Length;
        items = new List<MinItemP>();
    }

    public void AddInfo(string info) {
        GameObject temp = Instantiate(genInfo, infoTab);
        temp.transform.GetChild(0).GetComponent<Text>().text = info;
        temp.SetActive(true);
        infos.Add(info);
        counter.text = "infos. " + infos.Count + "/" + statues.Length;
    }

    public void AddItem(ItemPuzzle item) {
        Debug.Log("PegouItem");
    }

    public bool isFull() {
        return infos.Count == statues.Length;
    }

    public bool checkAnswer(string answer) {
        return this.answer == answer;
    }
}