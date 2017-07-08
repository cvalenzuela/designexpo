using UnityEngine;
using UnityEngine.UI;

public class MoreInfo : MonoBehaviour
{

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        // On each Select gesture, toggle whether the user is in placing mode.
        Image[] images = GetComponentsInChildren<Image>();

        foreach(Image image in images)
        {
            image.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void showChildren()
    {

    }
}