using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelController
{
    private static int levelNum;

    public static int GetLevelNumber()
    {
        return levelNum;
    }

    public static void ChangeLevelNum(int levelNumber)
    {
        levelNum = levelNumber;
    }
}
