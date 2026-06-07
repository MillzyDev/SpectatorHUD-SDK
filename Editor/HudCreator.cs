using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class HudCreator : EditorWindow
{
    [MenuItem("Window/SpectatorHUD/Create HUD")]
    public static void ShowExample()
    {
        var window = GetWindow<HudCreator>();
        window.titleContent = new GUIContent("Create HUD");
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;
        
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Packages/dev.millzy.spectatorhud.sdk/Editor/HudCreator.uxml");
        VisualElement content = visualTree.Instantiate();
        root.Add(content);
        
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Packages/dev.millzy.spectatorhud.sdk/Editor/HudCreator.uss");
        root.styleSheets.Add(styleSheet);
    }
}