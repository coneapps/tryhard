using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visual : MonoBehaviour, IGameScene
{

    GPGS gpgs = new GPGS();

    public GameObject sceneLoader;
    public GameObject[] levels;
    public Sprite[] sprites;
    public GameObject[] spritesGO;
    public GameObject spriteScreen;
    public Sprite[] rightSprites;
    public Sprite[] wrongSprites;
    public GameObject timeMessage;
    public GameObject[] rightButton;
    public GameObject[] wrongButtons;
    public GameObject[] wrongButtons1;
    public GameObject[] wrongButtons2;
    public GameObject[] wrongButtons3;
    public GameObject[] wrongButtons4;
    public GameObject[] infoMessages;
    public GameObject[] vislvl2levels;
    public GameObject retryBtn;
    public GameObject scoreText;

    int timer = 0;
    int correctAnswers = 0;


    public GameObject[] rightbuttonSprite;

    private void OnEnable()
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
            GameObject infoTxt = GameObject.FindGameObjectWithTag("infoMessage");
            infoTxt.GetComponent<Text>().text = Lang.getString("visualText10");
            GameObject startButton = GameObject.FindGameObjectWithTag("startButton");
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

            timer = 5;
            spriteToScreen();
            InvokeRepeating("countDown", 0, 1);

        }
    }

    public void level2()
    {
        for (int i = 0; i < rightbuttonSprite.Length; i++)
        {
            rightbuttonSprite[i].SetActive(false);
        }
        if (levels[2].activeSelf == true)
        {
            levels[0].SetActive(false);
            levels[1].SetActive(false);
            levels[3].SetActive(false);

            vislvl2levels[0].SetActive(true);
            vislvl2levels[1].SetActive(false);
            vislvl2levels[2].SetActive(false);
            vislvl2levels[3].SetActive(false);
            vislvl2levels[4].SetActive(false);

            vislevel2_4();
            vislevel2_3();
            vislevel2_2();
            vislevel2_1();
            vislevel2_0();



        }

    }

    public void level3()
    {
        if (levels[3].activeSelf == true)
        {
            levels[0].SetActive(false);
            levels[1].SetActive(false);
            levels[2].SetActive(false);
            levels[3].SetActive(true);
            int score = (correctAnswers * 50 + 750);
            scoreText.GetComponent<Text>().text = Lang.getString("pointText1") + score + Lang.getString("pointText2");
            sceneLoader.GetComponent<SceneLoader>().addVisualScore(score);
            sceneLoader.GetComponent<SceneLoader>().saveScores();
            if (gpgs.isSigned())
            {
                if (correctAnswers <= 0)
                    gpgs.unlockAchivement("CgkIm6CK7OEHEAIQEg");
                if (correctAnswers == 5)
                    gpgs.unlockAchivement("CgkIm6CK7OEHEAIQEw");
                gpgs.postScore(score, "CgkIm6CK7OEHEAIQEQ");
            }

        }

    }

    public void vislevel2_0()
    {
        vislvl2levels[0].SetActive(true);
        vislvl2levels[1].SetActive(false);
        vislvl2levels[2].SetActive(false);
        vislvl2levels[3].SetActive(false);
        vislvl2levels[4].SetActive(false);

        if (vislvl2levels[0].activeSelf == true)
        {
            wrongButtonListeners();
            colorsToButtons();
            spritesGOToButton();

            infoMessages[0].GetComponent<Text>().text = Lang.getString("visualText3");
            rightButton[0].GetComponent<Button>().onClick.AddListener(() =>
            {
                correctAnswers++;
                vislvl2levels[0].SetActive(false);
                vislvl2levels[1].SetActive(true);
            });

        }
    }

    public void vislevel2_1()
    {
        vislvl2levels[0].SetActive(false);
        vislvl2levels[1].SetActive(true);
        vislvl2levels[2].SetActive(false);
        vislvl2levels[3].SetActive(false);
        vislvl2levels[4].SetActive(false);

        if (vislvl2levels[1].activeSelf == true)
        {
            colorsToButtons();
            wrongButtonListeners();
            spritesGOToButton();

            infoMessages[1].GetComponent<Text>().text = Lang.getString("visualText4");
            rightButton[1].GetComponent<Button>().onClick.AddListener(() =>
            {
                correctAnswers++;
                vislvl2levels[1].SetActive(false);
                vislvl2levels[2].SetActive(true);
            });

        }
    }

    public void vislevel2_2()
    {
        vislvl2levels[0].SetActive(false);
        vislvl2levels[1].SetActive(false);
        vislvl2levels[2].SetActive(true);
        vislvl2levels[3].SetActive(false);
        vislvl2levels[4].SetActive(false);

        if (vislvl2levels[2].activeSelf == true)
        {
            colorsToButtons();
            wrongButtonListeners();
            spritesGOToButton();

            infoMessages[2].GetComponent<Text>().text = Lang.getString("visualText5");
            rightButton[2].GetComponent<Button>().onClick.AddListener(() =>
            {
                correctAnswers++;
                vislvl2levels[2].SetActive(false);
                vislvl2levels[3].SetActive(true);
            });

        }
    }

    public void vislevel2_3()
    {
        vislvl2levels[0].SetActive(false);
        vislvl2levels[1].SetActive(false);
        vislvl2levels[2].SetActive(false);
        vislvl2levels[3].SetActive(true);
        vislvl2levels[4].SetActive(false);
        if (vislvl2levels[3].activeSelf == true)
        {
            colorsToButtons();
            wrongButtonListeners();
            spritesGOToButton();

            infoMessages[3].GetComponent<Text>().text = Lang.getString("visualText6");
            rightButton[3].GetComponent<Button>().onClick.AddListener(() =>
            {
                correctAnswers++;
                vislvl2levels[3].SetActive(false);
                vislvl2levels[4].SetActive(true);
            });

        }
    }

    public void vislevel2_4()
    {
        vislvl2levels[0].SetActive(false);
        vislvl2levels[1].SetActive(false);
        vislvl2levels[2].SetActive(false);
        vislvl2levels[3].SetActive(false);
        vislvl2levels[4].SetActive(true);
        if (vislvl2levels[4].activeSelf == true)
        {
            colorsToButtons();
            wrongButtonListeners();
            spritesGOToButton();

            infoMessages[4].GetComponent<Text>().text = Lang.getString("visualText7");
            rightButton[4].GetComponent<Button>().onClick.AddListener(() =>
            {
                correctAnswers++;
                vislvl2levels[4].SetActive(false);
                levels[2].SetActive(false);
                levels[3].SetActive(true);
                level3();
            });

        }
    }



    public Visual()
    {
    }



    Sprite randomrightSprite()
    {
        return sprites[Random.Range(0, sprites.Length - 9)];
    }

    public void spriteToScreen()
    {
        for (int i = 0; i < spritesGO.Length; i++)
        {
            spritesGO[i].GetComponent<Image>().sprite = randomrightSprite();
            spriteCheck();
            spriteScreen = spritesGO[i];
        }
    }

    public void countDown()
    {
        //sayaç
        spritesGO[timer].SetActive(false);
        timer--;
        timeMessage.GetComponent<Text>().text = Lang.getString("timeText1") + timer + " s";


        if (timer < 0)
        {
            levels[1].SetActive(false);
            levels[2].SetActive(true);
            level2();
            CancelInvoke("countDown");
        }
    }

    public void spriteCheck()
    {
        for (int i = 0; i < spritesGO.Length - 1; i++)
        {
            if (spritesGO[i].GetComponent<Image>().sprite == spritesGO[i + 1].GetComponent<Image>().sprite)
            {
                spritesGO[i].GetComponent<Image>().sprite = randomrightSprite();
            }
        }
    }

    public void spritesGOToButton()
    {
        if (vislvl2levels[0].activeSelf == true)
        {
            for (int j = 0; j < sprites.Length - 9; j++)
            {
                if (spritesGO[4].GetComponent<Image>().sprite == sprites[j])
                {
                    rightbuttonSprite[4].GetComponent<Image>().sprite = rightSprites[j];
                }
            }
        }
        else if (vislvl2levels[1].activeSelf == true)
        {
            for (int j = 0; j < sprites.Length - 9; j++)
            {
                if (spritesGO[3].GetComponent<Image>().sprite == sprites[j])
                {
                    rightbuttonSprite[3].GetComponent<Image>().sprite = rightSprites[j];
                }
            }
        }
        else if (vislvl2levels[2].activeSelf == true)
        {
            for (int j = 0; j < sprites.Length - 9; j++)
            {
                if (spritesGO[2].GetComponent<Image>().sprite == sprites[j])
                {
                    rightbuttonSprite[2].GetComponent<Image>().sprite = rightSprites[j];
                }
            }
        }
        else if (vislvl2levels[3].activeSelf == true)
        {
            for (int j = 0; j < sprites.Length - 9; j++)
            {
                if (spritesGO[1].GetComponent<Image>().sprite == sprites[j])
                {
                    rightbuttonSprite[1].GetComponent<Image>().sprite = rightSprites[j];
                }
            }
        }
        else if (vislvl2levels[4].activeSelf == true)
        {
            for (int j = 0; j < sprites.Length - 9; j++)
            {
                if (spritesGO[0].GetComponent<Image>().sprite == sprites[j])
                {
                    rightbuttonSprite[0].GetComponent<Image>().sprite = rightSprites[j];
                }
            }
        }
    }

    public void colorsToButtons()
    {
        if (vislvl2levels[0].activeSelf == true)
        {
            spritesGOToButton();
            rightButton[0].GetComponent<Image>().sprite = rightbuttonSprite[4].GetComponent<Image>().sprite;
            wrongButtonCheck();
            randomizeButtonPos();
        }
        else if (vislvl2levels[1].activeSelf == true)
        {
            spritesGOToButton();
            rightButton[1].GetComponent<Image>().sprite = rightbuttonSprite[3].GetComponent<Image>().sprite;
            wrongButtonCheck();
            randomizeButtonPos();
        }
        else if (vislvl2levels[2].activeSelf == true)
        {
            spritesGOToButton();
            rightButton[2].GetComponent<Image>().sprite = rightbuttonSprite[2].GetComponent<Image>().sprite;
            wrongButtonCheck();
            randomizeButtonPos();
        }
        else if (vislvl2levels[3].activeSelf == true)
        {
            spritesGOToButton();
            rightButton[3].GetComponent<Image>().sprite = rightbuttonSprite[1].GetComponent<Image>().sprite;
            wrongButtonCheck();
            randomizeButtonPos();
        }
        else if (vislvl2levels[4].activeSelf == true)
        {
            spritesGOToButton();
            rightButton[4].GetComponent<Image>().sprite = rightbuttonSprite[0].GetComponent<Image>().sprite;
            wrongButtonCheck();
            randomizeButtonPos();
        }
    }

    public void randomizeButtonPos()
    {
        if (vislvl2levels[0].activeSelf == true)
        {
            RectTransform transform = rightButton[0].gameObject.transform as RectTransform;
            Vector2 position = transform.anchoredPosition;
            transform.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            RectTransform transform1 = wrongButtons[0].gameObject.transform as RectTransform;
            Vector2 position1 = transform1.anchoredPosition;
            transform1.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            RectTransform transform2 = wrongButtons[1].gameObject.transform as RectTransform;
            Vector2 position2 = transform2.anchoredPosition;
            transform2.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            RectTransform transform3 = wrongButtons[2].gameObject.transform as RectTransform;
            Vector2 position3 = transform3.anchoredPosition;
            transform3.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            for (int i = 24; 0 <= i; i--)
            {
                while (transform.anchoredPosition.y == transform1.anchoredPosition.y || transform.anchoredPosition.y == transform2.anchoredPosition.y || transform.anchoredPosition.y == transform3.anchoredPosition.y)
                {
                    transform.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
                while (transform1.anchoredPosition.y == transform.anchoredPosition.y || transform1.anchoredPosition.y == transform2.anchoredPosition.y || transform1.anchoredPosition.y == transform3.anchoredPosition.y)
                {
                    transform1.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
                while (transform2.anchoredPosition.y == transform.anchoredPosition.y || transform2.anchoredPosition.y == transform1.anchoredPosition.y || transform2.anchoredPosition.y == transform3.anchoredPosition.y)
                {
                    transform2.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
                while (transform3.anchoredPosition.y == transform.anchoredPosition.y || transform3.anchoredPosition.y == transform1.anchoredPosition.y || transform3.anchoredPosition.y == transform2.anchoredPosition.y)
                {
                    transform3.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
            }
        }
        else if (vislvl2levels[1].activeSelf == true)
        {
            RectTransform transform4 = rightButton[1].gameObject.transform as RectTransform;
            Vector2 position4 = transform4.anchoredPosition;
            transform4.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            RectTransform transform5 = wrongButtons1[0].gameObject.transform as RectTransform;
            Vector2 position5 = transform5.anchoredPosition;
            transform5.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            RectTransform transform6 = wrongButtons1[1].gameObject.transform as RectTransform;
            Vector2 position6 = transform6.anchoredPosition;
            transform6.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            RectTransform transform7 = wrongButtons1[2].gameObject.transform as RectTransform;
            Vector2 position7 = transform7.anchoredPosition;
            transform7.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            for (int i = 24; 0 <= i; i--)
            {
                while (transform4.anchoredPosition.y == transform5.anchoredPosition.y || transform4.anchoredPosition.y == transform6.anchoredPosition.y || transform4.anchoredPosition.y == transform7.anchoredPosition.y)
                {
                    transform4.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
                while (transform5.anchoredPosition.y == transform4.anchoredPosition.y || transform5.anchoredPosition.y == transform6.anchoredPosition.y || transform5.anchoredPosition.y == transform7.anchoredPosition.y)
                {
                    transform5.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
                while (transform6.anchoredPosition.y == transform4.anchoredPosition.y || transform6.anchoredPosition.y == transform5.anchoredPosition.y || transform6.anchoredPosition.y == transform7.anchoredPosition.y)
                {
                    transform6.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
                while (transform7.anchoredPosition.y == transform4.anchoredPosition.y || transform7.anchoredPosition.y == transform5.anchoredPosition.y || transform7.anchoredPosition.y == transform6.anchoredPosition.y)
                {
                    transform7.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
            }
        }
        else if (vislvl2levels[2].activeSelf == true)
        {
            RectTransform transform8 = rightButton[2].gameObject.transform as RectTransform;
            Vector2 position8 = transform8.anchoredPosition;
            transform8.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            RectTransform transform9 = wrongButtons2[0].gameObject.transform as RectTransform;
            Vector2 position9 = transform9.anchoredPosition;
            transform9.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            RectTransform transform10 = wrongButtons2[1].gameObject.transform as RectTransform;
            Vector2 position10 = transform10.anchoredPosition;
            transform10.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            RectTransform transform11 = wrongButtons2[2].gameObject.transform as RectTransform;
            Vector2 position11 = transform11.anchoredPosition;
            transform11.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            for (int i = 24; 0 <= i; i--)
            {
                while (transform8.anchoredPosition.y == transform9.anchoredPosition.y || transform8.anchoredPosition.y == transform10.anchoredPosition.y || transform8.anchoredPosition.y == transform11.anchoredPosition.y)
                {
                    transform8.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
                while (transform9.anchoredPosition.y == transform8.anchoredPosition.y || transform9.anchoredPosition.y == transform10.anchoredPosition.y || transform9.anchoredPosition.y == transform11.anchoredPosition.y)
                {
                    transform9.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
                while (transform10.anchoredPosition.y == transform8.anchoredPosition.y || transform10.anchoredPosition.y == transform9.anchoredPosition.y || transform10.anchoredPosition.y == transform11.anchoredPosition.y)
                {
                    transform10.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
                while (transform11.anchoredPosition.y == transform8.anchoredPosition.y || transform11.anchoredPosition.y == transform9.anchoredPosition.y || transform11.anchoredPosition.y == transform10.anchoredPosition.y)
                {
                    transform11.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
            }
        }
        else if (vislvl2levels[3].activeSelf == true)
        {
            RectTransform transform12 = rightButton[3].gameObject.transform as RectTransform;
            Vector2 position12 = transform12.anchoredPosition;
            transform12.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            RectTransform transform13 = wrongButtons3[0].gameObject.transform as RectTransform;
            Vector2 position1 = transform13.anchoredPosition;
            transform13.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            RectTransform transform14 = wrongButtons3[1].gameObject.transform as RectTransform;
            Vector2 position14 = transform14.anchoredPosition;
            transform14.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            RectTransform transform15 = wrongButtons3[2].gameObject.transform as RectTransform;
            Vector2 position15 = transform15.anchoredPosition;
            transform15.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            for (int i = 24; 0 <= i; i--)
            {
                while (transform12.anchoredPosition.y == transform13.anchoredPosition.y || transform12.anchoredPosition.y == transform14.anchoredPosition.y || transform12.anchoredPosition.y == transform15.anchoredPosition.y)
                {
                    transform12.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
                while (transform13.anchoredPosition.y == transform12.anchoredPosition.y || transform13.anchoredPosition.y == transform14.anchoredPosition.y || transform13.anchoredPosition.y == transform15.anchoredPosition.y)
                {
                    transform13.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
                while (transform14.anchoredPosition.y == transform12.anchoredPosition.y || transform14.anchoredPosition.y == transform13.anchoredPosition.y || transform14.anchoredPosition.y == transform15.anchoredPosition.y)
                {
                    transform14.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
                while (transform15.anchoredPosition.y == transform12.anchoredPosition.y || transform15.anchoredPosition.y == transform13.anchoredPosition.y || transform15.anchoredPosition.y == transform14.anchoredPosition.y)
                {
                    transform15.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
            }
        }
        else if (vislvl2levels[4].activeSelf == true)
        {
            RectTransform transform16 = rightButton[4].gameObject.transform as RectTransform;
            Vector2 position16 = transform16.anchoredPosition;
            transform16.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            RectTransform transform17 = wrongButtons4[0].gameObject.transform as RectTransform;
            Vector2 position17 = transform17.anchoredPosition;
            transform17.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            RectTransform transform18 = wrongButtons4[1].gameObject.transform as RectTransform;
            Vector2 position18 = transform18.anchoredPosition;
            transform17.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            RectTransform transform19 = wrongButtons4[2].gameObject.transform as RectTransform;
            Vector2 position19 = transform19.anchoredPosition;
            transform19.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));

            for (int i = 24; 0 <= i; i--)
            {
                while (transform16.anchoredPosition.y == transform17.anchoredPosition.y || transform16.anchoredPosition.y == transform18.anchoredPosition.y || transform16.anchoredPosition.y == transform19.anchoredPosition.y)
                {
                    transform16.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
                while (transform17.anchoredPosition.y == transform16.anchoredPosition.y || transform17.anchoredPosition.y == transform18.anchoredPosition.y || transform17.anchoredPosition.y == transform19.anchoredPosition.y)
                {
                    transform17.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
                while (transform18.anchoredPosition.y == transform16.anchoredPosition.y || transform18.anchoredPosition.y == transform17.anchoredPosition.y || transform18.anchoredPosition.y == transform19.anchoredPosition.y)
                {
                    transform18.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
                while (transform19.anchoredPosition.y == transform16.anchoredPosition.y || transform19.anchoredPosition.y == transform17.anchoredPosition.y || transform19.anchoredPosition.y == transform18.anchoredPosition.y)
                {
                    transform19.anchoredPosition = new Vector2(0, (-40 * Random.Range(0, 4)));
                }
            }
        }
    }

    public void wrongButtonCheck()
    {

        if (vislvl2levels[0].activeSelf == true)
        {
            for (int i = 0; i < wrongButtons.Length; i++)
            {
                for (int j = wrongButtons.Length - 1; 0 < j; j--)
                {
                    if (wrongButtons[i].GetComponent<Image>().sprite == wrongButtons[j].GetComponent<Image>().sprite)
                    {
                        wrongButtons[i].GetComponent<Image>().sprite = wrongSprites[Random.Range(0, wrongSprites.Length - 1)];
                    }
                }
            }
        }
        else if (vislvl2levels[1].activeSelf == true)
        {
            for (int i = 0; i < wrongButtons1.Length; i++)
            {
                for (int j = wrongButtons1.Length - 1; 0 < j; j--)
                {
                    if (wrongButtons1[i].GetComponent<Image>().sprite == wrongButtons1[j].GetComponent<Image>().sprite)
                    {
                        wrongButtons1[i].GetComponent<Image>().sprite = wrongSprites[Random.Range(0, wrongSprites.Length - 1)];
                    }
                }
            }
        }
        else if (vislvl2levels[2].activeSelf == true)
        {
            for (int i = 0; i < wrongButtons2.Length; i++)
            {
                for (int j = wrongButtons2.Length - 1; 0 < j; j--)
                {
                    if (wrongButtons2[i].GetComponent<Image>().sprite == wrongButtons2[j].GetComponent<Image>().sprite)
                    {
                        wrongButtons2[i].GetComponent<Image>().sprite = wrongSprites[Random.Range(0, wrongSprites.Length - 1)];
                    }
                }
            }
        }
        else if (vislvl2levels[3].activeSelf == true)
        {
            for (int i = 0; i < wrongButtons3.Length; i++)
            {
                for (int j = wrongButtons3.Length - 1; 0 < j; j--)
                {
                    if (wrongButtons3[i].GetComponent<Image>().sprite == wrongButtons3[j].GetComponent<Image>().sprite)
                    {
                        wrongButtons3[i].GetComponent<Image>().sprite = wrongSprites[Random.Range(0, wrongSprites.Length - 1)];
                    }
                }
            }
        }
        else if (vislvl2levels[4].activeSelf == true)
        {
            for (int i = 0; i < wrongButtons4.Length; i++)
            {
                for (int j = wrongButtons4.Length - 1; 0 < j; j--)
                {
                    if (wrongButtons4[i].GetComponent<Image>().sprite == wrongButtons4[j].GetComponent<Image>().sprite)
                    {
                        wrongButtons4[i].GetComponent<Image>().sprite = wrongSprites[Random.Range(0, wrongSprites.Length - 1)];
                    }
                }
            }
        }


    }

    public void wrongButtonListeners()
    {
        if (vislvl2levels[0].activeSelf == true)
        {
            foreach (GameObject go in wrongButtons)
            {
                go.GetComponent<Button>().onClick.AddListener(() =>
                {
                    go.SetActive(false);
                    correctAnswers--;
                });
            }
        }
        else if (vislvl2levels[1].activeSelf == true)
        {
            foreach (GameObject go in wrongButtons1)
            {
                go.GetComponent<Button>().onClick.AddListener(() =>
                {
                    go.SetActive(false);
                    correctAnswers--;
                });
            }
        }
        else if (vislvl2levels[2].activeSelf == true)
        {
            foreach (GameObject go in wrongButtons2)
            {
                go.GetComponent<Button>().onClick.AddListener(() =>
                {
                    go.SetActive(false);
                    correctAnswers--;
                });
            }
        }
        else if (vislvl2levels[3].activeSelf == true)
        {
            foreach (GameObject go in wrongButtons3)
            {
                go.GetComponent<Button>().onClick.AddListener(() =>
                {
                    go.SetActive(false);
                    correctAnswers--;
                });
            }
        }
        else if (vislvl2levels[4].activeSelf == true)
        {
            foreach (GameObject go in wrongButtons4)
            {
                go.GetComponent<Button>().onClick.AddListener(() =>
                {
                    go.SetActive(false);
                    correctAnswers--;
                });
            }
        }
    }


    public void Start()
    {

    }
    public void Update()
    {
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