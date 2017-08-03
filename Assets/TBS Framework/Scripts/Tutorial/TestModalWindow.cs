using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TestModalWindow : MonoBehaviour {

    private ModalPanel modalPanel;
    private DisplayManager displayManager;

    private UnityAction myYesAction;
    private UnityAction myNoAction;
    private UnityAction myCancelAction;

    void Awake()
    {
        modalPanel = ModalPanel.Instance();
        displayManager = DisplayManager.Instance();

        myYesAction = new UnityAction(TestYesFunction);
        myNoAction = new UnityAction(TestNoFunction);
        myCancelAction = new UnityAction(TestCancelFunction);
    }

    // Send to the Modal Panel to set up the Buttons and Functions to call
    public void TestYesNoCancel()
    {
        modalPanel.Choice("What is this? \n", myYesAction, myNoAction, myCancelAction);
    }

    // These are wrapped into UnityActions
    void TestYesFunction()
    {
        displayManager.DisplayMessage("Oh Yeah!");
    }

    void TestNoFunction()
    {
        displayManager.DisplayMessage("Oh No!");
    }

    void TestCancelFunction()
    {
        displayManager.DisplayMessage("Oh Canceled!");
    }
}
