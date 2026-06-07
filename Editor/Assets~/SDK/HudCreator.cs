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

using System.IO;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

using HudManifest = SpectatorHUD.HudV1;

namespace SpectatorHUD.SDK
{
    public class HudCreator : EditorWindow
    {
        public const int CurrentVersion = 1;
        
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

            var createButton = root.Q<Button>("create-button");
            createButton.clicked += OnCreateClick;
        }

        private void OnCreateClick()
        {
            VisualElement root = rootVisualElement;
            var hudName = root.Q<TextField>("name");
            var hudVersion = root.Q<IntegerField>("version");
            var hudAuthor = root.Q<TextField>("author");

            // Create folder to contain all the HUD assets
            AssetDatabase.CreateFolder("Assets", hudName.value);
            string hudPath = Path.Join("Assets", hudName.value);
            
            // Create version asset
            var versionAsset = ScriptableObject.CreateInstance<HudVersion>();
            versionAsset.version = CurrentVersion;
            string versionAssetPath = Path.Join(hudPath, "Hud.Version.asset");
            AssetDatabase.CreateAsset(versionAsset, versionAssetPath);
            
            // Create manifest asset
            var hudManifestAsset = ScriptableObject.CreateInstance<HudManifest>();
            hudManifestAsset.hudName = hudName.value;
            hudManifestAsset.hudVersion = hudVersion.value;
            hudManifestAsset.hudAuthor = hudAuthor.value;
            string hudManifestAssetPath = Path.Join(hudPath, "Hud.asset");
            AssetDatabase.CreateAsset(hudManifestAsset, hudManifestAssetPath);
            
            // Save
            AssetDatabase.SaveAssets();

            Selection.activeObject = hudManifestAsset;
            EditorGUIUtility.PingObject(hudManifestAsset);
            
            Close();
        }
    }
}