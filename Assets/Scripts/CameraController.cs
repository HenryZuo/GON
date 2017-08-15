using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private GameObject DataObj;
    private PersistentGame persistentGame;     //Public variable to store a reference to the player game object
    
    // Use this for initialization
    void Start()
    {
        DataObj = GameObject.Find("DataObj");
        persistentGame = DataObj.GetComponent<PersistentGame>();
        transform.position = persistentGame.getCurUnit().transform.position + new Vector3(0, -14, -36);
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        try
        {
            transform.position = persistentGame.getCurUnit().transform.position + new Vector3(0, -14, -36);
        }
        catch (System.NullReferenceException e)
        {
            Debug.Log("Error in CameraController.cs: " + e);
        }
    }
}