using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandedAttribute : PropertyAttribute
{
	public bool hideName = false;

	public ExpandedAttribute() { }
	public ExpandedAttribute(bool hideName) {
		this.hideName = hideName;
	}
}
