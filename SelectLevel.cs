using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by aliihsan.
/// </summary>

//TODO:gelen catId'ye göre ilgili levelleri ekrana çizdir, 
//sonra seçilen levele göre loadLevel metodunda gameScene scene'ine geç(with lvl param)

public class SelectLevel : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		
	}

	public void loadLevel(int level){
		Application.LoadLevel ("");  //Send level info
	}
}
