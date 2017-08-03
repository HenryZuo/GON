using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventStart : MonoBehaviour {

  public Data data;

  private bool errorChecker(string err) {
    if (err == "falsePlayer" || err == "falseAttribute") {
      return true;
    }
    return false;
  }

  public void createEvent(int pathLocation) {
    //TODO: check if path location exists
    switch (pathLocation) {
    default:
      Debug.Log(data.setPlayerNumericAttribute (0, "wealth", -100));
      break;
    }
    Debug.Log("Wealth: " + data.getPlayerAttribute(0, "wealth"));
  }
}
