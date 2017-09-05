using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
    ,IPointerEnterHandler
    ,IPointerExitHandler
{

    private string itemName;
    private GameObject infoPanel;
    private GameObject imagePanel;
    private Rarity rarity;
    private BaseItem baseItem;

    void Start() {
        
    }

    public void init(GameObject root, string name, Rarity rarity, BaseItem baseItem){
        //find our components
        infoPanel = root.transform.Find("InfoPanel").gameObject;
        imagePanel = root.transform.Find("ImagePanel").gameObject;

        if(infoPanel == null) {
            Debug.Log("infoPanel null");
        }
        if(imagePanel == null) {
            Debug.Log("imagePanel null");
        }

        this.ItemName = name;
        this.rarity = rarity;
        this.baseItem = baseItem;
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

    public Rarity Rarity {
        get {
            return rarity;
        }
    }

    public BaseItem BaseItem {
        get {
            return baseItem;
        }
    }
}
