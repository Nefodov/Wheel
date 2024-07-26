using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(menuName = Constants.CREATE_MENU_CONST + "ConstBoolObject")]
    public class ConstBoolObject : BoolObject
    {
        [SerializeField]
        private bool constValue;

        public override bool Value => constValue;
    }
}
