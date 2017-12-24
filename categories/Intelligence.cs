using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class Intelligence : MonoBehaviour, IGameScene {

	public GameObject sceneLoaderObject;
    	GPGS gpgs = new GPGS();

    public Intelligence()
    {
		
    }
    public string[] levelCode;
    public GameObject uiComponents;
    public GameObject message;
    public GameObject userInput;
    public GameObject numbers;
    public GameObject timeText;
    public GameObject retryButton;
    public GameObject[] choiceButtons;
    public GameObject[] imageButtons;
    public Sprite[] sprites;
    int currentLevel = 0;
    int correctAnswers = 0;
    int time;
    string[] parts;
    string question;
    string timeType;

    void OnEnable()
    {
        question = Lang.getString("Qtype");
        timeType = Lang.getString("time");
        levelCode[0] = Lang.getString("intQ1");
        levelCode[1] = Lang.getString("intQ2");
        levelCode[2] = Lang.getString("intQ3");
        levelCode[3] = Lang.getString("intQ4");
        levelCode[4] = Lang.getString("intQ5");
        levelCode[5] = Lang.getString("intQ6");
        levelCode[6] = Lang.getString("intQ7");
        levelCode[7] = Lang.getString("intQ8");
        levelCode[8] = Lang.getString("intQ9");
        levelCode[9] = Lang.getString("intQ10");
        levelCode[10] = Lang.getString("intQ11");
        levelCode[11] = Lang.getString("intQ12");
        levelCode[12] = Lang.getString("intQ13");
        levelCode[13] = Lang.getString("intQ14");
        levelCode[14] = Lang.getString("intQ15");
        levelCode[15] = Lang.getString("intQ16");
        levelCode[16] = Lang.getString("intQ17");
        levelCode[17] = Lang.getString("intQ18");
        levelCode[18] = Lang.getString("intQ19");
        levelCode[19] = Lang.getString("intQ20");
        levelCode[20] = Lang.getString("intQ21");
        time = 600;
        InvokeRepeating("countDown", 0, 1);
        loadLevel();
    }

    public void loadLevel()
    {
        if (currentLevel != 20)
        {
            parts = levelCode[currentLevel].Split(new[] { "/" }, StringSplitOptions.None);
            int level = currentLevel + 1;
            message.GetComponent<Text>().text = question + level + "\n" + parts[0];
            if (parts[2] == "1") // numara girişi olan bölümler
            {
                numbers.SetActive(true);
                if (parts.Length == 4)
                {
                    int number = int.Parse(parts[3]);
                    imageButtons[0].GetComponent<Image>().sprite = sprites[number];
                    setImage();
                    imageButtons[0].SetActive(true);
                }
            }
            else if (parts[2] == "2") // çoktan seçmeli bölümler
            {
                string[] choices = parts[1].Split(new[] { " " }, StringSplitOptions.None);
                for (int i = 0; i < choiceButtons.Length; i++)
                {
                    choiceButtons[i].GetComponentInChildren<Text>().text = choices[i];
                    choiceButtons[i].SetActive(true);
                }
            }
            else if (parts[2] == "3") // resim seçmeli bölümler
            {
                string[] sprNumbers = parts[3].Split(new[] { "," }, StringSplitOptions.None);
                for (int i = 0; i < imageButtons.Length; i++)
                {
                    int number = int.Parse(sprNumbers[i]);
                    imageButtons[i].GetComponent<Image>().sprite = sprites[number];
                    setImage();
                    imageButtons[i].SetActive(true);
                }
            }
        }
        else
        {
            CancelInvoke();
            int score = correctAnswers * (time/2);
            message.GetComponent<Text>().text = Lang.getString("finalmsg") + score;
            sceneLoaderObject.GetComponent<SceneLoader>().addIntelligenceScore(score);
            sceneLoaderObject.GetComponent<SceneLoader>().saveScores();
            if (gpgs.isSigned())
            {
                if (correctAnswers >= 5)
                    gpgs.unlockAchivement("CgkIm6CK7OEHEAIQAg");
                if (correctAnswers >= 10)
                    gpgs.unlockAchivement("CgkIm6CK7OEHEAIQAw");
                if (correctAnswers >= 20)
                    gpgs.unlockAchivement("CgkIm6CK7OEHEAIQBA");
                if (score > 1000)
                    gpgs.unlockAchivement("CgkIm6CK7OEHEAIQBQ");
                if (score > 3000)
                    gpgs.unlockAchivement("CgkIm6CK7OEHEAIQBg");
                if (score > 5000)
                    gpgs.unlockAchivement("CgkIm6CK7OEHEAIQBw");
                gpgs.postScore(score, "CgkIm6CK7OEHEAIQAQ");
            }
            retryButton.SetActive(true);
        }
    }

    public void select()
    {
        if (parts[2] == "1")
        {
            if (userInput.GetComponent<Text>().text == parts[1])
                correctAnswers++;
            numbers.SetActive(false);
            userInput.GetComponent<Text>().text = "";
            if (imageButtons[0].activeSelf)
                imageButtons[0].SetActive(false);
        }
        else if (parts[2] == "2")
        {
            string answer = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
            string[] choices = parts[1].Split(new[] { " " }, StringSplitOptions.None);
            if (answer == choices[5])
                correctAnswers++;
            for (int i = 0; i < choiceButtons.Length; i++)
            {
                choiceButtons[i].SetActive(false);
            }
        }
        else if (parts[2] == "3")
        {
            if (EventSystem.current.currentSelectedGameObject.name == parts[1])
                correctAnswers++;
            for (int i = 0; i < imageButtons.Length; i++)
            {
                imageButtons[i].SetActive(false);
            }
        }
        currentLevel++;
        loadLevel();
    }

    public void countDown()
    {
        time--;
        timeText.GetComponent<Text>().text = timeType + time + " s";
        if (time <= 0)
        {
            uiComponents.SetActive(false);
            message.GetComponent<Text>().text = Lang.getString("timeUp");
            retryButton.SetActive(true);
            CancelInvoke();
        }
    }

    public void type()
    {
        userInput.GetComponent<Text>().text = userInput.GetComponent<Text>().text + EventSystem.current.currentSelectedGameObject.name;
    }

    public void undo()
    {
        if (userInput.GetComponent<Text>().text != "")
            userInput.GetComponent<Text>().text = userInput.GetComponent<Text>().text.Remove(userInput.GetComponent<Text>().text.Length - 1);
    }

    public void setImage()
    {
        if ((imageButtons[0].GetComponent<Image>().sprite.bounds.size.x / imageButtons[0].GetComponent<Image>().sprite.bounds.size.y) < 2)
        {
            imageButtons[0].transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            imageButtons[0].transform.localScale = new Vector3(2, 0.5f, 1);
        }
    }

	public void Start () {
		
	}

	public void Update () {

	}

	public void setInfoUI(){

	}
	public void setEndUI(){

	}
	public void nextButtonClicked(){
		
	}

	public void OnGUI(){

	}
}
