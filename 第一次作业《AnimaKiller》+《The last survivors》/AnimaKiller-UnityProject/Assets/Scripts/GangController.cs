using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GangController : MonoBehaviour
{
    float timer = 0;
    Animator gangAnim;
    public GameObject bulletPrefabs;
    public Transform firePosition;
    public AudioSource audioSource;
    public AudioClip ac;
	void Start ()
    {
        gangAnim = GetComponent<Animator>();
       
    }


    void Update()
    {
        timer += Time.deltaTime;//计时器自增

        if (timer > 0.3f)//每个0.3秒就可以接受鼠标点击并且开枪
        {
            if (Input.GetMouseButtonDown(0))//鼠标按下，计时器归零，播放动画，创建ball并且施加一个力
            {
                timer = 0;
                gangAnim.SetInteger("fire", 1);
                GameObject Go=  Instantiate(bulletPrefabs, firePosition.position, Quaternion.identity);
                Go.GetComponent<Rigidbody>().AddForce(transform.forward *500);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            gangAnim.SetInteger("fire", 0);
            audioSource.PlayOneShot(ac);
        }

        if (Input.GetKeyDown(KeyCode.R))//换弹药的动作
        {
            gangAnim.SetInteger("reload", 1);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            gangAnim.SetInteger("reload", 0);
        }

        transform.eulerAngles = new Vector3(30 - 70 * (Input.mousePosition.y / Screen.height), -45+90*(Input.mousePosition.x / Screen.width),0);//eulerAngles是设置指定度数，Rotate是调用一次执行一次

    }




}
