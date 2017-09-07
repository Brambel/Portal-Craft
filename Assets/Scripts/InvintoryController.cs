using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InvintoryController : MonoBehaviour {

    public GameObject invintoryPanel;
    public GameController gameControl;
    public MapController mapControl;
    public static InvintoryController Instance; //singelton call

    private ItemFactory itemFactory;
    private invintoryList items;

    private class invintoryList{

        private int count;
        private int max;
        private List<GameObject> items;
        private GameObject invPanel;

        public invintoryList(int max, GameObject invPanel){
            count =0;
            this.max = max;
            items = new List<GameObject>();
            this.invPanel = invPanel;
        }

        public bool addItem(GameObject gmObj){
            if(count < max) {
                count++;
                items.Add(gmObj);
                reorder();
                return true;
            }
            //Debug.Log("item didn't add");
            return false;
        }

        public bool removeItem(GameObject gmObj){
            if(items.Remove(gmObj)) {
                --count;

                Destroy(gmObj);
                //Debug.Log("item destroyed");
                reorder();
                return true;
            }
            Debug.Log("didn't find item, count: "+count);
            return false;
        }


        public GameObject getItem(int i){
            return items[i];
        }

        public int getCount(){
            return count;
        }

        public int getMax(){
            return max;
        }

        private void reorder(){
            for (int i = 0; i < items.Count; ++i) {
                items[i].transform.SetParent(invPanel.transform, false);
                items[i].transform.transform.localPosition=new Vector2(-20, (-50 * i)-30);
            }
        }
    }

    void Start(){
        mapControl = MapController.Instance;
        items = new invintoryList(8, invintoryPanel);  //currently all we have space for
    }

	void Awake () {
        Instance = this;
        //all factories are singeltons
        itemFactory = ItemFactory.Instance;

         
	}
	
    public void freeItems(){
        //just for testing we'll add some items to their invintory
        for (int i = 0; i < Random.Range(4, 8); ++i) {
            if(items.addItem(itemFactory.createItem())) {
                
            } else {
                break;
            }

        }
    }

    public void itemClicked(PointerEventData eventData, Item item){
        string msg = "clicked: " + item.ItemName;
        Debug.Log("items.count: " + items.getCount());
        if(item.BaseItem == BaseItem.map) {
            msg += " poof, rain items";
            List<Item> loot = mapControl.createMapLoot(item);
            items.removeItem(item.gameObject);
            foreach (Item i in loot) {
                items.addItem(i.gameObject);
            }
        } else if(item.BaseItem == BaseItem.material) {
            msg += " touching stuff";
        } else {
            msg += " ERROR non matching base type";
        }

        Debug.Log(msg);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
