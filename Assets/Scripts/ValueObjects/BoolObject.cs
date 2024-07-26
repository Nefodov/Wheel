using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(menuName = Constants.CREATE_MENU + "BoolObject")]
    public class BoolObject : ValueObject<bool>
    {
    }
}
