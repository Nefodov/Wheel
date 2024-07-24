using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(menuName = Constants.CREATE_MENU_CONST + "ConstBoolObject")]
    public class ConstBoolObject : BoolObject
    {
        [SerializeField]
        private bool value;

        public override bool Value { get => value; set => this.value = value; }
    }
}
