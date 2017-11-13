using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by aliihsan.
/// </summary>

public interface IGameScene {
	void Start ();

	void Update ();

	void OnGUI ();

	void setInfoUI ();

	void setEndUI ();

	void nextButtonClicked();

}
