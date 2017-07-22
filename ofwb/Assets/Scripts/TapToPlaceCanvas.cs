using UnityEngine;
using UnityEngine.UI;

public class TapToPlaceCanvas : MonoBehaviour
{
    bool placing = false;
    public bool selected = false;
    public Image discover;
    public Image goal;
    public Image notes;

    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Called by DefaultTrackableEvent
    void Tracked()
    {
        GetComponent<Canvas>().enabled = true;
    }

    void NotTracked()
    {
        if (!selected)
        {
            GetComponent<Canvas>().enabled = false;
        }
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        // On each Select gesture, toggle whether the user is in placing mode.
        placing = !placing;
        // If the user is in placing mode, display the spatial mapping mesh.
        if (placing)
        {
            // If the object is selected change its property of selection
            selected = true;
            //SpatialMapping.Instance.DrawVisualMeshes = true;
        }
        // If the user is not in placing mode, hide the spatial mapping mesh.
        else
        {
            //SpatialMapping.Instance.DrawVisualMeshes = false;
        }
    }

    // Discover: Called by the Speech Manager
    void Discover()
    {
        if (selected)
        {
            discover.enabled = true;
            discover.SendMessage("goToDefaultPosition");

            //Play the audio for that discover
            AudioSource discoverAudio = discover.GetComponent<AudioSource>();
            discoverAudio.Play();

            Image[] images = discover.GetComponentsInChildren<Image>();

            foreach (Image image  in images)
            {
                image.enabled = true;
            }
        }
    }

    // Goal: Called by the Speech Manager
    void Goals()
    {
        if (selected)
        {
            goal.enabled = true;
            goal.SendMessage("goToDefaultPosition");

            Image[] images = goal.GetComponentsInChildren<Image>();

            foreach (Image image in images)
            {
                image.enabled = true;
            }
        }
    }

    // Notes: Called by the Speech Manager
    void Notes()
    {
        if (selected)
        {
            notes.enabled = true;
            notes.SendMessage("goToDefaultPosition");

            Image[] images = notes.GetComponentsInChildren<Image>();

            foreach (Image image in images)
            {
                image.enabled = true;
            }
        }
    }

    // Close the book, called by the Speech Manager
    void Close()
    {
        if (selected)
        {   
            // Disable all children notes
            notes.enabled = false;
            Image[] noteImages = notes.GetComponentsInChildren<Image>();

            foreach (Image image in noteImages)
            {
                image.enabled = false;
            }

            goal.enabled = false;
            Image[] goalImages = goal.GetComponentsInChildren<Image>();

            foreach (Image image in goalImages)
            {
                image.enabled = false;
            }

            discover.enabled = false;
            Image[] discoverImages = discover.GetComponentsInChildren<Image>();

            foreach (Image image in discoverImages)
            {
                image.enabled = false;
            }

            // Disable this canvas
            GetComponent<Canvas>().enabled = false;
            selected = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the user is in placing mode,
        // update the placement to match the user's gaze.

        if (placing)
        {
            // Do a raycast into the world that will only hit the Spatial Mapping mesh.
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo,
                30.0f, SpatialMapping.PhysicsRaycastMask))
            {
                // Move this object to
                // where the raycast hit the Spatial Mapping mesh.
                this.transform.position = hitInfo.point;

                // Rotate this object to face the user.
                Quaternion toQuat = Camera.main.transform.localRotation;
                toQuat.x = 0;
                toQuat.z = 0;
                this.transform.rotation = toQuat;
            }
        }
    }
}