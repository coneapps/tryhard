using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by aliihsan.
/// </summary>

//TODO:Burada her gameScene'de olacak gui'ler çizdirilir!, tüm oyun içi sahnelerde olması gereken aynı gui'leri burda çizdir.

public class GameScene : MonoBehaviour {

	void Start () {
		
	}

	void Update () { 	
		
	}

	public void OnGUI(){

		GUI.Box (new Rect(0,0,100,30),"sadasd");

	}


}
