using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Tapping : MonoBehaviour,IGameScene {

	SceneLoader sceneLoader;
	int level = 0;
	bool levelInitiated = false;

	float timeCounter=30;
	bool counterStarted = false;

	bool lvl1Active=false;
	public int touchCounter=0;


	public Tapping(SceneLoader sceneLoader){
		this.sceneLoader = sceneLoader;
	}

	public void Start () {

	}

	public void Update () {

		if (timeCounter <= 0) {
			levelInitiated = false;
			lvl1Active = false;
			counterStarted = false;
		} else {
			timeCounter -= Time.deltaTime;
		}

		if (!levelInitiated) {
			if (level < sceneLoader.tappingLevels.Length) {
				if (level != 0) {
					sceneLoader.tappingLevels [level - 1].SetActive (false);
				}
				sceneLoader.infoUI.SetActive (true);
				setInfoUI ();
				levelInitiated = true;
			} else {
				sceneLoader.tappingLevels [level - 1].SetActive (false);
				sceneLoader.endUI.SetActive (true);
				setEndUI ();
				sceneLoader.saveScores ();
			}
		}

		if (lvl1Active) {
			GameObject timeMessageText = GameObject.FindGameObjectsWithTag ("timeMessage") [0];
			timeMessageText.GetComponent<Text> ().text = "You have " + (int)timeCounter + " seconds left!";

			GameObject clickMessageText = GameObject.FindGameObjectsWithTag ("clickMessage") [0];
			clickMessageText.GetComponent<Text> ().text = "You touched " + (int)touchCounter + " times!";
		}
	}

	public void setInfoUI(){
		GameObject infoText = GameObject.FindGameObjectsWithTag("infoMessage")[0];
		infoText.GetComponent<Text> ().text = sceneLoader.tappingInfos[level];
	}
	public void setEndUI(){
		GameObject infoText = GameObject.FindGameObjectsWithTag("score")[0];
		infoText.GetComponent<Text> ().text = "You gained " + touchCounter + " points!";
	}

	public void nextButtonClicked(){

		sceneLoader.infoUI.SetActive (false);
		sceneLoader.tappingLevels [level].SetActive (true);

		level++;

		lvl1Active = true;
		counterStarted = true;
	}

	public void OnGUI(){


	}

}
