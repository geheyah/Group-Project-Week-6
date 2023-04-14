using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MMButtonScript : MonoBehaviour
{
    public Button MM;

    void Start()
    {
        MM.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
