using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Created by aliihsan.
/// </summary>

public class SelectCategory : MonoBehaviour {

    public GameObject cat1;
    public GameObject cat2;
    public GameObject cat3;
    public GameObject cat4;
    public GameObject cat5;

	void Start () {
        cat1.GetComponent<Text>().text = Lang.getString("cat1");
        cat2.GetComponent<Text>().text = Lang.getString("cat2");
        cat3.GetComponent<Text>().text = Lang.getString("cat3");
        cat4.GetComponent<Text>().text = Lang.getString("cat4");
        cat5.GetComponent<Text>().text = Lang.getString("cat5");
	}

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            goBack();
	}

	public void loadGameScene(int num)
    {
		SceneLoader.catId = num;
        SceneManager.LoadScene("gameScene");
    }


    public void goBack()
    {
		SceneManager.LoadScene("menu");
    }

}
