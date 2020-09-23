using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageShow : MonoBehaviour
{
    public static MessageShow _instance;//单例模式，可以让任何地方都可以访问到这个脚本并且调用这里面的方法

    private void Awake()
    {
        _instance = this;
    }

    void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}

    public void Show(string m)//显示信息的方法
    {
        GetComponent<Text>().text = m;
        Invoke("Fade", 3);

    }

    private void Fade()
    {
        GetComponent<Text>().text = "";
    }
}
