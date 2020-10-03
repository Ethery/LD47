using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
	public void BackToMenu()
	{
		SceneManager.LoadScene("MainMenu");
		UIManager.Show(UIManager.EPageType.MainMenu, true);
	}
}