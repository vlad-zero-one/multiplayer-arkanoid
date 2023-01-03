using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DependencyInjection;

public class Logger : MonoBehaviour
{
    [SerializeField] private Text logText;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Log(string message)
    {
        Debug.Log(message);

        logText.text += "\n";
        logText.text += message;
    }
}
