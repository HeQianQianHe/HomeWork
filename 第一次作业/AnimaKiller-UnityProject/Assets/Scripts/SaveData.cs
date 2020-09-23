using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]//必须要加这个属性，这样这个类的对象才能被序列化（二进制存储）
public class SaveData 
{

    public List<int> positionList =new List<int>();
    public List<int> typeList = new List<int>();
    public int score;


}
