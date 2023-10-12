using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragonData : MonoBehaviour 
{
    public float Speed = 1;
    public float TimeBetweenEggDrops = 1f;
    public float LeftRightDistance = 10f;
    public float ChanceDirection = 0.1f;

    public EnemyDragonData(float speed, float timeBetweenEggDrop, float leftRightDistance, float chanceDirection)
    {
        Speed = speed;
        TimeBetweenEggDrops = timeBetweenEggDrop;
        LeftRightDistance = leftRightDistance;
        ChanceDirection = chanceDirection;
    }
}