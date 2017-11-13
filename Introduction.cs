using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Created by aliihsan.
/// </summary>

//TODO:Introda bir süre bekle ve beklerken iconu döndür...

public class Introduction : MonoBehaviour {
	void Start () {
        StartCoroutine(waitSeconds());
	}

	void Update () {
		
	}

	IEnumerator waitSeconds(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("menu");
	}
}
