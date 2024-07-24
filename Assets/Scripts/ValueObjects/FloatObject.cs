using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(menuName = Constants.CREATE_MENU + "FloatObject")]
	public class FloatObject : ValueObject<float>
	{
		private float value;

        public override float Value { get => value; set => this.value = value; }

        public override object RawValue()
        {
            return Value;
        }
    }
}
