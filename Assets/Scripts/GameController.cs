using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public NavigationController navControl;
    public InvintoryController invControl;
    public CraftingController craftControl;
    public MapController mapControl;

    public void testInv(){ //temporary test method
        invControl.freeItems();
    }
}
