using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Created by aliihsan.
/// </summary>

//TODO:Statistics scene'ini burda oluştur.

public class Statistics : MonoBehaviour {
    public GameObject message;
    GPGS gpgs = new GPGS();
    int IScore;
    int TapScore;
    int TypeScore;
    int WordScore;
    int VisualScore;

	void Start() 
    {
        if (gpgs.isSigned())
        {
            gpgs.load("CgkIm6CK7OEHEAIQAQ", "iScore");
            gpgs.load("CgkIm6CK7OEHEAIQCA", "typeScore");
            gpgs.load("CgkIm6CK7OEHEAIQDA", "tapScore");
            gpgs.load("CgkIm6CK7OEHEAIQEA", "wordScore");
            gpgs.load("CgkIm6CK7OEHEAIQEQ", "visualScore");
        }
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            goBack();
        IScore = PlayerPrefs.GetInt("iScore");
        TapScore = PlayerPrefs.GetInt("tapScore");
        TypeScore = PlayerPrefs.GetInt("typeScore");
        WordScore = PlayerPrefs.GetInt("wordScore");
        VisualScore = PlayerPrefs.GetInt("visualScore");
        message.GetComponent<Text>().text = Lang.getString("line1") + "\n" + Lang.getString("line2") + IScore + "\n" + Lang.getString("line3") + TypeScore + "\n" + Lang.getString("line4") + TapScore + "\n" + Lang.getString("line5") + WordScore + "\n" + Lang.getString("line6") + VisualScore;
    }

    public void goBack()
    {
        Initiate.Fade("menu", Color.black, 3.5f);
    }
}
