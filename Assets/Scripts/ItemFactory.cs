using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFactory : MonoBehaviour{

    public GameObject itemPrefab;
    public GameObject mapItemPrefab;

    private static ItemFactory instance;

    public static ItemFactory Instance {
        get {
            if(instance == null) {
                instance = new GameObject().AddComponent<ItemFactory>();
            }
            return instance;
        }
    }

    private static int itemId=0;

	
    // Use this for initialization
	void Start () {

	}

    void Awake () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject createItem(float rarityMult = 1f){
        return createItem(determineBaseItem(), rarityMult);
    }

    public GameObject createItem(BaseItem baseItem, float rarityMult = 1f){
        GameObject item = null;
        try{
        BaseItem b = baseItem;
            Debug.Log(b);
        Item thisItem=null;
        switch(b) {
        case BaseItem.map:
                Debug.Log("in map");
            item = Instantiate(mapItemPrefab, new Vector2(0, 0), mapItemPrefab.transform.rotation);
            break;
        case BaseItem.material:
                Debug.Log("in matterials");
            item = Instantiate(itemPrefab, new Vector2(0, 0), itemPrefab.transform.rotation);          
            break;
        }

            thisItem = item.GetComponent<Item>();
        Rarity r = determineRarity(rarityMult);

        thisItem.init(item,r.ToString()+" "+b.ToString(), r, b);

        ++itemId;        
        }
        catch(System.ArgumentException ex){
            Debug.Log(ex.GetType().Name+": "+ex.Message);
        }
        return item;
    }

    private Rarity determineRarity(float multiplier){
        float proc = (UnityEngine.Random.Range(1, 100)*multiplier);

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
        return (BaseItem)Enum.GetValues(typeof(BaseItem)).GetValue(proc);
    }
}
