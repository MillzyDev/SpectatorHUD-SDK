/*
 *      SpectatorHUD SDK
 *      Copyright (C) 2026  Millzy
 *
 *      This program is free software: you can redistribute it and/or modify
 *      it under the terms of the GNU General Public License as published by
 *      the Free Software Foundation, either version 3 of the License, or
 *      (at your option) any later version.
 *
 *      This program is distributed in the hope that it will be useful,
 *      but WITHOUT ANY WARRANTY; without even the implied warranty of
 *      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *      GNU General Public License for more details.
 *
 *      You should have received a copy of the GNU General Public License
 *      along with this program.  If not, see https://www.gnu.org/licenses/.
 */

using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

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