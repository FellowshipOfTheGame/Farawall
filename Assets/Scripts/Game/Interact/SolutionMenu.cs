using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolutionMenu : MonoBehaviour {

    public char[] obj;
    Dropdown[] drops;
    public int order;
    public string[] options;
	// Use this for initialization
	void Start () {
        drops = new Dropdown[obj.Length];
        for (int i = 0; i < obj.Length; i++) {
            obj[i] = '-';
            drops[i] = this.transform.GetChild(i).GetComponent<Dropdown>();

            List<Dropdown.OptionData> aux = new List<Dropdown.OptionData>();
            for (int j = 0; j < options.Length / obj.Length; j++) {
                Debug.Log(i * obj.Length + j);
                aux.Add(new Dropdown.OptionData(options[i * obj.Length + j]));
            }

            drops[i].AddOptions(aux);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeChar(int index) {
        obj[index] = drops[index].options[drops[index].value].text.ToCharArray()[0];
    }
}
