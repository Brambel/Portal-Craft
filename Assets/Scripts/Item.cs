using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
    ,IPointerEnterHandler
    ,IPointerExitHandler
{

    private string name;
    private GameObject root;
    private GameObject infoPanel;
    private GameObject imagePanel;

    void Start() {
        
    }

    public void init(GameObject root, string name){
        this.root = root;

        //find our components
        infoPanel = root.transform.Find("InfoPanel").gameObject;
        imagePanel = root.transform.Find("ImagePanel").gameObject;

        if(infoPanel == null) {
            Debug.Log("infoPanel null");
        }
        if(imagePanel == null) {
            Debug.Log("imagePanel null");
        }
        this.Name = name;
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerEnter(PointerEventData eventData){

        Debug.Log("enterd: " + Name+" EventData: "+eventData);

    }

    public void OnPointerExit(PointerEventData eventData){
        Debug.Log("exited: " + Name+" EventData: "+eventData);
    }

    public string Name {
        get {
            return name;
        }
        protected set {
            name = value;

            Text nameText = infoPanel.GetComponentInChildren<Text>();
            if(nameText != null) {
                nameText.text = name;
            } else {
                Debug.Log("failed it get infoPanel/text");
            }
        }
    }

}
