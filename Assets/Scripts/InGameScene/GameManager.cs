using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<CompanyRoom> Companys = new List<CompanyRoom>();
    public WorkerUnit prefab;
    public RightUIButton rightUI;
    public LeftUIButton leftUI;

    void Start()
    {
        foreach (Worker worker in DataController.Instance.gameData.workers)
        {
            worker.AddWorkerUnit();
        }
    }

}
    

