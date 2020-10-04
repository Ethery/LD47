using System.Collections.Generic;
using UnityEngine.UI;

public class TutoPopup : UIPage
{
	public Text TextBox;

	public static void Show(string TextToShow)
	{
		List<UIPage> pages = UIManager.Show(UIManager.EPageType.TutoPopup, true);
		foreach (UIPage page in pages)
		{
			(page as TutoPopup).TextBox.text = TextToShow;
		}
	}

	public void ExitPopup()
	{
		UIManager.Show(UIManager.EPageType.TutoPopup, false);
	}
}