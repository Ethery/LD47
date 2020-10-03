using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void StartGame()
	{
		SceneManager.LoadScene("Level1");
	}

	public void StartCredits()
	{
		UIManager.Show(UIManager.EPage.Credits, true);
	}

	public void ExitGame()
	{
		Application.Quit();
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
#endif
	}

}
