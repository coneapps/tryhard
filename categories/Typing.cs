using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Typing : MonoBehaviour, IGameScene
{

    GPGS gpgs = new GPGS();
    SceneLoader sceneLoader;
    int level = 0;
    bool levelInitiated = false;
    int j = 0;
    GameObject yourWordText;
    GameObject wordListText;
    int wordCounter = 0;
    int lettercounter = 0;
    bool lvl1Active = false, arrayUpdated = false;

    float timeCounter = 60;
    bool counterStarted = false;

    string[] englishWordList = {"apple", "come", "walking", "car", "rest", "door", "gone", "flying", "school", "informations", "there", "here", "very", "open", 
                                "while", "make", "leave", "house", "really", "large", "came", "word", "children", "above", "different", "sometimes", "quick", 
                                "thought", "father", "river", "near", "always", "some", "window", "make", "word" ,"children", "can", "point", "under"};

    string[] turkishWordList = { "elma", "gelmek", "araba", "nehir", "kaplan", "temsili", "bazen", "elektrik", "indirim", "kullanmak" , "bilgisayar" , "para", 
                                 "koymak", "getirmek", "insan", "ama", "beklemek", "hemen", "kitap", "sahip", "tutmak", "biraz", "burada", "bilmek", "zor", 
                                 "anlatmak", "yazmak", "gibi", "alt", "kadar", "etmek", "neden", "iyi", "oturmak", "bile", "duymak", "timsah", "kendi"};

    string word;
    string[] choosenWordList = new string[5];

    public Typing(SceneLoader sceneLoader)
    {
        this.sceneLoader = sceneLoader;
    }

    public void Start()
    {

    }

    public void addLetter(string c)
    {
        word += c;
        yourWordText.GetComponent<Text>().text = word;
        checkWord();
    }

    public void deleteLetter()
    {
        if (word.Length > 0)
        {
            word = word.Substring(0, word.Length - 1);
            yourWordText.GetComponent<Text>().text = word;
            checkWord();
        }
    }

    void checkWord()
    {
        if (word == choosenWordList[j])
        {
            lettercounter += word.Length;
            yourWordText.GetComponent<Text>().text = "";
            word = "";
            //Gives score
            wordCounter++;
            if (j == 4)
            {
                updateArray();
                j = 0;
            }
            else
            {
                j++;
                //Remove word from text
                wordListText.GetComponent<Text>().text = wordListText.GetComponent<Text>().text.Remove(0, wordListText.GetComponent<Text>().text.IndexOf(' ') + 1);
            }
        }
        else
        {
            //Nothing happens...(user gotta write it right!)
        }
    }

    void updateArray()
    {
        wordListText.GetComponent<Text>().text = "";
        for (int i = 0; i < 5; i++)
        {
            choosenWordList[i] = chooseWord();   //choosenWordList [0-1-2-3-4]   5 elements filled
            wordListText.GetComponent<Text>().text += choosenWordList[i] + " ";
        }
    }

    string chooseWord()
    {
        if (Lang.lang == 0)
        {
            return englishWordList[Random.Range(0, englishWordList.Length - 1)];
        }
        else if (Lang.lang == 1)
        {
            return turkishWordList[Random.Range(0, turkishWordList.Length - 1)];
        }
        else
        {
            return englishWordList[Random.Range(0, englishWordList.Length - 1)];
        }
    }

    public void Update()
    {

        if (counterStarted)
        {
            if (timeCounter <= 0)
            {
                levelInitiated = false;
                lvl1Active = false;
                counterStarted = false;
            }
            else
            {
                if(counterStarted)
                timeCounter -= Time.deltaTime;
            }
        }


        if (!levelInitiated)
        {
            if (level < sceneLoader.typingLevels.Length)
            {
                if (level != 0)
                {
                    sceneLoader.typingLevels[level - 1].SetActive(false);
                }
                sceneLoader.infoUI.SetActive(true);
                setInfoUI();
            }
            else
            {
                sceneLoader.typingLevels[level - 1].SetActive(false);
                sceneLoader.endUI.SetActive(true);
                setEndUI();
                sceneLoader.saveScores();
            }
            levelInitiated = true;
        }

        if (lvl1Active)
        {
            wordListText = GameObject.FindGameObjectsWithTag("wordlist")[0];
            yourWordText = GameObject.FindGameObjectsWithTag("yourWord")[0];

            GameObject timeMessageText = GameObject.FindGameObjectsWithTag("timeMessage")[0];
            timeMessageText.GetComponent<Text>().text = Lang.getString("timeMessage") + ": " + (int)timeCounter + " s";

            GameObject descriptionText = GameObject.FindGameObjectsWithTag("typingDescription")[0];
            descriptionText.GetComponent<Text>().text = Lang.getString("description") + ":";

            //Levelin başlangıcında wordList doldurulur!
            if (!arrayUpdated)
            {
                updateArray();
                arrayUpdated = true;
            }
        }

    }

    public void setInfoUI()
    {
        GameObject infoText = GameObject.FindGameObjectsWithTag("infoMessage")[0];
        infoText.GetComponent<Text>().text = Lang.getString("typingInfo" + (level + 1)); ;
    }
    public void setEndUI()
    {
        GameObject infoText = GameObject.FindGameObjectsWithTag("score")[0];
        GameObject btnRetry = GameObject.FindGameObjectWithTag("retry");
        int score = wordCounter * lettercounter;
        sceneLoader.addTypingScore(score);
        infoText.GetComponent<Text>().text = Lang.getString("youGained") + ": " + score;
        if (gpgs.isSigned())
        {
            if (score > 1000)
                gpgs.unlockAchivement("CgkIm6CK7OEHEAIQCQ");
            if (score > 2000)
                gpgs.unlockAchivement("CgkIm6CK7OEHEAIQCg");
            if (score > 5000)
                gpgs.unlockAchivement("CgkIm6CK7OEHEAIQCw");
            gpgs.postScore(score, "CgkIm6CK7OEHEAIQCA");
        }
    }

    public void nextButtonClicked()
    {
        sceneLoader.infoUI.SetActive(false);
        sceneLoader.typingLevels[level].SetActive(true);

        level++;

        lvl1Active = true;
        counterStarted = true;
    }

    public void OnGUI()
    {

    }
}