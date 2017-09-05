using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFactory : MonoBehaviour{

    public GameObject itemPrefab;

    private static int itemId=0;
	
    // Use this for initialization
	void Start () {

	}

    void Awake () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject createItem(int rarityMult = 1){
        if(itemPrefab == null) {
            Debug.Log("item null");
        }
        GameObject item = Instantiate(itemPrefab, new Vector2(0, 0), itemPrefab.transform.rotation);
        Item thisItem = item.GetComponent<Item>();
        thisItem.init(item,"Item "+itemId, determineRarity(rarityMult), determineBaseItem());

        ++itemId;
        return item;
    }

    private Rarity determineRarity(int multiplier){
        int proc = (UnityEngine.Random.Range(1, 100)*multiplier);

        if(proc > 90) {
            return Rarity.rare;
        } else if(proc > 50) {
            return Rarity.magic;
        } else {
            return Rarity.common;
        }

    }

    private BaseItem determineBaseItem(){
        
        int proc = UnityEngine.Random.Range(0, Enum.GetValues(typeof(BaseItem)).Length);
        return (BaseItem) Enum.GetValues(typeof(BaseItem)).GetValue(proc);
    }
}
