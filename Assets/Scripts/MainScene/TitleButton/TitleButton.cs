using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    [SerializeField]
    private GameObject blackground;

    [SerializeField]
    private GameObject newgamewindow;

    [SerializeField]
    private GameObject continuewindow;

    [SerializeField]
    private GameObject gameoutwindow;

    [SerializeField]
    private GameObject newgame;

    [SerializeField]
    private GameObject gameout;

    private bool noclick = false;

    private void Awake()
    {
        TextMeshProUGUI tmpro = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        if (DataController.Instance.gameData.cleartutorial)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
            tmpro.color = new Color(tmpro.color.r, tmpro.color.g, tmpro.color.b, 1);
        }
        else
        {
            this.gameObject.GetComponent<Button>().interactable = false;
            tmpro.color = new Color(tmpro.color.r, tmpro.color.g, tmpro.color.b, 0.35f);
        }
    }

    IEnumerator WindowOff(GameObject obj, GameObject mokpyo)
    {
        if (!noclick)
        {
            blackground.gameObject.SetActive(false);
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
            blackground.gameObject.SetActive(true);
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
    public void NewGameNo()
    {
        StartCoroutine(WindowOff(newgamewindow, newgame));
    }
    public void ContinueNo()
    {
        StartCoroutine(WindowOff(continuewindow, gameObject));
    }
    public void GameOutNo()
    {
        StartCoroutine(WindowOff(gameoutwindow, gameout));
    }
    public void NewGame()
    {
        if (DataController.Instance.gameData.cleartutorial)
        {
            StartCoroutine(WindowOn(newgamewindow, newgame));
        }
        else if (!noclick)
        {
            DataController.Instance._gameData = new GameData();
            DataController.Instance.SaveGameData();
            SceneManager.LoadScene("InGameScene");
        }
    }
    public void Continue()
    {
        StartCoroutine(WindowOn(continuewindow, gameObject));
    }

    public void GameOut()
    {
        StartCoroutine(WindowOn(gameoutwindow, gameout));
    }


    public void NewGameYes()
    {
        DataController.Instance._gameData = new GameData();
        DataController.Instance.SaveGameData();
        DataController.Instance.LoadGameData();
        SceneManager.LoadScene("InGameScene");
    }
    public void ContinueYes()
    {
        DataController.Instance.LoadGameData();
        SceneManager.LoadScene("InGameScene");
    }
    public void GameOutYes()
    {
        DataController.Instance.SaveGameData();
        Application.Quit();
    }

}