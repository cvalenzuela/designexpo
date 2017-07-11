using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Close : MonoBehaviour
{

    void Start()
    {
        GetComponent<Image>().enabled = false;
    }

    void OnSelect()
    {
        GetComponent<Image>().enabled = false;
        SendMessageUpwards("Close");
    }
}
