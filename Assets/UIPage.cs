using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class UIPage : MonoBehaviour
{
	public static Dictionary<EPage,List<UIPage>> PagesRefs
	{
		get;
		protected set;
	}

	public enum EPage
	{
		MainMenu,
		Credits
	}

	public enum EState
	{
		Shown,
		Hidden
	}

	public EPage Page;
	public EState CurrentState
	{
		get;
		private set;
	}
	private void Awake()
	{
		if (!PagesRefs.ContainsKey(Page))
			PagesRefs.Add(Page, new List<UIPage>());
		PagesRefs[Page].Add(this);
	}

	private void OnDestroy()
	{
		PagesRefs[Page].Remove(this);
		if (PagesRefs[Page].Count <= 0)
			PagesRefs.Remove(Page);
	}
	public static void Show(EPage aPage, bool aShow)
	{
		foreach(UIPage page in PagesRefs[aPage])
		{
			if(page.CurrentState == (aShow ? EState.Hidden:EState.Shown))
			{
				page.Show(aShow);
			}
		}
	}

	public void Show(bool aShow)
	{
		CurrentState = aShow ? EState.Shown : EState.Hidden;
		gameObject.SetActive(aShow);
	}
}
