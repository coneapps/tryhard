using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by aliihsan.
/// </summary>

//TODO:btn... methodlarını doldur, başlangıçta butonları ekrana çizdir ve eventlarını yaz.

public class Menu : MonoBehaviour {


	void Start () {
		
	}

	void Update () {
			
	}
		
	public void OnGUI(){


	}

	public void btnPlay(){
		Application.LoadLevel ("SelectCategory");
	}

	public void btnHow2Play(){
		Application.LoadLevel ("HowToPlay");

	}

	public void btnAchievements(){

	}

	public void btnLeaderBoards(){


	}

	public void btnStatistics(){
		Application.LoadLevel ("Statistics");
	}

	public void btnExit(){
		Application.Quit ();
	}


}
