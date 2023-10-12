using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class DataHandler<T>
    where T : IComparable<T>
{
    public T[] array = new T[10];
    private int gSheetStartIndex;
    private int gSheetEndIndex;

    public DataHandler(int gSheetStartIndex, int gSheetEndIndex)
    {
        this.gSheetStartIndex = gSheetStartIndex;
        this.gSheetEndIndex = gSheetEndIndex;
    }

    public void LoadData(List<string> values)
    {
        for (int i = gSheetStartIndex; i < gSheetEndIndex; i++)
            array[i - gSheetStartIndex] = (T)Convert.ChangeType(values[i], typeof(T));
    }
}

public class GoogleSheetsController : MonoBehaviour
{
    public DataHandler<int> NumEnergyShieldsDataHandler = new(0, 10);
    public DataHandler<float> DragonSpeedDataHandler = new(10, 20);
    public DataHandler<float> DragonTimeBetweenEggDropsDataHandler = new(20, 30);
    public DataHandler<float> DragonLeftRightDistanceDataHandler = new(30, 40);
    public DataHandler<float> DragonEggSpeedDataHandler = new(40, 50);

    private void Awake()
    {
        StartCoroutine(LoadData());
    }

    public IEnumerator LoadData()
    {
        UnityWebRequest curentResp = UnityWebRequest.Get("https://sheets.googleapis.com/v4/spreadsheets/1o19ha-YpnmuLS3ykEEedX4mSo1mXQyecfvzAQtcEYEQ/values/Лист1?key=AIzaSyDioDZ0qN8PDi5qZcaD2tNIveIt85oi9TQ");
        yield return curentResp.SendWebRequest();

        string rawResp = curentResp.downloadHandler.text;
        var rawJson = JSON.Parse(rawResp);

        foreach (var itemRawJson in rawJson["values"])
        {
            var parseJson = JSON.Parse(itemRawJson.ToString());
            var selectRow = parseJson[0].AsStringList;
            if (selectRow.Count == 50)
            {
                NumEnergyShieldsDataHandler.LoadData(selectRow);
                DragonSpeedDataHandler.LoadData(selectRow);
                DragonTimeBetweenEggDropsDataHandler.LoadData(selectRow);
                DragonLeftRightDistanceDataHandler.LoadData(selectRow);
                DragonEggSpeedDataHandler.LoadData(selectRow);
            }
        }
    }
}
