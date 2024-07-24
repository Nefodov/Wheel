using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(menuName = Constants.CREATE_MENU_CONST + "ConstIntObject")]
    public class ConstIntObject : IntObject
    {
        [SerializeField]
        private int value;

        public override int Value { get => value; set => this.value = value; }
    }
}
