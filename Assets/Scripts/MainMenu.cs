using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public void StartGame()
	{

	}

	public void StartCredits()
	{
		UIPage.Show(UIPage.EPage.Credits, true);
	}

	public void ExitGame()
	{
		Application.Quit();
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
#endif
	}

}
