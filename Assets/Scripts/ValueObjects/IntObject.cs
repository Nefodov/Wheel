using UnityEngine;

namespace ValueObjects
{
	[CreateAssetMenu(menuName = Constants.CREATE_MENU + "IntObject")]
	public class IntObject : ValueObject<int>
	{
        private int value;

        public override int Value { get => value; set => this.value = value; }

        public override object RawValue()
        {
            return Value;
        }
    }
}
