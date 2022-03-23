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
    public int health = 1;
    public int mental = 1;
    public int art = 0;
    public int programing = 0;
    public bool actionable = false;
    public Color haircolor = Color.white;
    public Color clothescolor = Color.black;
    public bool isman = true;
    public string name = "√÷¡æ»£";
    public List<Direct> directable = new List<Direct>();
    public Room inroom = Room.Rest;

    public WorkerUnit AddWorkerUnit()
    {
        WorkerUnit obj = GameObject.Instantiate<WorkerUnit>(GameManager.Instance.prefab);
        obj.Init(this);
        obj.transform.SetParent(GameManager.Instance.Companys[(int)inroom]);
        obj.transform.localPosition = new Vector3(0, -0.375f, 0);
        obj.transform.localScale = new Vector3(0.125f, 0.125f, 0.125f);
        GameManager.Instance.Companys[(int)inroom].GetComponent<CompanyRoom>().workers.Add(obj);
        return obj;
    }
    public enum Room
    {
        Graphic = 0,
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
    [SerializeField]
    private SpriteRenderer Hair;
    [SerializeField]
    private SpriteRenderer Clothes;

    public float speed;
    public float final;
    public float cooltime;
    public void Init(Worker worker)
    {
        this.worker = worker;
        Hair.color = worker.haircolor;
        Clothes.color = worker.clothescolor;
    }
    
    void Update()
    {
        MovingMan();
    }

    void MovingMan()
    {
        if (transform.localPosition.x == final)
        {
            if (cooltime <= 0)
            {
                speed = UnityEngine.Random.Range(5, 30) / 30000f;
                final = UnityEngine.Random.Range(-4375, 4376) / 10000f;
                cooltime = UnityEngine.Random.Range(20, 66) / 10f;
            }
            else
            {
                cooltime -= Time.deltaTime;
            }
        }
        else
        {
            if (final < transform.localPosition.x)
            {
                transform.localPosition -= new Vector3(speed, 0, 0);
                if (transform.localPosition.x < final)
                {
                    transform.localPosition = new Vector3(final, transform.localPosition.y, transform.localPosition.z);

                }
            }
            else
            {
                transform.localPosition += new Vector3(speed, 0, 0);
                if (transform.localPosition.x > final)
                {
                    transform.localPosition = new Vector3(final, transform.localPosition.y, transform.localPosition.z);
                }
            }
        }
    }
}
