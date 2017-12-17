using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Created by aliihsan.
/// </summary>

//TODO:btn... methodlarını doldur, başlangıçta butonları ekrana çizdir ve eventlarını yaz.

public class Menu : MonoBehaviour {

	public TextAsset textAsset;

    GPGS gpgs = new GPGS();
    public GameObject settingsButtons;
    public GameObject signed;
    public GameObject unsigned;
    public GameObject tur;
    public GameObject eng;
    public GameObject muted;
    public GameObject unmuted;

    public void Authenticate()
    {
        if (gpgs.isSigned())
        {
            signed.SetActive(true);
            unsigned.SetActive(false);
        }
        else
        {
            signed.SetActive(false);
            unsigned.SetActive(true);
        }
        gpgs.sign();
    }
	void Start () {
        if (Lang.lang == 0)
            tur.SetActive(false);
        else
            eng.SetActive(false);

        if (gpgs.isSigned())
            unsigned.SetActive(false);
        else
            signed.SetActive(false);
	}

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            System.Diagnostics.Process.GetCurrentProcess().Kill();
	}
		
	public void OnGUI(){

	}

	public void btnPlay(){
		SceneManager.LoadScene("selectCategory");
	}

	public void btnHow2Play(){
		SceneManager.LoadScene("howToPlay");
	}

	public void btnAchievements(){
        gpgs.showAchievements();
	}

	public void btnLeaderBoards(){
        gpgs.showLeaderboards();
	}

	public void btnStatistics(){
		SceneManager.LoadScene("statistics");
	}

    public void btnSettings()
    {
		if (!settingsButtons.activeSelf)
			settingsButtons.SetActive (true);
        else 
			settingsButtons.SetActive (false);
	}

	public void changeLanguage()
    {
		if (PlayerPrefs.GetString("language").Equals("English")) 
        {
            Lang.setLanguage("Turkish", textAsset);
            tur.SetActive(true);
            eng.SetActive(false);
        }
        else
        {
            Lang.setLanguage("English", textAsset);
            tur.SetActive(false);
            eng.SetActive(true);
        }
    }

    public void btnVolume()
    {

    }
}
