using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour {

    public Button[] buttons;
    public GameObject[] splashes; //TODO: renam
    public GameController gameControl;
    public static NavigationController Instance;

    private bool firstInvClick = true;

    public void Start(){
        Instance = this;
    }

    public void Awake() {
        //clear all buttons
        foreach (GameObject g in splashes) {
            g.SetActive(false);
        }
            
        mainMenuClicked();
    }

    public void mainMenuClicked() {
        clearScreen();
        buttons[0].interactable = false;
        Debug.Log("we're on main menu");
    }

    public void invintoryClicked() {
        if(firstInvClick) {
            firstInvClick = false;
            gameControl.testInv();
        }
        clearScreen();
        buttons[1].interactable = false;
        Debug.Log("we're on invintory");
        splashes[0].SetActive(true);
    }

    private void clearScreen(){
        foreach (Button b in buttons) {
            b.interactable = true;
        }

        foreach (GameObject g in splashes) {
            g.SetActive(false);
        }
    }
}
