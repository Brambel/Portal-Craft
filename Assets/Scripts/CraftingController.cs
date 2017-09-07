using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingController : MonoBehaviour {

    public static CraftingController Instance;

    private InvintoryController invControl;
    private ItemFactory itemFactory;
	// Use this for initialization
	void Start () {
        invControl = InvintoryController.Instance;
        itemFactory = ItemFactory.Instance;
	}

    void Awake(){
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void combinMaterials(Item a, Item b){
        Debug.Log("we crafted something!");
        invControl.removeItem(a);
        invControl.removeItem(b);
        invControl.addItem(itemFactory.createItem(BaseItem.map).GetComponent<Item>());
    }
}
