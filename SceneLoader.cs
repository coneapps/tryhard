using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by aliihsan.
/// </summary>

//TODO:Burası levelleri başlatıp sonlandıran arayüz.Sadece level geçişleri için kullanılmalı!, level geçişlerini yaz.

public class SceneLoader : MonoBehaviour {

	public static int catId = -1;  //Default = -1 for null value


	public string[] intelligenceInfos;
	public string[] tappingInfos;
	public string[] typingInfos;
	public string[] wordInfos;
	public string[] visualInfos;

	public GameObject[] intelligenceLevels;
	public GameObject[] tappingLevels;
	public GameObject[] typingLevels;
	public GameObject[] wordMemoryLevels;
	public GameObject[] visualMemoryLevels;

	public GameObject infoUI;
	public GameObject endUI;

	private IGameScene gameScene;

	private int iScore;
	private int typeScore;
	private int tappScore;
	private int wordScore;
	private int visualScore;

	void Start () {
		
		switch (catId) {
		case -1:
			Application.Quit ();
			break;
		case 0:
			//gameScene = new Intelligence ();
			intelligenceLevels[0].SetActive(true);
			break;
		case 1:
			gameScene = new Typing (this);
			break;
		case 2:
			gameScene = new Tapping (this);
			break;
		case 3:
			gameScene = new Word (this);
			break;
		case 4:
			gameScene = new Visual (this);
			break;
		}

		if (gameScene != null) {
			gameScene.Start ();
		}
	}

	void Update () {
		if (gameScene != null) {
			gameScene.Update ();
		}


	}

	void OnGUI(){
		if (gameScene != null) {
			gameScene.OnGUI ();
		}


	}

	#region Sends data to gameScene class(tapping)
	public void increaseTouchCounter(){
		(gameScene as Tapping).touchCounter++;
	}


	#endregion

	#region Sends data to gameScene class(typing)
	public void addLetter(string c){
		(gameScene as Typing).addLetter (c);
	}

	public void deleteLetter(){
		(gameScene as Typing).deleteLetter ();
	}
	#endregion


	public void nextLvl(){
		gameScene.nextButtonClicked ();
	}


	#region Score Management methods
	public void addIntelligenceScore(int score){
		iScore += score;
	}
	public void addTappingScore(int score){
		tappScore += score;
	}
	public void addTypingScore(int score){
		typeScore += score;
	}
	public void addWordScore(int score){
		wordScore += score;
	}
	public void addVisualScore(int score){
		visualScore += score;
	}

	public void saveScores(){
		int prevIScore = PlayerPrefs.GetInt ("iScore");
		int prevTapScore = PlayerPrefs.GetInt ("tapScore");
		int prevTypeScore = PlayerPrefs.GetInt ("typeScore");
		int prevWordScore = PlayerPrefs.GetInt ("wordScore");
		int prevVisualScore = PlayerPrefs.GetInt ("visualScore");

		if (iScore > prevIScore) {
			PlayerPrefs.SetInt ("iScore",iScore);
		}
		if (tappScore > prevTapScore) {
			PlayerPrefs.SetInt ("tapScore",tappScore);
		}
		if (typeScore > prevTypeScore) {
			PlayerPrefs.SetInt ("typeScore",typeScore);
		}
		if (wordScore > prevWordScore) {
			PlayerPrefs.SetInt ("wordScore",wordScore);
		}
		if (visualScore > prevVisualScore) {
			PlayerPrefs.SetInt ("visualScore",visualScore);
		}
	}
	#endregion

}
