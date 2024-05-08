using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void Save(object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Path.Combine(Application.persistentDataPath, "PlayerProfile");
        if (File.Exists(path))
        {
            DeleteSave();
        }
        File.WriteAllText(path,json);
    }

    /// <summary>
    /// 调用此函数读取玩家存档
    /// </summary>
    /// <typeparam name="TPlayerProfile"></typeparam>
    /// <returns></returns>
    
    public static TPlayerProfile Load<TPlayerProfile>()
    {
        var path = Path.Combine(Application.persistentDataPath, "PlayerProfile");
        var json = File.ReadAllText(path);
        var data = JsonUtility.FromJson<TPlayerProfile>(json);
        return data;
    }
    
    /// <summary>
    /// 删除存档
    /// </summary>
    public static void DeleteSave()
    {
        var path = Path.Combine(Application.persistentDataPath,"PlayerProfile");
        File.Delete(path);
    }

    /// <summary>
    /// 初始化存档 创建新游戏时使用
    /// </summary>
    
    public static void InitSave()
    {
        PlayerProfile p = new PlayerProfile();
        Save(p);
    }

    /// <summary>
    /// 判断是否有存档
    /// </summary>
    /// <returns></returns>
    public static bool hasSave()
    {
        var path = Path.Combine(Application.persistentDataPath,"PlayerProfile");
        if (File.Exists(path))
        {
            return true;
        }

        return false;
    }


    void HowToUse()
    {
        PlayerProfile p = SaveSystem.Load<PlayerProfile>();//读取存档示例
        SaveSystem.Save(p);//存储存档示例
        SaveSystem.InitSave();//初始化存档示例
        int c = p.coin;//访问存档内变量
    }
    
    [Serializable]
    public class PlayerProfile
    {
        public int coin = 99999999;
        public List<int> hasCardNum;
    }
    
    
}
