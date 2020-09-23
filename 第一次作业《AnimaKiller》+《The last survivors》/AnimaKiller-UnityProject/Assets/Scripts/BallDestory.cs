using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestory : MonoBehaviour
{


	void Start ()
    {
		
	}

	void Update ()//球过低时候自动销毁
    {
        if (gameObject.transform.position.y < -50)
        {
            Destroy(gameObject);   
        }
	}
}
