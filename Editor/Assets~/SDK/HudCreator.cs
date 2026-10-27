/*
 *      Spectator HUD SDK
 *      Copyright (c) 2026 Millzy
 *   
 *      Licensed under the Apache License, Version 2.0 (the "License");
 *      you may not use this file except in compliance with the License.
 *      You may obtain a copy of the License at
 *
 *          http://www.apache.org/licenses/LICENSE-2.0
 *
 *      Unless required by applicable law or agreed to in writing, software
 *      distributed under the License is distributed on an "AS IS" BASIS,
 *      WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *      See the License for the specific language governing permissions and
 *      limitations under the License.
 */

#if UNITY_EDITOR

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
            hudManifestAsset.spectatorHudVersion = versionAsset;
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

#endif