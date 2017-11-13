using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual : MonoBehaviour,IGameScene {
	
	SceneLoader sceneLoader;
	int level = 0;
	public bool levelInitiated = false;

	public Visual(SceneLoader sceneLoader){
		this.sceneLoader = sceneLoader;
	}

	public void Start () {

	}

	public void Update () {
		
		if (!levelInitiated) {
			if (level < sceneLoader.visualMemoryLevels.Length) {
				if (level != 0) {
					sceneLoader.visualMemoryLevels [level - 1].SetActive (false);
				}
				sceneLoader.infoUI.SetActive (true);
				setInfoUI ();
				levelInitiated = true;
			} else {
				sceneLoader.visualMemoryLevels [level - 1].SetActive (false);
				sceneLoader.endUI.SetActive (true);
				setEndUI ();
				sceneLoader.saveScores ();
			}
		}




	}

	public void setInfoUI(){
		//TODO:İlgili verileri array'den çek ve text yerlerine bas.


	}
	public void setEndUI(){
		
	}

	public void nextButtonClicked(){
		//TODO:Info ekranını disable et, ilgili lvl ui'ini aktif et ve level değişkenini 1 arttır.
	}

	public void OnGUI(){




	}
}
