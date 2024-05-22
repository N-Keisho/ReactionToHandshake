using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://qiita.com/Ninagawa123/items/f6595dcf788dd316be8a
// 上記をURL参考に作成
public class SerialReceive : MonoBehaviour
{
    
    public SerialHandler serialHandler;
    public int heart = 0;

  void Start()
    {
        //信号を受信したときに、そのメッセージの処理を行う
        serialHandler.OnDataReceived += OnDataReceived;
    }

    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
    {
        var data = message.Split(
                new string[] { "\n" }, System.StringSplitOptions.None);
        try
        {
            // Debug.Log(data[0]);//Unityのコンソールに受信データを表示
            heart = int.Parse(data[0]);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);//エラーを表示
        }
    }
}
