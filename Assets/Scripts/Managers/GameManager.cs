using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
	public static JumpPlayer Player;

	public void BackToMenu()
	{
		SceneManager.LoadScene("MainMenu");
		UIManager.Show(UIManager.EPageType.MainMenu, true);
	}
}