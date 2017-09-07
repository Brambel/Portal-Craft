using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

    public static MapController Instance;

    private ItemFactory itemFactory;

	// Use this for initialization
	void Start () {
        itemFactory = ItemFactory.Instance;
	}
	
    void Awake(){
        
        Instance = this;
        Debug.Log("mapController singelton created");
    }

	// Update is called once per frame
	void Update () {
		
	}

    public List<Item> createMapLoot(Item map){
        int count=0;
        float multiplier=1f;
        List<Item> loot = new List<Item>();

        if(map.BaseItem == BaseItem.map) {
            
            switch(map.Rarity) {
            case Rarity.rare:
                count = 2;
                multiplier = 2f;
                break;
            case Rarity.magic:
                count = 2;
                multiplier = 1.5f;
                break;

            case Rarity.common:
                count = 1;
                multiplier = 1f;
                break;   
            }
        }

        for (int i = 0; i < count; ++i) {
            loot.Add(itemFactory.createItem(multiplier).GetComponent<Item>());
        }

        return loot;
    }
}
