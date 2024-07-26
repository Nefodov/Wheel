using System;
using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(menuName = Constants.CREATE_MENU_CONST + "ConstIntObject")]
    public class ConstIntObject : IntObject
    {
        [SerializeField]
        private int _constValue;

        public override int Value => _constValue;
    }
}
