using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public void loadCategory(int catId){
		Application.LoadLevel ("");  //Send catId
	}

}
