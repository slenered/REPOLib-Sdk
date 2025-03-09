using REPOLib.Objects.Sdk;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace REPOLibSdk.Editor
{
    [CustomEditor(typeof(ValuableContent))]
    public class ValuableContentEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();

            Util.PropertyField("_prefab", serializedObject, root);

            var addToAllLevelsField = new Toggle
            {
                label = "Add to All Levels",
                bindingPath = "_addToAllLevels"
            };
            addToAllLevelsField.Bind(serializedObject);
            root.Add(addToAllLevelsField);
            
            var levelNamesField = Util.PropertyField("_levelNames", serializedObject, root);

            levelNamesField.SetEnabled(!addToAllLevelsField.value);
            addToAllLevelsField.RegisterValueChangedCallback(evt => {
                levelNamesField.SetEnabled(!evt.newValue);
            });

            return root;
        }
    }
}
