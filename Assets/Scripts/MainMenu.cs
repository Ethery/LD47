using UnityEditor;
using UnityEngine;

public class MainMenu : UIPage
{
	public void StartGame()
	{
		GameManager.Instance.NextLevel();
		UIManager.Show(UIManager.EPageType.MainMenu, false);
		TutoPopup.Show("Your goal is to go to the teleporter on the level.\n Try go right maybe ? ");
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