using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MinItemP : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    GameObject message;
    public static MinItemP dragged = null, target = null;
    Image myImage;
    Color myColor;

    // Use this for initialization
    void Start () {
        message = this.transform.GetChild(0).gameObject;
        myImage = this.GetComponent<Image>();
        myColor = myImage.color;
        myImage.color = Color.clear;
        message.SetActive(false);
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && message.activeInHierarchy && dragged == null) {
            dragged = this;
            myImage.raycastTarget = false;
        }

        if (dragged == this) {
            this.transform.position = Input.mousePosition;
            if (Input.GetMouseButtonUp(0)) {
                if (target != null) {
                    int newIndex = target.transform.GetSiblingIndex();
                    target.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
                    this.transform.SetSiblingIndex(newIndex);
                    target.myImage.color = Color.clear;
                    target = null;
                }
                dragged = null;
                myImage.raycastTarget = true;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (dragged != null) {
            target = this;
            myImage.color = myColor;
        }else
            message.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (dragged != null && target == this) {
            target = null;
            myImage.color = Color.clear;
        }else
            message.SetActive(false);
    }
}
