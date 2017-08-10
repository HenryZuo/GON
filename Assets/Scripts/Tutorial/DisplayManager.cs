using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayManager : MonoBehaviour
{

    public Text displayText;
    public Text diceText;

    public float displayTime;
    public float fadeTime;

    private IEnumerator fadeAlpha;

    private static DisplayManager displayManager;

    public static DisplayManager Instance()
    {
        if (!displayManager)
        {
            displayManager = FindObjectOfType(typeof(DisplayManager)) as DisplayManager;
            if (!displayManager)
                Debug.LogError("There needs to be one active DisplayManager script on a GameObject in your scene.");
        }

        return displayManager;
    }

    public void DisplayMessage(string message)
    {
        displayText.text = message;
        SetAlpha();
    }

    public void DisplayDiceRoll(string message)
    {
        diceText.text = message;
        SetAlpha();
    }

    void SetAlpha()
    {
        if (fadeAlpha != null)
        {
            StopCoroutine(fadeAlpha);
        }
        fadeAlpha = FadeAlpha();
        StartCoroutine(fadeAlpha);
    }

    IEnumerator FadeAlpha()
    {
        //Color resetColor = displayText.color;
        //resetColor.a = 1;
        //displayText.color = resetColor;

        //yield return new WaitForSeconds(displayTime);

        //while (displayText.color.a > 0)
        //{
        //    Color displayColor = displayText.color;
        //    displayColor.a -= Time.deltaTime / fadeTime;
        //    displayText.color = displayColor;
        //    yield return null;
        //}
        //yield return null;

        // --dice roll--
        Color resetColor1 = diceText.color;
        resetColor1.a = 1;
        diceText.color = resetColor1;

        yield return new WaitForSeconds(displayTime);

        while (diceText.color.a > 0)
        {
            Color displayColor = diceText.color;
            displayColor.a -= Time.deltaTime / fadeTime;
            diceText.color = displayColor;
            yield return null;
        }
        yield return null;
        // --dice roll--
    }
}