using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
	public static JumpPlayer Player;

	public void BackToMenu()
	{
		SceneManager.LoadScene("MainMenu");
		UIManager.Show(UIManager.EPageType.MainMenu, true);
		UIManager.Show(UIManager.EPageType.DeathScreen, false);
		UIManager.Show(UIManager.EPageType.WinScreen, false);
		UIManager.Show(UIManager.EPageType.TutoPopup, false);
		UIManager.Show(UIManager.EPageType.Credits, false);
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		UIManager.Show(UIManager.EPageType.MainMenu, false);
		UIManager.Show(UIManager.EPageType.DeathScreen, false);
		UIManager.Show(UIManager.EPageType.WinScreen, false);
		UIManager.Show(UIManager.EPageType.TutoPopup, false);
		UIManager.Show(UIManager.EPageType.Credits, false);
	}
}