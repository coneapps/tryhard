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
    GameObject audio;

    public void Authenticate()
    {
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
        audio = GameObject.FindGameObjectWithTag("audio");
        if (audio.GetComponent<AudioSource>().isPlaying)
            muted.SetActive(false);
        else
            unmuted.SetActive(false);
	}

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            System.Diagnostics.Process.GetCurrentProcess().Kill();
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
	}

	public void btnPlay(){
        Initiate.Fade("selectCategory", Color.black, 3.5f);
	}

	public void btnHow2Play(){
        Initiate.Fade("howToPlay", Color.black, 3.5f);
	}

	public void btnAchievements(){
        gpgs.showAchievements();
	}

	public void btnLeaderBoards(){
        gpgs.showLeaderboards();
	}

	public void btnStatistics(){
        Initiate.Fade("statistics", Color.black, 3.5f);
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
        if (audio.GetComponent<AudioSource>().isPlaying) {
            audio.GetComponent<AudioSource>().Stop();
            muted.SetActive(true);
            unmuted.SetActive(false);
        } 
        else 
        {
            audio.GetComponent<AudioSource>().Play();
            muted.SetActive(false);
            unmuted.SetActive(true);
        }
    }
}
