using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(menuName = Constants.CREATE_MENU + "StringObject")]
    public class StringObject : ValueObject<string>
    {
    }
}
