using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RandomEventPanel : MonoBehaviour
{

    public Text quote;
    public GameObject randomEventPanelObj;
    public Button closeButton;
    public GUIController guiController;

    private static RandomEventPanel randomEventPanel;

    public static RandomEventPanel Instance()
    {
        if (!randomEventPanel)
        {
            randomEventPanel = FindObjectOfType(typeof(RandomEventPanel)) as RandomEventPanel;
            if (!randomEventPanel)
            {
                Debug.LogError("There needs to be one active Modal Panel script on a GameObject in your scene.");
            }
        }
        return randomEventPanel;
    }
    

    public void Notification(string notificationText, UnityAction closeModalEvent)
    {
        randomEventPanelObj.SetActive(true);
        closeButton.onClick.RemoveAllListeners();
        closeButton.onClick.AddListener(CloseNotification);

        quote.text = notificationText;
        closeButton.gameObject.SetActive(true);
    }

    void CloseNotification()
    {
        randomEventPanelObj.SetActive(false);
        guiController.EndTurn();
    }
}
