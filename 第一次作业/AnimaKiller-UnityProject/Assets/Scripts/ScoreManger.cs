using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManger : MonoBehaviour
{
    public int n = 0;
    public static ScoreManger _instance;//单例模式，这样可以在任何地方就能访问修改这个数值
    bool isDead = false;
    public GameObject ruyuPage;
    public GameObject gung;

    private void Awake()
    {
        _instance = this;//单例赋值
    }
    void Start ()
    {
		
	}

	void Update ()
    {
        GetComponent<Text>().text = "杀死： " + n; //刷新显示
        if (!isDead&&n>=10)
        {
            ruyuPage.SetActive(true);
            isDead = true;
            Cursor.visible = true;
            Destroy(gung);
        }
	}
}
