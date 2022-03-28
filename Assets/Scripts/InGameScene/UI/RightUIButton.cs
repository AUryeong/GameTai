using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RightUIButton : MonoBehaviour
{
    [SerializeField]
    WorkerSlot slot;    

    private WorkerUnit targetUnit;

    private bool noclick = false;

    public void Close()
    {
        if (!noclick)
        {
            StartCoroutine(WindowOff(slot.gameObject, targetUnit.gameObject));
        }
    }

    IEnumerator WindowOff(GameObject obj, GameObject mokpyo)
    {
        if (!noclick)
        {
            Vector3 vector = Camera.main.WorldToScreenPoint(mokpyo.transform.position);
            obj.GetComponent<RectTransform>().localScale = Vector3.one;
            obj.transform.position = new Vector3(1645, 510);
            noclick = true;
            while (obj.GetComponent<RectTransform>().localScale.x > 0.02f)
            {
                obj.GetComponent<RectTransform>().localScale = Vector3.Lerp(obj.GetComponent<RectTransform>().localScale, Vector3.zero, Time.deltaTime * 20);
                obj.transform.position = Vector3.Lerp(obj.transform.position, vector, Time.deltaTime * 20);
                yield return new WaitForFixedUpdate();
            }
            obj.GetComponent<RectTransform>().localScale = Vector3.zero;
            obj.transform.position = vector;
            obj.SetActive(false);
            noclick = false;
        }
    }

    IEnumerator WindowOn(GameObject obj, GameObject mokpyo)
    {
        if (!noclick)
        {
            Vector3 vector = new Vector3(1645, 510);
            obj.GetComponent<RectTransform>().localScale = Vector3.zero;
            obj.SetActive(true);
            obj.transform.position = Camera.main.WorldToScreenPoint(mokpyo.transform.position);
            noclick = true;
            while (obj.GetComponent<RectTransform>().localScale.x < 0.98f)
            {
                obj.GetComponent<RectTransform>().localScale = Vector3.Lerp(obj.GetComponent<RectTransform>().localScale, Vector3.one, Time.deltaTime * 20);
                obj.transform.position = Vector3.Lerp(obj.transform.position, vector, Time.deltaTime * 20);
                yield return new WaitForFixedUpdate();
            }
            obj.GetComponent<RectTransform>().localScale = Vector3.one;
            obj.transform.position = vector;
            noclick = false;
        }
    }
    public void Targeting(WorkerUnit targetunit)
    {
        slot.Targeting(targetunit);
        this.targetUnit = targetunit;
        StartCoroutine(WindowOn(slot.gameObject, targetunit.gameObject));
    }
}
