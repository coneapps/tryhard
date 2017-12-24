using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Tapping : MonoBehaviour, IGameScene
{

    GPGS gpgs = new GPGS();
    SceneLoader sceneLoader;
    int level = 0;
    bool levelInitiated = false;
    Vector2[] coords;

    float timeCounter = 30;
    bool counterStarted = false;

    bool lvl1Active = false;
    public int touchCounter = 0;
    public int buttonPosition = 2;


    public Tapping(SceneLoader sceneLoader)
    {
        this.sceneLoader = sceneLoader;
    }

    public void Start()
    {
        coords = new Vector2[5];
        coords[0] = new Vector2(-60, 0);
        coords[1] = new Vector2(60, 0);
        coords[2] = new Vector2(0, -60);
        coords[3] = new Vector2(-60, -120);
        coords[4] = new Vector2(60, -120);
    }

    public void Update()
    {

        if (timeCounter <= 0)
        {
            levelInitiated = false;
            lvl1Active = false;
            counterStarted = false;
        }
        else
        {
            if (counterStarted)
            timeCounter -= Time.deltaTime;
        }

        if (!levelInitiated)
        {
            if (level < sceneLoader.tappingLevels.Length)
            {
                if (level != 0)
                {
                    sceneLoader.tappingLevels[level - 1].SetActive(false);
                }
                sceneLoader.infoUI.SetActive(true);
                setInfoUI();
                levelInitiated = true;
            }
            else
            {
                sceneLoader.tappingLevels[level - 1].SetActive(false);
                sceneLoader.endUI.SetActive(true);
                setEndUI();
                sceneLoader.saveScores();
            }
        }

        if (lvl1Active)
        {
            GameObject timeMessageText = GameObject.FindGameObjectsWithTag("timeMessage")[0];
            timeMessageText.GetComponent<Text>().text = Lang.getString("timeMessage") + ": " + (int)timeCounter + " s";

            GameObject clickMessageText = GameObject.FindGameObjectsWithTag("clickMessage")[0];
            clickMessageText.GetComponent<Text>().text = Lang.getString("clickMessage") + ": " + (int)touchCounter;

            GameObject clickButton = GameObject.FindGameObjectsWithTag("clickButton")[0];
            clickButton.GetComponent<RectTransform>().anchoredPosition = coords[buttonPosition];
        }
    }

    public void setInfoUI()
    {
        GameObject infoText = GameObject.FindGameObjectsWithTag("infoMessage")[0];
        infoText.GetComponent<Text>().text = Lang.getString("tappingInfo" + (level + 1));
    }
    public void setEndUI()
    {
        GameObject infoText = GameObject.FindGameObjectsWithTag("score")[0];
        GameObject btnRetry = GameObject.FindGameObjectWithTag("retry");
        infoText.GetComponent<Text>().text = Lang.getString("pointsEarned") + ": " + touchCounter;
        if (gpgs.isSigned())
        {
            if (touchCounter > 25)
                gpgs.unlockAchivement("CgkIm6CK7OEHEAIQDQ");
            if (touchCounter > 50)
                gpgs.unlockAchivement("CgkIm6CK7OEHEAIQDg");
            if (touchCounter > 75)
                gpgs.unlockAchivement("CgkIm6CK7OEHEAIQDw");
            gpgs.postScore(touchCounter, "CgkIm6CK7OEHEAIQDA");
        }
    }

    public void nextButtonClicked()
    {

        sceneLoader.infoUI.SetActive(false);
        sceneLoader.tappingLevels[level].SetActive(true);

        level++;

        lvl1Active = true;
        counterStarted = true;
    }

    public void OnGUI()
    {


    }

}