using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(menuName = Constants.CREATE_MENU + "StringObject")]
    public class StringObject : ValueObject<string>
    {
        private string value;

        public override string Value { get => value; set => this.value = value; }

        public override object RawValue()
        {
            return Value;
        }
    }
}
