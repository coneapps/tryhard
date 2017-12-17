using System;
using System.Collections;
using System.IO;
using System.Xml;

using UnityEngine;


public class Lang
{
	
    private static Hashtable Strings;
    public static int lang = 0;  //0=English, 1=Turkish

	public static void initiate(TextAsset textAsset)
    {
		if (PlayerPrefs.HasKey ("language")) 
		{
			setLanguage(PlayerPrefs.GetString ("language"), textAsset);
		} else {
			PlayerPrefs.SetString ("language", "English");
			setLanguage("English", textAsset);
		}
    }

	public static void setLanguage(string language, TextAsset textAsset)
    {
        if (language.ToLower().Equals("english"))
        {
            lang = 0;
			PlayerPrefs.SetString ("language","English");
        } 
		else if (language.ToLower().Equals("turkish"))
        {
            lang = 1;
			PlayerPrefs.SetString ("language","Turkish");
        }
        var xml = new XmlDocument();
		xml.LoadXml (textAsset.text);

        Strings = new Hashtable();
        var element = xml.DocumentElement[language];
        if (element != null)
        {
            var elemEnum = element.GetEnumerator();
            while (elemEnum.MoveNext())
            {
                var xmlItem = (XmlElement)elemEnum.Current;
                Strings.Add(xmlItem.GetAttribute("name"), xmlItem.InnerText);
            }
        }
        else
        {
            Debug.LogError("The specified language does not exist: " + language);
        }
    }

    public static string getString(string name)
    {
        if (!Strings.ContainsKey(name))
        {
            Debug.LogError("The specified string does not exist: " + name);

            return "";
        }

        return (string)Strings[name];
    }



}