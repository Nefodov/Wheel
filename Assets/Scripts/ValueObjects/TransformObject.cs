using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(menuName = Constants.CREATE_MENU + "TransformObject")]
    public class TransformObject : ValueObject<Transform>
    {
    }
}
