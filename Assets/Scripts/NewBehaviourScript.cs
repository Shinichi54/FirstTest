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
    private Button button;
    private Text btn_text;

    void Start()
    {
		//AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		//jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

		_input = new AndroidJavaObject("com.gg.unity_exchange.AndroidKeyboard");

        canvasTras = GameObject.Find("Canvas").transform;
        text = canvasTras.Find("Text").GetComponent<Text>();
        button = canvasTras.Find("Button").GetComponent<Button>();
        btn_text = button.transform.Find("Text").GetComponent<Text>();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        _input.Call("Open", btn_text.text, false);
    }

    public void OnCustomInputAction(string data)
    {
        // 删除Button的文字
        btn_text.text = "";
        text.text = data.ToString();

        // string content = data.ToString();
        // 此处发送消息 发送 content
        // sendmessage(content);
    }

    public void OnCustomInputActionBack(string data)
    {
        if(data.Length > 0)
        {
            // 设置Button的文字
            btn_text.text = data.ToString();
        }
    }
}