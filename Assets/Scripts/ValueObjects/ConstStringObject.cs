using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(menuName = Constants.CREATE_MENU_CONST + "ConstStringObject")]
    public class ConstStringObject : StringObject
    {
        [SerializeField]
        private string value;

        public override string Value { get => value; set => this.value = value; }
    }
}
