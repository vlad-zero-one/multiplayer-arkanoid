using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class Logger : MonoBehaviour
{
    [SerializeField] private Text logText;
    [SerializeField] private Button clear;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        clear.onClick.AsObservable().Subscribe(_ => Clear()).AddTo(this);
    }

    private void Clear()
    {
        if (this == null || gameObject == null || logText == null) return;

        logText.text = string.Empty;
    }

    public void Log<T>(T message)
    {
        if (this == null || gameObject == null || logText == null) return;

        Debug.Log(message.ToString());

        logText.text += message.ToString();
        logText.text += "\n";
    }
}