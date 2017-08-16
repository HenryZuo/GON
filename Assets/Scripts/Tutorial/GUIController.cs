using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    private GameObject DataObj;

    private PersistentGame persistentGame;
    
    void Start()
    {
        DataObj = GameObject.Find("DataObj");
        persistentGame = DataObj.GetComponent<PersistentGame>();
    }
    
	public void Move()
    {
        persistentGame.GUIMove();        
    }
    	
	public void endTurn()
	{
        persistentGame.GUIEndTurn();
	}
    
}
