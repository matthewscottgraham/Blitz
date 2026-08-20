using UnityEngine;

namespace Extensions
{
    public static class GameObjectExtensions
    {
        public static T AddChild<T>(this GameObject go) where T : Component
        {
            var child = new GameObject(typeof(T).Name);
            child.transform.SetParent(go.transform);
            return child.AddComponent<T>();
        }
    }
}