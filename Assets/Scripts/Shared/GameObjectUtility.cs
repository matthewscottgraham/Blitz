using UnityEngine;

namespace Shared
{
    public static class GameObjectUtility
    {
        public static T AddChild<T>(this GameObject go) where T : Component
        {
            var child = new GameObject();
            child.transform.SetParent(go.transform);
            return child.AddComponent<T>();
        }
    }
}