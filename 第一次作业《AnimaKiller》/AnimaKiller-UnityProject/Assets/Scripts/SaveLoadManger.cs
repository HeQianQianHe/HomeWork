
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using LitJson;


public class SaveLoadManger : MonoBehaviour
{
    public MonsterCreateManger[] mcmArray;//存储所有的怪物生成器


    public void SaveByBin()//二进制存储信息的方法
    {
        SaveData sd = CreateSaveObject();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.dataPath + "/SaveDataFile" + "/byBin.txt");
        bf.Serialize(fs, sd);
        fs.Close();
        if(File.Exists(Application.dataPath + "/SaveDataFile" + "/byBin.txt"))
        {
            MessageShow._instance.Show("保存成功！");
        }
    }

    public void SaveByJson()//Json存储信息的方法
    {
        SaveData sd = CreateSaveObject();
        string filePath = Application.dataPath + "/SaveDataFile" + "/byJson.json";
        string saveJsonStr = JsonMapper.ToJson(sd);
        StreamWriter sw = new StreamWriter(filePath);
        sw.Write(saveJsonStr);
        sw.Close();
        if (File.Exists(Application.dataPath + "/SaveDataFile" + "/byJson.json"))
        {
            MessageShow._instance.Show("保存成功！");
        }
    }

    public void LoadByJson()
    {
        if (File.Exists(Application.dataPath + "/SaveDataFile" + "/byJson.json"))
        {
            string filePath = Application.dataPath + "/SaveDataFile" + "/byJson.json";
            StreamReader sr = new StreamReader(filePath);
            string jsonStr = sr.ReadToEnd();
            sr.Close();
            SaveData sd = JsonMapper.ToObject<SaveData>(jsonStr);
            SetGame(sd);
        }
        else
        {
            MessageShow._instance.Show("你就没存档！");
        }
    }

    public void LoadByBin()//二进制读取信息的方法
    {
        if (File.Exists(Application.dataPath + "/SaveDataFile" + "/byBin.txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.dataPath + "/SaveDataFile" + "/byBin.txt", FileMode.Open);
            SaveData sd = (SaveData)bf.Deserialize(fs);
            SetGame(sd);
        }
        else
        {
            MessageShow._instance.Show("你就没存档！");
        }
    }

    SaveData CreateSaveObject()//将信息打包到一个类的对象里
    {
        SaveData S = new SaveData();
        S.score = ScoreManger._instance.n;
        foreach (MonsterCreateManger item in mcmArray)
        {
            if (item.knowMonster != null)
            {
                S.positionList.Add(item.pos);
                S.typeList.Add(item.knowMonster.GetComponent<MonsterISMe>().type);
            }
        }
        return S;
    }

    void  SetGame(SaveData sd)//将读取的存储数据的类的对象设置给游戏
    {
        foreach (MonsterCreateManger mcm in mcmArray)
        {
            mcm.Clean();
        }
        for (int i = 0; i < sd.positionList.Count; i++)
        {
            mcmArray[sd.positionList[i]].ActivateMonsterByType(sd.typeList[i]);
        }
        ScoreManger._instance.n = sd.score;

    }

}
