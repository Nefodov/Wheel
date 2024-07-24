using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(menuName = Constants.CREATE_MENU + "FloatObjectSerialized")]
    public class FloatObjectSerialized : FloatObject
    {
        [SerializeField]
        private float value;

        public override float Value { get => value; set => this.value = value; }
    }
}
