using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinItemP : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    GameObject message;

    // Use this for initialization
    void Start () {
        message = this.transform.GetChild(0).gameObject;
        message.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        message.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) {
        message.SetActive(false);
    }
}
