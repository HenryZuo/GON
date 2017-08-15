using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyUnit : MonoBehaviour
{

    //void Awake(){
    //	DontDestroyOnLoad (gameObject);
    //}
    void Awake()
    {
        DontDestroyOnLoad(this);

        Debug.Log("length in dont destroy unit: " + FindObjectsOfType(GetType()).Length);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
