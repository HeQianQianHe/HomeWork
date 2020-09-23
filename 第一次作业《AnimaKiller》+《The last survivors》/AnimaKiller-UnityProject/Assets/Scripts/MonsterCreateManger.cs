using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreateManger : MonoBehaviour
{
    public Transform[] monsterPrefabs;//存储要实例化生成的怪物
    public  GameObject knowMonster=null;//存储现在正在显示的怪物
    public int pos;//存储自己的位置信息，这个要和SaveLoadManger中的mcmArray数组序号一致，这样才能根据这个序号找到指定的怪物生成器

    void Start ()
    {
        StartCoroutine("WaitSmoeTimeToCreateMonster");//开启协程来过几秒钟之后创建怪物
        for (int i = 0; i < transform.childCount; i++)
        {
            monsterPrefabs[i] = transform.GetChild(i);
        }
    }

    IEnumerator WaitSmoeTimeToCreateMonster()//等几秒创建怪物，并且开启下一个协程来使得怪物过一会消失
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        CreateMonster();
        StartCoroutine("WaitSmoeTimeSelfCantSeeMonster");
    }

    IEnumerator WaitSmoeTimeSelfCantSeeMonster()//等几秒钟把怪物消失掉//启用上一个协程用来再次开启怪物创建
    {
        yield return new WaitForSeconds(Random.Range(2, 8));
        SelfCantSeeMonster();
        StartCoroutine("WaitSmoeTimeToCreateMonster");
    }

    public void CreateMonster()//随机选择一个怪物//将这个怪物设置显示，并且激活碰撞检测盒子
    {
        knowMonster = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)].gameObject;
        knowMonster.SetActive(true);
        knowMonster.GetComponent<BoxCollider>().enabled = true;
    }

    public void SelfCantSeeMonster()//将这个怪物的显示关闭，碰撞盒子也关闭，并且置空knowMonster
    {
        if(knowMonster != null)
        {
            knowMonster.GetComponent<BoxCollider>().enabled = false;
            knowMonster.SetActive(false);
            knowMonster = null;
        }        
    }

    public void BeiKill()//被ball击中的时候调用这个方法
    {
        if (knowMonster != null)
        {
            StopAllCoroutines();//停止所有协程
            SelfCantSeeMonster();//将这个怪物的显示关闭，碰撞盒子也关闭，并且置空knowMonster
            StartCoroutine("WaitSmoeTimeToCreateMonster");//开启等待一会创建新怪物的协程
        }
        
    }

    public void Clean()//用来将所有的怪物创造器重置，清空所有对象
    {
        StopAllCoroutines();
        SelfCantSeeMonster();
        StartCoroutine("WaitSmoeTimeToCreateMonster");
    }

    public void ActivateMonsterByType(int type)//根据type来显示某一个怪物//等几秒钟把怪物消失掉，进入新循环
    {
        StopAllCoroutines();
        knowMonster = monsterPrefabs[type].gameObject;
        knowMonster.SetActive(true);
        knowMonster.GetComponent<BoxCollider>().enabled = true;
        StartCoroutine("WaitSmoeTimeSelfCantSeeMonster");
    }
}
