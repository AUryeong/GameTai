using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<Transform> Companys = new List<Transform>();
    public WorkerUnit prefab;

    void Start()
    {
        foreach(Worker worker in DataController.Instance.gameData.workers)
        {
            worker.AddWorkerUnit();
        }
    }
}
    

