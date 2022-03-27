using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.EventSystems;
using TMPro;
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
public enum Room
{
    Graphic = 0,
    Code,
    Direct,
    Rest
}

 
[Serializable]
public class Worker
{
    public int maxhelath = 1;
    public int maxmental = 1;
    public int health = 1;
    public int mental = 1;
    public int art = 0;
    public int programing = 0;
    public bool actionable = false;
    public Color haircolor = Color.white;
    public Color clothescolor = Color.black;
    public bool isman = true;
    public string name = "최종호";
    public Room room = Room.Rest;
    public List<Direct> directable = new List<Direct>();

    public WorkerUnit AddWorkerUnit()
    {
        
        WorkerUnit obj = GameObject.Instantiate<WorkerUnit>(GameManager.Instance.prefab);
        obj.Init(this);
        obj.transform.SetParent(GameManager.Instance.Companys[(int)room].transform);
        obj.transform.localPosition = new Vector3(0, 0f, 0);
        obj.transform.localScale = new Vector3(1f, 1f, 1f);
        obj.name = "Worker_" + name;
        GameManager.Instance.Companys[(int)room].workers.Add(obj);
        return obj;
    }

    public WorkerUnit GetWorkerUnit()
    {
        WorkerUnit worker = GameManager.Instance.Companys[(int)room].workers.Find((WorkerUnit x) => x.worker == this);
        if(worker == null)
        {
            worker = AddWorkerUnit();
        }
        return worker;
    }

    [Serializable]
    public class Direct
    {
        public Genre genre = Genre.FPS;
        public Rank rank = Rank.D;

        public static string[] GenreList = new string[]
        {
            "FPS", "RTS", "플랫포머", "로그라이크", "액션", "메트로바니아", "시뮬레이션", "잠입 액션", "핵 앤 슬래시", "타이쿤", "슈팅 리듬", "탄막 슈팅", "생존", "오픈 월드 ", "추리", "비주얼 노벨", "미연시", "턴제 전략", "AOS", "오토배틀러", "샌드박스", "RPG", "MMORPG", "퍼즐", "캐주얼", "카드 게임", "어드벤처"
        };

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


public class WorkerUnit : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler
{
    public Worker sanwiworker;
    public Worker worker;
    [SerializeField]
    private SpriteRenderer Hair;
    [SerializeField]
    private SpriteRenderer Clothes;
    [SerializeField]
    private TextMeshPro tmp;

    public float speed;
    public float final;
    public float cooltime;
    private float catched = -1;
    public void OnPointerUp(PointerEventData data)
    {
        if(catched > 0.16f)
        {
            CompanyRoom companyroom = null;
            float xyz = 9999999;
            foreach (CompanyRoom companyRoom in GameManager.Instance.Companys)
            {
                float xy = Mathf.Abs(companyRoom.transform.position.x - this.gameObject.transform.position.x) + Mathf.Abs(companyRoom.transform.position.y - this.gameObject.transform.position.y);
                if (xy < xyz)
                {
                    xyz = xy;
                    companyroom = companyRoom;
                }
            }
            this.Move(companyroom);
        }
        else
        {
            GameManager.Instance.rightUI.Targeting(this);
        }
        catched = -1;
    }
    public void OnPointerClick(PointerEventData data)
    {

    }
    public void OnPointerDown(PointerEventData data)
    {
        catched = 0;
    }
    public void Init(Worker worker)
    {
        this.worker = worker;
        Hair.color = worker.haircolor;
        Clothes.color = worker.clothescolor;
        tmp.text = worker.name;
    }
    
    public void Move(CompanyRoom companyRoom)
    {
        if (companyRoom.room != worker.room)
        {
            GameManager.Instance.Companys[(int)worker.room].workers.Remove(this);
            companyRoom.workers.Add(this);
            this.gameObject.transform.SetParent(companyRoom.transform);
            worker.room = companyRoom.room;
        }
        if (Mathf.Abs(this.gameObject.transform.localPosition.x) > 7.03f)
        {
            if(this.gameObject.transform.localPosition.x > 0)
            {
                this.gameObject.transform.localPosition = new Vector3(7.03f, 0, 0);
            }
            else
            {
                this.gameObject.transform.localPosition = new Vector3(-7.03f, 0, 0);
            }
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, 0, 0);
        }
        final = this.gameObject.transform.localPosition.x;
        cooltime = UnityEngine.Random.Range(2, 10) / 10f;
    }

    void Update()
    {
        if (catched >= 0)
        {
            catched += Time.deltaTime;
            if(catched > 0.16f)
            {
                Vector3 vt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                this.gameObject.transform.position = new Vector3(vt.x, vt.y, 0);
            }
            else
            {
                MovingMan();
            }
        }
        else
        {
            MovingMan();
        }
    }

    void MovingMan()
    {
        if (transform.localPosition.x == final)
        {
            if (cooltime <= 0)
            {
                speed = UnityEngine.Random.Range(5, 31) / 30000f;
                final = UnityEngine.Random.Range(-70300, 70301) / 10000f;
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
