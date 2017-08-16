using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private GameObject GUIControllerObj;
    private GUIController guiController;     //Public variable to store a reference to the player game object
    
    // Use this for initialization
    void Start()
    {
        GUIControllerObj = GameObject.Find("GUI Controller");
        guiController = GUIControllerObj.GetComponent<GUIController>();
        //transform.position = guiController.getCurUnit().transform.position + new Vector3(0, -10, -9);
        gameObject.GetComponent<Camera>().fieldOfView = 26;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        try
        {
            transform.position = guiController.getCurUnit().transform.position + new Vector3(0, -10, -9);
        }
        catch (System.NullReferenceException e)
        {
            Debug.Log("Error in CameraController.cs: " + e);
        }
    }
}