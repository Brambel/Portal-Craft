using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InvintoryController : MonoBehaviour {

    public GameObject invintoryPanel;
    private ItemFactory itemFactory;

    private List<GameObject> items = new List<GameObject>();


	void Awake () {
        //get a copy of the ItemFactory script so it dosn't need to be public
        itemFactory = gameObject.AddComponent(typeof(ItemFactory)) as ItemFactory;

        //just for testing we'll add some items to their invintory
        for (int i = 0; i < 3; ++i) {
            items.Add(itemFactory.createItem());
            items[i].transform.SetPositionAndRotation(new Vector2(0, (-50 * i) + 190),Quaternion.identity);
            items[i].transform.SetParent(invintoryPanel.transform,false);

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
