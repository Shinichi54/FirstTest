using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    private AndroidJavaObject _input = null;
    private Transform canvasTras;
    private Text text;
    private Button btn;
    private InputField inputField;

    void Start()
    {
		//AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		//jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

		_input = new AndroidJavaObject("com.gg.unity_exchange.AndroidKeyboard");

        canvasTras = GameObject.Find("Canvas").transform;
        text = canvasTras.Find("Text").GetComponent<Text>();
        btn = canvasTras.Find("Button").GetComponent<Button>();
        inputField = canvasTras.Find("InputField").GetComponent<InputField>();

        _input.Call("Open", text.text, false);
    }

    void OnCustomInputAction(string data)
    {
        text.text = data.ToString();
    }
}