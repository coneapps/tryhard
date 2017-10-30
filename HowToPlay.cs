using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Created by aliihsan.
/// </summary>

//TODO:Gerekli arayüzü ekrana çizdir.

public class HowToPlay : MonoBehaviour {
	void Start () {
		
	}

	void Update () {
		
	}

    public void goBack()
    {
        SceneManager.LoadScene("menu");
    }
}
