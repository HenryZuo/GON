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
        DontDestroyOnLoad(this.GetComponent<Unit>());
        if (FindObjectsOfType(GetType()).Length > 4)
        {
            Destroy(gameObject);
        }
    }
}
