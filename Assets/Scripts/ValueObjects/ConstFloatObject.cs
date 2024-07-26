using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(menuName = Constants.CREATE_MENU_CONST +  "ConstFloatObject")]
    public class ConstFloatObject : FloatObject
    {
        [SerializeField]
        private float _constValue;

        public override float Value => _constValue; 
    }
}
