using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyGame : MonoBehaviour
{
    public static DontDestroyGame instance = null;
    //void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}
    //void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);

    //    if (FindObjectsOfType(GetType()).Length > 1)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        { Destroy(gameObject); }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
}
