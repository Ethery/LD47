﻿using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : UIPage
{
	public void StartGame()
	{
		SceneManager.LoadScene("Level1");
		UIManager.Show(UIManager.EPageType.MainMenu, false);
		TutoPopup.Show("Your goal is to go to the teleporter on the level.");
	}

	public void StartCredits()
	{
		UIManager.Show(UIManager.EPageType.Credits, true);
	}

	public void ExitGame()
	{
		Application.Quit();
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
#endif
	}
}