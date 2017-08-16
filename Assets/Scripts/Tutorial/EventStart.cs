using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventStart : MonoBehaviour {
    
  private Data data;
    private PersistentGame game;
  private TestModalWindow testModalWindow;

    void Start()
    {
        data = gameObject.GetComponent<Data>();
        game = gameObject.GetComponent<PersistentGame>();

        testModalWindow = gameObject.GetComponent<TestModalWindow>();
    }

  private bool errorChecker(string err) {
    if (err == "falsePlayer" || err == "falseAttribute") {
      return true;
    }
    return false;
  }

  private void handleEvent(Dictionary<string, string> incomingEvent) {
        if (incomingEvent["type"] == "random")
        {
            string[] possibleEvents = incomingEvent["events"].Split(',');
            string decidedEvent = possibleEvents[Random.Range(0, possibleEvents.Length)];

            switch (incomingEvent["name"])
            {
                case "soldiers":
                    int number = Random.Range(100, 400);
                    if (incomingEvent["change"] == "positive")
                    {
                        data.setPlayerNumericAttribute(game.getCurUnit().PlayerNumber, incomingEvent["name"], number);
                        testModalWindow.randomEventModal("Oh yes, "+decidedEvent+" You gained "+number+" soldiers.");
                    }
                    else
                    {
                        data.setPlayerNumericAttribute(game.getCurUnit().PlayerNumber, incomingEvent["name"], -number);
                        testModalWindow.randomEventModal("Oh no, " + decidedEvent + " You lost " + number + " soldiers.");
                    }
                    break;
                default:
                    break;
            }
        }
        if (incomingEvent["type"] == "castle")
        {
            SceneManager.LoadScene(2);
        }
        }

  public void createEvent(int pathLocation) {
    //TODO: check if path location exists
    handleEvent(data.getEvent(pathLocation));
    }
}
