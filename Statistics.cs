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

	void Start () {
        int IScore = PlayerPrefs.GetInt("iScore");
        int TapScore = PlayerPrefs.GetInt("tapScore");
        int TypeScore = PlayerPrefs.GetInt("typeScore");
        int WordScore = PlayerPrefs.GetInt("wordScore");
        int VisualScore = PlayerPrefs.GetInt("visualScore");
        message.GetComponent<Text>().text = "Best scores\nIntelligence: " + IScore + "\nTapping: " + TapScore + "\nTyping: " + TypeScore + "\nWord Memory: " + WordScore + "\nVisual Memory: " + VisualScore;
	}

    public void goBack()
    {
        SceneManager.LoadScene("menu");
    }
}
