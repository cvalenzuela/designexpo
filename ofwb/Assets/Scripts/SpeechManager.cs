using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
        keywords.Add("Clear All", () =>
        {
            // Call the OnReset method on every descendant object.
            //this.BroadcastMessage("OnSelect");
        });

        // Discover a book
        keywords.Add("Discover this Book", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the Discover method on the focused object.
                focusObject.SendMessage("Discover", SendMessageOptions.DontRequireReceiver);
            }
        });   

        // Goals of a book
        keywords.Add("My Goals", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the Goal method on the focused object.
                focusObject.SendMessage("Goals", SendMessageOptions.DontRequireReceiver);
            }   
        });


        // Notes of a book
        keywords.Add("Show my Notes", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the Notes method on the focused object.
                focusObject.SendMessage("Notes", SendMessageOptions.DontRequireReceiver);
            }
        });

        // Close a note from a book
        keywords.Add("Close This", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the OnDrop method on just the focused object.
                focusObject.SendMessage("Close", SendMessageOptions.DontRequireReceiver);
            }
        });

        // Stop a sound audio from a note
        keywords.Add("Stop This", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the OnDrop method on just the focused object.
                focusObject.SendMessage("Stop", SendMessageOptions.DontRequireReceiver);
            }
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}