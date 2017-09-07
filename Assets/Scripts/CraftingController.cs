using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingController : MonoBehaviour {

    public static CraftingController Instance;
	// Use this for initialization
	void Start () {
        
	}

    void Awake(){
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
