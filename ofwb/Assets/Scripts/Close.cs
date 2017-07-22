using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Close : MonoBehaviour
{
    public Image note;

    void Start()
    {
        GetComponent<Image>().enabled = false;
    }

    void OnSelect()
    {
        GetComponent<Image>().enabled = false;
        note.SendMessage("Close");
    }
}
