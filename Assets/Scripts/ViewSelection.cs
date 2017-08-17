using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSelection : MonoBehaviour {

    private GameObject DataObj;

    private Data data;
    private GUIController guiController;

    // player stats
    private int curPlayer;

    // castle stats
    private Dictionary<string, string> curCastle;

    void Start()
    {
        DataObj = GameObject.Find("GUI Controller");
        data = DataObj.GetComponent<Data>();
        guiController = DataObj.GetComponent<GUIController>();

        curCastle = data.getEvent(guiController.getCurUnit().PathLocation);
        curPlayer = guiController.getPlayerNum();

        if ( (curCastle["house"] == "") || (curCastle["house"] == data.getPlayerAttribute(curPlayer, "house")))
        {
            gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
        }
    }
}
