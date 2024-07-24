using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(menuName = Constants.CREATE_MENU + "BoolObject")]
    public class BoolObject : ValueObject<bool>
    {
        private bool value;

        public override bool Value { get => value; set => this.value = value; }

        public override object RawValue()
        {
            return Value;
        }
    }
}
