﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
    ,IPointerEnterHandler
    ,IPointerExitHandler
    ,IPointerClickHandler
{
    private GameObject infoPanel;
    private GameObject imagePanel;
    private GameObject root;
    public InvintoryController invController;

    private string itemName;
    private int maxPrefix;
    private int maxPostfix;
    private int vaule;
    private int level;
    private Rarity rarity;
    private BaseItem baseItem;

    void Start() {
        
    }

    void Awake(){

    }

    public void init(GameObject parentPanel, string name, Rarity rarity, BaseItem baseItem){
        
        //find our components
        this.root = parentPanel;
        infoPanel = parentPanel.transform.Find("InfoPanel").gameObject;
        imagePanel = parentPanel.transform.Find("ImagePanel").gameObject;
        this.invController = InvintoryController.Instance;


        if(infoPanel == null) {
            Debug.Log("infoPanel null");
        }
        if(imagePanel == null) {
            Debug.Log("imagePanel null");
        }

        this.ItemName = name;
        this.Rarity = rarity;
        this.BaseItem = baseItem;
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerEnter(PointerEventData eventData){

        Debug.Log("enterd: " + ItemName+" rarity: "+Rarity.ToString()+" base: "+BaseItem.ToString());


    }

    public void OnPointerExit(PointerEventData eventData){
        Debug.Log("exited: " + ItemName);
    }

    public void OnPointerClick(PointerEventData eventData){
        if(invController == null) {
            Debug.Log("invController is null");
        } else {
            invController.itemClicked(eventData, this);   
        }
                                 
    }

    public string ItemName {
        get {
            return itemName;
        }
        protected set {
            itemName = value;

            Text nameText = infoPanel.GetComponentInChildren<Text>();
            if(nameText != null) {
                nameText.text = itemName;
            } else {
                Debug.Log("failed it get infoPanel/text");
            }
        }
    }

    public void highlight(bool b){
        if(b) {//highlight
            root.GetComponent<Image>().color = UnityEngine.Color.red;
        } else {
            setRarityColor();
        }
    }

    public Rarity Rarity {
        get {
            return rarity;
        }
        protected set{
            rarity = value;
            setRarityColor();
        }
    }

    private void setRarityColor(){
        if(rarity == Rarity.rare) {
            root.GetComponent<Image>().color = UnityEngine.Color.yellow;
        } else if(rarity == Rarity.magic) {
            root.GetComponent<Image>().color = UnityEngine.Color.green;
        } else {
            root.GetComponent<Image>().color = UnityEngine.Color.grey;
        }
    }

    public virtual string getType(){
        return "Item";
    }

    public BaseItem BaseItem {
        get {
            return baseItem;
        }
        protected set{
            baseItem = value;
            if(baseItem == BaseItem.map) {
                imagePanel.GetComponent<Image>().color = UnityEngine.Color.red;
            } else if(baseItem == BaseItem.material) {
                imagePanel.GetComponent<Image>().color = UnityEngine.Color.blue;
            }
        }
    }
}
