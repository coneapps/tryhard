
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Word : MonoBehaviour, IGameScene
{

    GPGS gpgs = new GPGS();

    public GameObject sceneLoader;
    public GameObject[] levels;
    public GameObject[] wordsTxt;
    public GameObject[] differentWords;
    public GameObject timeMessage;
    public GameObject timeMessage1;
    public GameObject[] buttons;
    public GameObject wordInfoTxt;
    public GameObject startButton;
    bool wrongWord = false;

    public Word()
    {
    }


    int timer = 0;
    int timer1 = 0;
    int correctAnswers = 0;
    int buttonPressed = 0;


    string[] wordArray = {"abandon", "ability", "account", "act", "adapt", "addition", "admire","afford",
                          "agent","air","alarm","alive","allow","anger",
                          "baby", "bad", "ball","bang", "bandage", "bar", "beard","bell" , "bind", "bit",
                          "blame" , "blood","bone","bow" ,
                          "cage","calm", "cat","cell","chef", "come", "chest", "choice","claim","clay",
                          "coal", "comfort", "craft","cruel","customs",
                          "daily","dance", "deal", "destination", "dry","deposit","developer","diet",
                          "discover","doctor","doom", "dorm","dusk","dream","dry",
                          "ear", "ecology", "edit","effort", "element","embarrass","emotion","employee",
                          "energy",
                          "faint" ,"feast","fry",
                          "general","go","glad","great",
                          "him","howl",
                          "reach","rest",
                          "keep", "kill",
                          "oath", "object", "offer","oneself",
                           "zoo" ,

                          "animal","absence", "abstract","accuracy","abuse",
                          "blast", "bleed", "bolt", "blizzard","break" ,
                          "can","caution","certainty","chaos", "cry","choke",
                          "dad","dentist","depth","dictionary","dog", "duty",
                          "easy","edge","elbow","emerge","enjoy",
                          "far", "from","feel",
                          "gender","generation","glam",
                          "how","heal",
                          "off", "odd","once", "operate", 
                          "zero"};
    string[] wordArray1 = {"vazgeçmek", "yetenek", "hesap", "hareket", "uyum", "ek", "hayran", "göze",
                          "ajan", "hava", "alarm", "canlı", "izin", "öfke",
                          "sakal", "sanal", "saban", "bel", "bağla", "pire", "ateş",
                          "suç", "kan", "kemik", "yay",
                          "kafes", "sakin", "kedi", "hücre", "şef", "gel", "göğüs", "seçim", "talep", "kil",
                          "kömür", "konfor", "zanaat", "zalim", "gümrük",
                          "günlük", "dans", "pazarlama", "kuru", "mevduat", "geliştirici", "diyet",
                          "keşfetmek", "doktor", "lanet", "yurt", "alacaklı", "hayal", "kuru",
                          "kulak", "ekoloji", "düzenleme", "efor", "unsur", "utanç", "duygu", "çalışan",
                          "enerji",
                          "baygın", "bayram", "kızartma",
                          "genel", "büyük", "memnun", "git",
                          "o", "feryat",
                          "rest", "ulaşmak",
                          "tutmak", "öldürmek",
                          "yemin", "nesne", "teklif", "kendin",
                           "çiçekçi",

                          "hayvan", "yokluk", "soyut", "doğruluk", "kullanım",
                          "patlama", "kanama", "cıvata", "fırtına", "kırık",
                          "can", "dikkat", "kesinlik", "kaos", "ağla", "boğmak",
                          "baba", "dişçi", "derinlik", "sözlük", "köpek", "görev",
                          "kolay", "üstünde", "dirsek", "zevk","ortaya",
                          "uzak", "dan", "hissetmek",
                          "cinsiyet", "kuşak", "ışıltı",
                          "nasıl", "iyileşmek",
                          "kapalı", "tek", "bir kez", "çalıştır",
                          "sıfır"};

    void OnEnable()
    {
        levels[0].SetActive(true);
        level0();
        level1();
        level2();
        level3();
    }


    public void level0()
    {
        if (levels[0].activeSelf == true)
        {
            levels[1].SetActive(false);
            levels[2].SetActive(false);
            levels[3].SetActive(false);
            wordInfoTxt.GetComponent<Text>().text = Lang.getString("wordInfo");
            startButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                levels[0].SetActive(false);
                levels[1].SetActive(true);
                level1();
            });
        }
    }

    public void level1()
    {
        if (levels[1].activeSelf == true)
        {
            levels[0].SetActive(false);
            levels[2].SetActive(false);
            levels[3].SetActive(false);
            timer = 15;
            InvokeRepeating("countDown", 0.01f, 1);
        }
        wordsToScreen();
    }

    public void level2()
    {
        if (levels[2].activeSelf == true)
        {
            differentWords[0].SetActive(false);
            differentWords[1].SetActive(false);
            levels[0].SetActive(false);
            levels[1].SetActive(false);
            levels[3].SetActive(false);
            timer1 = 30;
            InvokeRepeating("countDown1", 0.01f, 1);
        }
        buttonListeners();
        wordsToButton();

    }

    public void level3()
    {
        if (levels[3].activeSelf == true)
        {
            levels[0].SetActive(false);
            levels[1].SetActive(false);
            levels[2].SetActive(false);
            levels[3].SetActive(true);
            GameObject scoreText = GameObject.FindGameObjectWithTag("score");
            GameObject retryBtn = GameObject.FindGameObjectWithTag("retry");
            int score = (correctAnswers / 2 * 50) + 200;
            scoreText.GetComponent<Text>().text = Lang.getString("pointText1") + score + Lang.getString("pointText2");
            sceneLoader.GetComponent<SceneLoader>().addWordScore(score);
            sceneLoader.GetComponent<SceneLoader>().saveScores();
            if (gpgs.isSigned())
            {
                if (wrongWord == false)
                    gpgs.unlockAchivement("CgkIm6CK7OEHEAIQFA");
                if (score == 500)
                    gpgs.unlockAchivement("CgkIm6CK7OEHEAIQFQ");
                gpgs.postScore(score, "CgkIm6CK7OEHEAIQEA");
            }

        }

    }

    string wordChoose()
    {
        //Random kelime seçer.
        if (Lang.lang == 0)
            return wordArray[Random.Range(0, wordArray.Length - 41)];
        else
            return wordArray1[Random.Range(0, wordArray1.Length - 41)];
    }

    void wordsToScreen()
    {
        //Seçilen kelimeleri ekrana rastgele yazdırır.
        for (int i = 0; i < wordsTxt.Length; i++)
        {
            wordsTxt[i].GetComponent<Text>().text = wordChoose();
        }
    }

    void wordsToButton()
    {

        //Keliemeleri butonlara yazdırıp rastgele konum at.
        for (int i = 0; i < wordsTxt.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = wordsTxt[i].GetComponent<Text>().text;
        }
        for (int i = 0; i < differentWords.Length; i++)
        {
            if (Lang.lang == 0)
                differentWords[i].GetComponent<Text>().text = wordArray[Random.Range(wordArray.Length - 41, wordArray.Length)];
            else
                differentWords[i].GetComponent<Text>().text = wordArray1[Random.Range(wordArray1.Length - 41, wordArray1.Length)];
            buttons[i + 6].GetComponentInChildren<Text>().text = differentWords[i].GetComponent<Text>().text;
        }
    }

    public void countDown()
    {
        //sayaç

        timer--;
        timeMessage.GetComponent<Text>().text = Lang.getString("timeText1") + timer + " s";
        if (timer <= 0)
        {
            levels[1].SetActive(false);
            levels[2].SetActive(true);
            level2();
            CancelInvoke("countDown");
        }
    }

    public void countDown1()
    {
        //sayaç1
        timer1--;
        timeMessage1.GetComponent<Text>().text = Lang.getString("timeText1") + timer1 + " s";
        if (timer1 <= 0)
        {
            levels[2].SetActive(false);
            levels[3].SetActive(true);
            level3();
            CancelInvoke("countDown1");
        }
    }

    public void buttonListeners()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int n = i;
            buttons[i].GetComponent<Button>().onClick.AddListener(() =>
            {
                if (buttons[n].GetComponentInChildren<Text>().text == differentWords[0].GetComponent<Text>().text || buttons[n].GetComponentInChildren<Text>().text == differentWords[1].GetComponent<Text>().text)
                {
                    correctAnswers--;
                    wrongWord = true;
                }
                else
                {
                    correctAnswers++;
                    buttonPressed++;
                }
                buttons[n].SetActive(false);
            });
        }
    }

    public void Start()
    {


    }
    public void Update()
    {
        if (buttonPressed / 2 > 5)
        {
            levels[2].SetActive(false);
            levels[3].SetActive(true);
            level3();
            CancelInvoke("countDown1");
        }
    }
    public void setInfoUI()
    {
        
    }
    public void setEndUI()
    {
        
    }
    public void nextButtonClicked()
    {
        
    }
    public void OnGUI()
    {

    }
}
