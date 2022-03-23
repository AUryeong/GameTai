using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Rank
{
    D,
    C,
    B,
    A,
    AA,
    AAA
}

[Serializable]
public class Worker
{
    public int health;
    public int mental;
    public int art;
    public int programing;
    public bool actionable = false;
    public Color haircolor = Color.white;
    public Color clothescolor = Color.black;
    public bool isman = true;
    public string name = "√÷¡æ»£";
    public List<Direct> directable = new List<Direct>();
    public Room inroom;

    public GameObject GetWorkerUnit()
    {
        /*GameObject obj = GameManager.Instance.Company.GetComponent<CompanyRoom>().workers.Find((WorkerUnit x) => x.name == name).gameObject;
        if (obj == null)
        {
            obj = new GameObject(name, typeof(WorkerUnit));
            obj.GetComponent<WorkerUnit>().worker = this;
            if(inroom == Room.Direct)
            {
                //obj.transform.SetParent();
            }
        }
        return obj;*/
        return null;
    }
    public enum Room
    {
        Graphic,
        Code,
        Direct,
        Rest
    }

    [Serializable]
    public class Direct
    {
        public Genre genre = Genre.FPS;
        public Rank rank = Rank.D;

        public enum Genre
        {
            FPS,
            RTS,
            Platformer,
            Loguelike,
            Action,
            Metrovania,
            Simulation,
            Stealthaction,
            Hackandslash,
            Tycoon,
            Shooting,
            Rhythm,
            Curtainfire,
            Survival,
            Openworld,
            Reasoning,
            Visualnovel,
            Girldatingsimulation,
            Turnbasedstrategy,
            AOS,
            Autobattler,
            Sandbox,
            RPG,
            MMORPG,
            Puzzle,
            Casual,
            Card,
            Adventure
        }
    }
}


public class WorkerUnit : MonoBehaviour
{
    public Worker worker;
    public WorkerUnit(Worker worker)
    {
        this.worker = worker;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }


}
