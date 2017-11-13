using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Typing : MonoBehaviour,IGameScene {

	SceneLoader sceneLoader;
	int level = 0;
	bool levelInitiated = false;
	int j=0;
	GameObject yourWordText;
	GameObject wordListText;
	int wordCounter=0;
	bool lvl1Active = false, arrayUpdated = false;

	float timeCounter = 30;
	bool counterStarted = false;

	string[] wordList = {"apple","come","walking","car","rest","door","gone","flying","school","informations","there", "here", "very", "open", "while",
                        "make", "leave", "house", "really", "large", "came", "word", "children", "above", "different", "sometimes", "quick", "thought",
                        "father", "river", "near", "always", "some", "window"};
	string word;
	string[] choosenWordList = new string[5];

	public Typing(SceneLoader sceneLoader){
		this.sceneLoader = sceneLoader;
	}

	public void Start () {

	}

	public void addLetter(string c){
		word += c;
		yourWordText.GetComponent<Text>().text = word;
		checkWord ();
	}

	public void deleteLetter(){
        if (word.Length > 0)
        {
            word = word.Substring(0, word.Length - 1);
            yourWordText.GetComponent<Text>().text = word;
            checkWord();
        }
	}

	void checkWord(){
		if (word == choosenWordList [j]) {
			yourWordText.GetComponent<Text> ().text = "";
			word = "";
			//Gives score
			wordCounter++;
			sceneLoader.addTypingScore (1);
			if (j == 4) {
				updateArray ();
				j = 0;
			} else {
				j++;
				//Remove word from text
				wordListText.GetComponent<Text> ().text = wordListText.GetComponent<Text> ().text.Remove(0, wordListText.GetComponent<Text> ().text.IndexOf(' ') + 1);
			}
		} else {
			//Nothing happens...(user gotta write it right!)
		}
	}

	void updateArray(){
		wordListText.GetComponent<Text> ().text = "";
		for (int i = 0; i < 5; i++) {
			choosenWordList [i] = chooseWord();   //choosenWordList [0-1-2-3-4]   5 elements filled
			wordListText.GetComponent<Text> ().text += choosenWordList [i] + " ";
		}
	}

	string chooseWord(){
		return wordList[Random.Range (0, wordList.Length - 1)];
	}

	public void Update () {
	
		if (counterStarted) {
			if (timeCounter <= 0) {
				levelInitiated = false;
				lvl1Active = false;
				counterStarted = false;
			} else {
				timeCounter -= Time.deltaTime;
			}
		}


		if (!levelInitiated) {
			if (level < sceneLoader.typingLevels.Length) {
				if (level != 0) {
					sceneLoader.typingLevels [level - 1].SetActive (false);
				}
				sceneLoader.infoUI.SetActive (true);
				setInfoUI ();
				levelInitiated = true;
			} else {
				sceneLoader.typingLevels [level - 1].SetActive (false);
				sceneLoader.endUI.SetActive (true);
				setEndUI ();
				sceneLoader.saveScores ();
			}
		}

		if (lvl1Active) {
			wordListText = GameObject.FindGameObjectsWithTag ("wordlist")[0];
			yourWordText = GameObject.FindGameObjectsWithTag ("yourWord") [0];
			//Levelin başlangıcında wordList doldurulur!
			if (!arrayUpdated) {
				updateArray ();
				arrayUpdated = true;
			}
		}

	}

	public void setInfoUI(){
		GameObject infoText = GameObject.FindGameObjectsWithTag("infoMessage")[0];
		infoText.GetComponent<Text> ().text = sceneLoader.typingInfos[level];
	}
	public void setEndUI(){
		GameObject infoText = GameObject.FindGameObjectsWithTag("score")[0];
		infoText.GetComponent<Text> ().text = "You gained " + wordCounter + " points!";
	}

	public void nextButtonClicked(){

		sceneLoader.infoUI.SetActive (false);
		sceneLoader.typingLevels [level].SetActive (true);

		level++;

		lvl1Active = true;
		counterStarted = true;
	}

	public void OnGUI(){


	}
}
