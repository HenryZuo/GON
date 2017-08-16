using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyUnits : MonoBehaviour
{

    //void Awake(){
    //	DontDestroyOnLoad (gameObject);
    //}
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
