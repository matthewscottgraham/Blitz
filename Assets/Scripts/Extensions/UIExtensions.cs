using UnityEngine.UIElements;

namespace Extensions
{
    public static class UIExtensions
    {
        public static T AddNew<T>(this VisualElement parent, T child) where T : VisualElement
        {
            parent.Add(child);
            return child;
        }
    }
}