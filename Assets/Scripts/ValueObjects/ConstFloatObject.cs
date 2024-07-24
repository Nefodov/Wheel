using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(menuName = Constants.CREATE_MENU_CONST +  "ConstFloatObject")]
    public class ConstFloatObject : FloatObject
    {
        [SerializeField]
        private float value;

        public override float Value { get => value; set => this.value = value; }
    }
}
