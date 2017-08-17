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

    void Awake()
    {
        DataObj = GameObject.Find("GUI Controller");
        data = DataObj.GetComponent<Data>();
        guiController = DataObj.GetComponent<GUIController>();

        curCastle = data.getEvent(guiController.getCurUnit().PathLocation);
        curPlayer = guiController.getPlayerNum();

        if ( (curCastle["owner"] == "") || (curCastle["owner"] == data.getPlayerAttribute(curPlayer, "house")))
        {
            transform.Find("OwnCastleContainer").gameObject.SetActive(true);
        } else
        {
            transform.Find("EnemyCastleContainer").gameObject.SetActive(true);
        }        
    }
}
