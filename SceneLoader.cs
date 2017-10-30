using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by aliihsan.
/// </summary>

//TODO:Burası levelleri başlatıp sonlandıran arayüz.Sadece level geçişleri için kullanılmalı!, level geçişlerini yaz.

public class SceneLoader : MonoBehaviour {

	level1 lvl1 = new level1 ();

	void Start () {
		lvl1.Start ();
	}

	void Update () {
		lvl1.Update ();
		
	}

	void OnGUI(){
		lvl1.OnGUI ();

	}

}
