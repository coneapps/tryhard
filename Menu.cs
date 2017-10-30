using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Created by aliihsan.
/// </summary>

//TODO:btn... methodlarını doldur, başlangıçta butonları ekrana çizdir ve eventlarını yaz.

public class Menu : MonoBehaviour {
    public void Authenticate()
    {
        // Sign in / out
    }
	void Start () {
		
	}

	void Update () {
			
	}
		
	public void OnGUI(){

	}

	public void btnPlay(){
		SceneManager.LoadScene("SelectCategory");
	}

	public void btnHow2Play(){
		SceneManager.LoadScene("HowToPlay");
	}

	public void btnAchievements(){

	}

	public void btnLeaderBoards(){

	}

	public void btnStatistics(){
		SceneManager.LoadScene("Statistics");
	}

	public void btnExit(){
		Application.Quit ();
	}
}
