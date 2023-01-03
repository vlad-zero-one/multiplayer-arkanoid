using UnityEngine;
using UnityEngine.UI;

public class Logger : MonoBehaviour
{
    [SerializeField] private Text logText;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Log(string message)
    {
        if (this == null || gameObject == null || logText == null) return;

        Debug.Log(message);

        logText.text += "\n";
        logText.text += message;
    }
}