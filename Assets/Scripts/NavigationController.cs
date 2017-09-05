using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour {

    public Button[] buttons;


    public void Start() {
        
    }

    public void mainMenuClicked() {
        clearButtons();
        buttons[0].interactable = false;
        Debug.Log("we're on main menu");
    }

    public void invintoryClicked() {
        clearButtons();
        buttons[1].interactable = false;
        Debug.Log("we're on invintory");
    }

    private void clearButtons(){
        foreach (Button b in buttons) {
            b.interactable = true;
        }
    }
}
