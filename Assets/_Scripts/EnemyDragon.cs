using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
    public GameObject dragonEggPrefab;
    public float Speed = 1f;
    public float TimeBetweenEggDrops = 1f;
    public float LeftRightDistance = 10f;
    public float ChanceDirection = 0.1f;
    public GoogleSheetsController GSheetController;
    
    void Start()
    {
        StartCoroutine(StartRoutine());
    }

    private IEnumerator StartRoutine()
    {
        yield return StartCoroutine(GSheetController.LoadData());

        int levelNum = LevelController.GetLevelNumber();

        Speed = GSheetController.DragonSpeedDataHandler.array[levelNum - 1];
        TimeBetweenEggDrops = GSheetController.DragonTimeBetweenEggDropsDataHandler.array[levelNum - 1];
        LeftRightDistance = GSheetController.DragonLeftRightDistanceDataHandler.array[levelNum - 1];        

        Invoke("DropEgg", 2f);
    }

    void DropEgg()
    {
        Vector3 myVector = new Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg = Instantiate<GameObject>(dragonEggPrefab);
        egg.transform.position = transform.position + myVector;
        Invoke("DropEgg", TimeBetweenEggDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += Speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -LeftRightDistance)
        {
            Speed = Mathf.Abs(Speed);
        }
        else if (pos.x > LeftRightDistance)
        {
            Speed = -Mathf.Abs(Speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < ChanceDirection)
        {
            Speed *= -1;
        }
    }
}
