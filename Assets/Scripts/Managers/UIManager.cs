using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
	public enum EPageType
	{
		MainMenu,
		Credits,
		DeathScreen,
		WinScreen,
	}

	public static Dictionary<EPageType, List<UIPage>> PagesRefs
	{
		get;
		protected set;
	} = new Dictionary<EPageType, List<UIPage>>();

	public static void RegisterPage(UIPage page)
	{
		if (!PagesRefs.ContainsKey(page.PageType))
			PagesRefs.Add(page.PageType, new List<UIPage>());
		PagesRefs[page.PageType].Add(page);

		Debug.Log("Registered " + page.name + " as " + page.PageType);
	}

	public static void UnregisterPage(UIPage page)
	{
		PagesRefs[page.PageType].Remove(page);
		if (PagesRefs[page.PageType].Count <= 0)
			PagesRefs.Remove(page.PageType);
		Debug.Log("Unregistered " + page.name + " from " + page.PageType);
	}

	public static void Show(EPageType aPage, bool aShow)
	{
		if (PagesRefs.ContainsKey(aPage))
		{
			foreach (UIPage page in PagesRefs[aPage])
			{
				page.Show(aShow);
			}
		}
		else
		{
			Debug.LogError("There is no " + aPage + " registered in UI Manager. Make sure it is registering itself.");
		}
	}
}