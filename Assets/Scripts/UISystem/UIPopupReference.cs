using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIPopupReferenceBase : ScriptableObject
{
	private UIPopup popup;

	public UIPopup Popup
	{
		get
		{
			if (popup == null)
			{

			}
			return popup;
		}
	}

	public abstract UIPopup GetPopup();
	public abstract void Open();
	public abstract void OpenInQueue();
	public abstract void Close();
}
