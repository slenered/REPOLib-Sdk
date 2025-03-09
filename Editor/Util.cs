using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace REPOLibSdk.Editor
{
    public static class Util
    {
        public static PropertyField PropertyField(string fieldName, SerializedObject serializedObject, VisualElement parent)
        {
            var field = PropertyField(fieldName, serializedObject);
            parent.Add(field);
            return field;
        }
        
        public static PropertyField PropertyField(string fieldName, SerializedObject serializedObject)
        {
            var field = new PropertyField
            {
                bindingPath = fieldName,
            };
            
            field.Bind(serializedObject);
            return field;
        }

        public static void SetVisible(this VisualElement element, bool visible)
        {
            element.style.display = visible ? DisplayStyle.Flex : DisplayStyle.None;
        }
    }
}
