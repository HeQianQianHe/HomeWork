using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MonsterISMe : MonoBehaviour
{
    public int type;//存储自己的怪物类型，这个要和MonsterCreateManger中的monsterPrefabs数组序号一致，这样才能根据这个序号生成相应的怪物

    void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.transform.gameObject.tag == "ball")
        {
            GetComponent<Animator>().SetInteger("animation",8);
            Invoke("DestroyThis", 2);
            Destroy(collision.collider.transform.gameObject);//销毁球
            ScoreManger._instance.n++;//加分
        }
    }

    void DestroyThis()
    {
        GetComponent<Animator>().SetInteger("animation", 0);
        gameObject.GetComponentInParent<MonsterCreateManger>().BeiKill();//把这个怪物置空
    }
}
