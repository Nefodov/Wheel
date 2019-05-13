using UnityEngine;

namespace ValueObjects
{
	[CreateAssetMenu(menuName = Constants.CREATE_MENU + "IntObject")]
	public class IntObject : ValueObject<int>
	{
	}
}
