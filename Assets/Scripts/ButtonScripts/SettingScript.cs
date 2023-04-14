using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingScript : MonoBehaviour
{
    public Button Settings;

    void Start()
    {
        Settings.onClick.AddListener(TaskOnClick);
    }

    private void Update()
    {
       
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Settings");
    }
}
