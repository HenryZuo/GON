using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GUIController guiController;       //Public variable to store a reference to the player game object
    
    // Use this for initialization
    void Start()
    {

        // set the desired aspect ratio (the values in this example are
        // hard-coded for 16:9, but you could make them into public
        // variables instead so you can set them at design time)
        //float targetaspect = 16.0f / 9.0f;

        //// determine the game window's current aspect ratio
        //float windowaspect = (float)Screen.width / (float)Screen.height;

        //// current viewport height should be scaled by this amount
        //float scaleheight = windowaspect / targetaspect;

        //// obtain camera component so we can modify its viewport
        //Camera camera = GetComponent<Camera>();

        //// if scaled height is less than current height, add letterbox
        //if (scaleheight < 1.0f)
        //{
        //    Rect rect = camera.rect;

        //    rect.width = 1.0f;
        //    rect.height = scaleheight;
        //    rect.x = 0;
        //    rect.y = (1.0f - scaleheight) / 2.0f;

        //    camera.rect = rect;
        //}
        //else // add pillarbox
        //{
        //    float scalewidth = 1.0f / scaleheight;

        //    Rect rect = camera.rect;

        //    rect.width = scalewidth;
        //    rect.height = 1.0f;
        //    rect.x = (1.0f - scalewidth) / 2.0f;
        //    rect.y = 0;

        //    camera.rect = rect;
        //}
        transform.position = guiController.curUnit.transform.position + new Vector3(0, -14, -36);
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        try
        {
            transform.position = guiController.curUnit.transform.position + new Vector3(0, -14, -36);
        }
        catch (System.NullReferenceException e)
        {
            // do nothing here
        }
    }
}