using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartGameScript : MonoBehaviour
{
    public Button start;

    void Start()
    {
        start.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1f;

    }


}
