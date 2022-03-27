using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeftUIButton : MonoBehaviour
{
    [SerializeField]
    private GameObject shopwindow;

    [SerializeField]
    private GameObject communitywindow;

    [SerializeField]
    private GameObject workercontrolwindow;

    [SerializeField]
    private GameObject workeraddwindow;

    [SerializeField]
    private GameObject leftuiwindow;

    private bool noclick = false;
    private bool opened = false;

    private void Awake()
    {
    }

    public void OpenorClose()
    {
        if (!noclick)
        {
            noclick = true;
            if (opened)
            {
                StartCoroutine(Close());
            }
            else
            {
                StartCoroutine(Open());
            }
            opened = !opened;
        }
    }

    IEnumerator Open()
    {
        leftuiwindow.GetComponent<RectTransform>().localPosition = new Vector3(-1183, -200, 0);
        while (Mathf.Abs(leftuiwindow.GetComponent<RectTransform>().localPosition.x) - 730f > 0.2f)
        {
            leftuiwindow.GetComponent<RectTransform>().localPosition = Vector3.Lerp(leftuiwindow.GetComponent<RectTransform>().localPosition, new Vector3(-730, -200, 0), Time.deltaTime * 12);
            yield return new WaitForFixedUpdate();
        }
        leftuiwindow.GetComponent<RectTransform>().localPosition = new Vector3(-730, -200, 0);
        noclick = false;
    }
    IEnumerator Close()
    {
        leftuiwindow.GetComponent<RectTransform>().localPosition = new Vector3(-730, -200, 0);
        while (Mathf.Abs(leftuiwindow.GetComponent<RectTransform>().localPosition.x) - 1183f < -0.2f)
        {
            leftuiwindow.GetComponent<RectTransform>().localPosition = Vector3.Lerp(leftuiwindow.GetComponent<RectTransform>().localPosition, new Vector3(-1183, -200, 0), Time.deltaTime * 12);
            yield return new WaitForFixedUpdate();
        }
        leftuiwindow.GetComponent<RectTransform>().localPosition = new Vector3(-1183, -200, 0);
        noclick = false;
    }

    IEnumerator WindowOff(GameObject obj, GameObject mokpyo)
    {
        if (!noclick)
        {
            obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            obj.GetComponent<RectTransform>().localPosition = Vector3.zero;
            obj.SetActive(true);
            noclick = true;
            while (obj.GetComponent<RectTransform>().localScale.x > 0.02f)
            {
                obj.GetComponent<RectTransform>().localScale = Vector3.Lerp(obj.GetComponent<RectTransform>().localScale, Vector3.zero, Time.deltaTime * 20);
                obj.GetComponent<RectTransform>().localPosition = Vector3.Lerp(obj.GetComponent<RectTransform>().localPosition, mokpyo.GetComponent<RectTransform>().localPosition, Time.deltaTime * 20);
                yield return new WaitForFixedUpdate();
            }
            obj.GetComponent<RectTransform>().localScale = Vector3.zero;
            obj.GetComponent<RectTransform>().localPosition = obj.GetComponent<RectTransform>().localPosition;
            noclick = false;
        }
    }

    IEnumerator WindowOn(GameObject obj, GameObject mokpyo)
    {
        if (!noclick)
        {
            obj.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            obj.SetActive(true);
            obj.GetComponent<RectTransform>().localPosition = mokpyo.GetComponent<RectTransform>().localPosition;
            noclick = true;
            while (obj.GetComponent<RectTransform>().localScale.x < 0.98f)
            {
                obj.GetComponent<RectTransform>().localScale = Vector3.Lerp(obj.GetComponent<RectTransform>().localScale, Vector3.one, Time.deltaTime * 20);
                obj.GetComponent<RectTransform>().localPosition = Vector3.Lerp(obj.GetComponent<RectTransform>().localPosition, Vector3.zero, Time.deltaTime * 20);
                yield return new WaitForFixedUpdate();
            }
            obj.GetComponent<RectTransform>().localScale = Vector3.one;
            obj.GetComponent<RectTransform>().localPosition = Vector3.zero;
            noclick = false;
        }
    }

}