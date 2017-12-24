using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Created by aliihsan.
/// </summary>

public class HowToPlay : MonoBehaviour {

    public GameObject title;
    public GameObject text;
    int index = 0;
    string[] texts = { Lang.getString("hwt1"), Lang.getString("hwt2"), Lang.getString("hwt3"), Lang.getString("hwt4"), Lang.getString("hwt5") };
	void Start () {
        text.GetComponent<Text>().text = texts[0];
        title.GetComponent<Text>().text = Lang.getString("howto");
	}

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            goBack();
	}

    public void prev()
    {
        index--;
        if (index == -1)
            index = texts.Length - 1;
        text.GetComponent<Text>().text = texts[index];
    }

    public void next()
    {
        index++;
        if (index == texts.Length)
            index = 0;
        text.GetComponent<Text>().text = texts[index];
    }

    public void goBack()
    {
        Initiate.Fade("menu", Color.black, 3.5f);
    }
}
