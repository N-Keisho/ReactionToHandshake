using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelScript : MonoBehaviour
{
    SerialHandler serialHandler;
    TMP_InputField PortNumInput;
    TMP_InputField BaudRateInput;
    void Start()
    {

        serialHandler = GameObject.Find("SerialHandler").GetComponent<SerialHandler>();
        PortNumInput = GameObject.Find("PortNumInput").GetComponent<TMP_InputField>();
        BaudRateInput = GameObject.Find("BaudRateInput").GetComponent<TMP_InputField>();
        if (BaudRateInput == null)
        {
            Debug.Log("BaudRateInput is null");
        }
        PortNumInput.text = PlayerPrefs.GetString("PortName", "COM5");
        BaudRateInput.text = PlayerPrefs.GetInt("BaudRate", 9600).ToString();
    }

    public void PortNameChanged()
    {
        serialHandler.portName = PortNumInput.text;
        PlayerPrefs.SetString("PortName", PortNumInput.text);
    }

    public void BaudRateChanged()
    {
        serialHandler.baudRate = int.Parse(BaudRateInput.text);
        PlayerPrefs.SetInt("BaudRate", int.Parse(BaudRateInput.text));
    }
}
