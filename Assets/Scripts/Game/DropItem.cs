using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {

    public GameObject item;
    public Vector3 offset;
    public bool canDrop = true;

	public GameObject Drop() {
       if (canDrop) {
            GameObject temp = Instantiate(item);
            temp.transform.position = this.transform.position + offset;
            return temp;
       }
        return null;
    }
}
