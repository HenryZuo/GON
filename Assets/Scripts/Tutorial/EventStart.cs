using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventStart : MonoBehaviour {
    
  private Data data;
  private GUIController game;
  private TestModalWindow testModalWindow;

    void Start()
    {
        data = gameObject.GetComponent<Data>();
        game = gameObject.GetComponent<GUIController>();
        testModalWindow = gameObject.GetComponent<TestModalWindow>();
    }

  private bool errorChecker(string err) {
    if (err == "falsePlayer" || err == "falseAttribute") {
      return true;
    }
    return false;
  }

  private void handleEvent(Dictionary<string, string> incomingEvent) {
        switch (incomingEvent["type"])
        {
            case "random":
                var decidedEvent = data.getRandomEvent();
                int number = Random.Range(100, 400);
                var decidedEventArray = decidedEvent["events"].Split(',');
                var decidedEventName = decidedEventArray[Random.Range(0, decidedEventArray.Length)];
                if (decidedEvent["change"] == "positive")
                {
                    data.setPlayerNumericAttribute(game.getPlayerNum(), decidedEvent["name"], number);
                    testModalWindow.randomEventModal("Oh yes, " + decidedEventName + " You gained " + number + " " + decidedEvent["name"]);
                }
                else
                {
                    data.setPlayerNumericAttribute(game.getPlayerNum(), decidedEvent["name"], -number);
                    testModalWindow.randomEventModal("Oh no, " + decidedEventName + " You lost " + number + " " + decidedEvent["name"]);
                }
                break;
            case "castle":
                Invoke("goToCastle", game.getDiceRoll() * 0.2f);                
                break;
            default:
                Debug.Log("event type not available");
                return;
        }
  }

  public void createEvent(int pathLocation) {
    //TODO: check if path location exists
    handleEvent(data.getEvent(pathLocation));
    }

    public void goToCastle()
    {
        SceneManager.LoadScene(2);
    }
    
}
