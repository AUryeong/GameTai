using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public string name = "최종호";
    public List<Direct> directable = new List<Direct>();
    
    public GameObject GetWorkerUnit()
    {
        GameObject obj = GameObject.Find("Company").transform.Find(name).gameObject;
        if(obj == null)
        {
            obj = new GameObject(name, typeof(WorkerUnit));
            obj.GetComponent<WorkerUnit>().worker = this;
            obj.transform.SetParent(GameObject.Find("Company").transform);
        }
        return obj;
    }

    [Serializable]
    public class Direct
    {
        public Genre genre;
        public int rank = 0; //최대 6
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
