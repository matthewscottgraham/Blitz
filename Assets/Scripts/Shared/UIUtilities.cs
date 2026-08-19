using UnityEngine.UIElements;

namespace Shared
{
    public static class UIUtilities
    {
        public static T AddNew<T>(this VisualElement parent, T child) where T : VisualElement
        {
            parent.Add(child);
            return child;
        }
    }
}