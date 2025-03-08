using REPOLib.Objects.Sdk;
using System;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace REPOLibSdk.Editor
{
    public class ExportWindow : EditorWindow
    {
        private static Mod _selectedMod;

        private const string OutputPathPrefsKey = "REPOLib-Sdk_OutputPath";
        
        [MenuItem("Window/REPOLib Exporter")]
        public static void ShowFromMenu()
        {
            Open(null);
        }
        
        public static void Open(Mod mod)
        {
            _selectedMod = mod;
            var window = GetWindow<ExportWindow>();
            window.titleContent = new GUIContent("REPOLib Exporter");
        }

        public void CreateGUI()
        {
            var root = rootVisualElement;
            
            var modField = new ObjectField("Mod")
            {
                objectType = typeof(Mod),
                value = _selectedMod
            };
            root.Add(modField);

            var contentList = new ScrollView
            {
                style = {
                    maxHeight = 300,
                    overflow = Overflow.Hidden,
                }
            };
            root.Add(contentList);

            string savedPath = EditorPrefs.GetString(OutputPathPrefsKey, string.Empty);
            var pathField = new TextField("Output Path") { value = savedPath };
            root.Add(pathField);

            var exportButton = new Button(() => {
                PackageExporter.ExportPackage((Mod)modField.value, pathField.value);
            })
            {
                text = "Export"
            };
            root.Add(exportButton);
            
            modField.RegisterValueChangedCallback(evt => {
                contentList.Clear();
                
                _selectedMod = evt.newValue as Mod;
                if (_selectedMod == null) return;
                
                RefreshContentList();
            });

            pathField.RegisterValueChangedCallback(evt => {
                EditorPrefs.SetString(OutputPathPrefsKey, evt.newValue);
            });

            if (_selectedMod != null)
            {
                RefreshContentList();
            }

            return;

            void RefreshContentList()
            {
                Object[] includedAssets = PackageExporter.FindContents(_selectedMod)
                    .Select(AssetDatabase.LoadAssetAtPath<Object>)
                    .ToArray();

                foreach (var asset in includedAssets)
                {
                    var field = new ObjectField
                    {
                        value = asset
                    };
                    field.SetEnabled(false);
                    contentList.Add(field);
                }
            }
        }
    }
}
