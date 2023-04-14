using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseGameScript : MonoBehaviour
{
    public Button Close;

    void Start()
    {
        Close.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
