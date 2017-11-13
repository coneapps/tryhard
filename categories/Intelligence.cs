using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
//TODO : REMOVE RETARDED SOLUTIONS, ENCAPSULATE WHAT VARIES
public class Intelligence : MonoBehaviour, IGameScene {

	public GameObject sceneLoaderObject;

    public Intelligence()
    {
		
    }
    public string[] levelCode;
    public GameObject uiComponents;
    public GameObject message;
    public GameObject userInput;
    public GameObject numbers;
    public GameObject timeText;
    public GameObject[] choiceButtons;
    public GameObject[] imageButtons;
    public Sprite[] sprites;
    int currentLevel = 0;
    int correctAnswers = 0;
    int time;
    string[] parts;

    void OnEnable()
    {
        time = 300;
        InvokeRepeating("countDown", 1, 1);
        loadLevel();
    }

    public void loadLevel()
    {
        if (currentLevel != 20)
        {
            parts = levelCode[currentLevel].Split(new[] { "/" }, StringSplitOptions.None);
            int level = currentLevel + 1;
            message.GetComponent<Text>().text = "Level " + level + "\n" + parts[0];
            if (parts[2] == "1") // numara girişi olan bölümler
            {
                numbers.SetActive(true);
                if (parts.Length == 4)
                {
                    int number = int.Parse(parts[3]);
                    imageButtons[0].GetComponent<Image>().sprite = sprites[number];
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
                    imageButtons[i].SetActive(true);
                }
            }
        }
        else
        {
            CancelInvoke();
            int score = correctAnswers * time;
            message.GetComponent<Text>().text = "You finished this category. You can play it again to increase your score.\nScore :" + score;
            sceneLoaderObject.GetComponent<SceneLoader>().addIntelligenceScore(score);
            sceneLoaderObject.GetComponent<SceneLoader>().saveScores();
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
        timeText.GetComponent<Text>().text = "Time: " + time + " s";
        if (time <= 0)
        {
            uiComponents.SetActive(false);
            message.GetComponent<Text>().text = "Time's up!\nResult :" + correctAnswers + "/20";
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
