using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Created by aliihsan.
/// </summary>

//TODO:Introda bir süre bekle ve beklerken iconu döndür...

public class Introduction : MonoBehaviour {

    public GameObject exceptionMessage;
	public TextAsset textAsset;
    GPGS gpgs = new GPGS();

	void Start () {
        //Initiating Xml Multi-Lang Class
        try
        {
            Lang.initiate(textAsset);
        }
        catch (Exception ex)
        {
            exceptionMessage.GetComponent<Text>().text = ex.GetType() + ex.Message;
        }

        gpgs.Start();
        gpgs.sign();
        StartCoroutine(waitSeconds());
	}

	void Update () {
		
	}

	IEnumerator waitSeconds(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("menu");
	}
}
