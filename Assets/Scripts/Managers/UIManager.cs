using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
	public enum EPage
	{
		MainMenu,
		Credits
	}

	public static Dictionary<EPage, List<UIPage>> PagesRefs
	{
		get;
		protected set;
	} = new Dictionary<EPage, List<UIPage>>();


	public static void RegisterPage(UIPage page)
	{
		if (!PagesRefs.ContainsKey(page.Page))
			PagesRefs.Add(page.Page, new List<UIPage>());
		PagesRefs[page.Page].Add(page);
	}
	public static void UnregisterPage(UIPage page)
	{
		PagesRefs[page.Page].Remove(page);
		if (PagesRefs[page.Page].Count <= 0)
			PagesRefs.Remove(page.Page);
	}


	public static void Show(EPage aPage, bool aShow)
	{
		foreach (UIPage page in PagesRefs[aPage])
		{
			if (page.CurrentState == (aShow ? UIPage.EState.Hidden : UIPage.EState.Shown))
			{
				page.Show(aShow);
			}
		}
	}
}
