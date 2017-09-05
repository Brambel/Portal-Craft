using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InvintoryController : MonoBehaviour {

    public GameObject item;
    public GameObject invintoryPanel;

    private List<GameObject> items = new List<GameObject>();

	void Awake () {
        for (int i = 0; i < 3; ++i) {
            items.Add(Instantiate(item, new Vector2(0, (-50 * i)+190),item.transform.rotation));
            Debug.Log(items[i]);
            Item thisItem = items[i].GetComponent<Item>();
            thisItem.init(items[i],"Item "+i);
            items[i].transform.SetParent(invintoryPanel.transform,false);

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
