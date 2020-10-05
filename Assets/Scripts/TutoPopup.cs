using System.Collections.Generic;
using TMPro;

public class TutoPopup : UIPage
{
	public TextMeshProUGUI TextBox;

	public static void Show(string TextToShow)
	{
		List<UIPage> pages = UIManager.Show(UIManager.EPageType.TutoPopup, true);
		foreach (UIPage page in pages)
		{
			(page as TutoPopup).TextBox.text = TextToShow;
		}
	}

	private void Update()
	{
		if (GameManager.Player != null)
		{
			if (CurrentState == EState.Shown && GameManager.Player.CanMove)
			{
				GameManager.Player.CanMove = false;
			}
		}
	}

	public override void Show(bool aShow)
	{
		base.Show(aShow);
		if (GameManager.Player != null)
		{
			GameManager.Player.CanMove = !aShow;
		}
	}
}