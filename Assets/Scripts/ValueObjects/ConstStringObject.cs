using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(menuName = Constants.CREATE_MENU_CONST + "ConstStringObject")]
    public class ConstStringObject : StringObject
    {
        [SerializeField]
        private string _constValue;

        public override string Value => _constValue;
    }
}
