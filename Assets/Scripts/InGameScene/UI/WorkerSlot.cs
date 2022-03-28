using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class WorkerSlot : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI workername;
    [SerializeField]
    private TextMeshProUGUI workerhealth;
    [SerializeField]
    private TextMeshProUGUI workerbreak;
    [SerializeField]
    private TextMeshProUGUI workerprog;
    [SerializeField]
    private TextMeshProUGUI workerart;
    [SerializeField]
    private TextMeshProUGUI workerdirect;
    [SerializeField]
    private Image hair;
    [SerializeField]
    private Image clothes;
    public void Targeting(WorkerUnit targetunit)
    {
        Worker target = targetunit.worker;
        if (target != null)
        {
            workername.text = target.name;
            workerhealth.text = "체력 : " + target.health + " / " + target.maxhelath;
            workerbreak.text = "정신력 : " + target.mental + " / " + target.maxmental;
            workerprog.text = "프로그래밍 : " + target.programing;
            workerart.text = "미적 감각 : " + target.art;
            string s = "";
            foreach (Worker.Direct direct in target.directable)
            {
                s += Worker.Direct.GenreList[(int)direct.genre] + " (" + direct.rank + ")\n";
            }
            workerdirect.text = s;
            hair.color = target.haircolor;
            clothes.color = target.clothescolor;
        }
    }
}
