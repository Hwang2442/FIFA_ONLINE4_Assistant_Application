using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.Networking;

public static class JsonHelper
{
    public static void ToJson(object obj, string path)
    {
        string json = JsonConvert.SerializeObject(obj);
        File.WriteAllText(path, json);
    }

    public static T FromJson<T>(string path)
    {
        string json = string.Empty;

        using (UnityWebRequest www = UnityWebRequest.Get(path))
        {
            www.SendWebRequest();

            while (!www.isDone) ;

            json = www.downloadHandler.text;
        }

        return JsonConvert.DeserializeObject<T>(json);
    }
}

#region User information

[Serializable]
public class UserInformation
{
    [JsonConstructor]
    public UserInformation(string accessId, string nickname, int level)
    {
        this.accessId = accessId;
        this.nickname = nickname;
        this.level = level;
    }

    public readonly string accessId;
    public readonly string nickname;
    public readonly int level;
}

[Serializable]
public class HighestRating
{
    [JsonConstructor]
    public HighestRating(int matchType, int division, string achievementDate)
    {
        this.matchType = matchType;
        this.division = division;
        this.achievementDate = achievementDate;
    }

    public readonly int matchType;
    public readonly int division;
    public readonly string achievementDate;
}

[Serializable]
public class TransactionHistory
{
    [JsonConstructor]
    public TransactionHistory(string tradeDate, string saleSn, int spid, int grade, int value)
    {
        this.tradeDate = tradeDate;
        this.saleSn = saleSn;
        this.spid = spid;
        this.grade = grade;
        this.value = value;
    }

    public readonly string tradeDate;
    public readonly string saleSn;
    public readonly int spid;
    public readonly int grade;
    public readonly int value;
}

#endregion

#region Meta information

#endregion