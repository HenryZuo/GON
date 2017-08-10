using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventStart : MonoBehaviour {

  public Data data;
  public TestModalWindow testModalWindow;
  public GUIController game;

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
            Debug.Log(decidedEvent);

            switch (incomingEvent["name"])
            {
                case "soldiers":
                    int number = Random.Range(100, 400);
                    if (incomingEvent["change"] == "positive")
                    {
                        data.setPlayerNumericAttribute(game.curUnit.PlayerNumber, incomingEvent["name"], number);
                        testModalWindow.randomEventModal("Oh yes, "+decidedEvent+" You gained "+number+" soldiers.");
                    }
                    else
                    {
                        data.setPlayerNumericAttribute(game.curUnit.PlayerNumber, incomingEvent["name"], -number);
                        testModalWindow.randomEventModal("Oh no, " + decidedEvent + " You lost " + number + " soldiers.");
                    }
                    Debug.Log("current soldiers" + data.getPlayerAttribute(game.curUnit.PlayerNumber, "soldiers"));
                    break;
                default:
                    break;
            }
        }  
  }

  public void createEvent(int pathLocation) {
        //TODO: check if path location exists
    switch (pathLocation) {
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
        case 6:
            handleEvent(data.getEvent(pathLocation));
            break;
        default:
          testModalWindow.TestYesNoCancel();
          data.setPlayerNumericAttribute (0, "wealth", -100);
          break;
    }
    Debug.Log("Wealth: " + data.getPlayerAttribute(0, "wealth"));
  }
}
