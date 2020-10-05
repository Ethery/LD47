using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
	public static JumpPlayer Player;

	public int NumberOfLevel = 2;

	[HideInInspector]
	public int CurrentLevel = 0;

	public void BackToMenu()
	{
		SceneManager.LoadScene("MainMenu");
		UIManager.Show(UIManager.EPageType.MainMenu, true);
		UIManager.Show(UIManager.EPageType.DeathScreen, false);
		UIManager.Show(UIManager.EPageType.WinScreen, false);
		UIManager.Show(UIManager.EPageType.TutoPopup, false);
		UIManager.Show(UIManager.EPageType.Credits, false);
		UIManager.Show(UIManager.EPageType.NextLevel, false);
	}

	public bool HasNextLevel()
	{
		return CurrentLevel < NumberOfLevel;
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		UIManager.Show(UIManager.EPageType.MainMenu, false);
		UIManager.Show(UIManager.EPageType.DeathScreen, false);
		UIManager.Show(UIManager.EPageType.WinScreen, false);
		UIManager.Show(UIManager.EPageType.TutoPopup, false);
		UIManager.Show(UIManager.EPageType.Credits, false);
		UIManager.Show(UIManager.EPageType.NextLevel, false);
	}

	public void NextLevel()
	{
		CurrentLevel++;
		SceneManager.LoadScene("Level" + 5);
		UIManager.Show(UIManager.EPageType.MainMenu, false);
		UIManager.Show(UIManager.EPageType.DeathScreen, false);
		UIManager.Show(UIManager.EPageType.WinScreen, false);
		UIManager.Show(UIManager.EPageType.TutoPopup, false);
		UIManager.Show(UIManager.EPageType.Credits, false);
		UIManager.Show(UIManager.EPageType.NextLevel, false);
	}
}