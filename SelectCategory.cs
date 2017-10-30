using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Created by aliihsan.
/// </summary>

//TODO:Ekrana kategorileri çizdir, eventlarını yaz, loadCategory metodunda ilgili parametreyi selectLevel scene'ine geçir

public class SelectCategory : MonoBehaviour {
	void Start () {
		
	}

	void Update () {
		
	}

	void OnGUI(){

	}

	public void loadCategory(string category){
        SceneManager.LoadScene(""); // Send catId
	}

    public void goBack()
    {
        SceneManager.LoadScene("menu");
    }
}
