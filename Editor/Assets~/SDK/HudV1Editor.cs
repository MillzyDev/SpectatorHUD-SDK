/*
 *      Spectator HUD SDK
 *      Copyright 2026 Millzy
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

namespace SpectatorHUD.SDK
{
    [CustomEditor(typeof(HudV1))]
    public class HudV1Editor : HudEditor
    {
        public override void ExportHud()
        {
            HudV1 hudTarget = (HudV1)this.target;

            // Get assets paths to include in bundle
            string hudManifestTarget = AssetDatabase.GetAssetPath(hudTarget);
            string hudVersion = AssetDatabase.GetAssetPath(hudTarget.spectatorHudVersion);
            string hudAsset = AssetDatabase.GetAssetPath(hudTarget.hudAsset);

            // Get save location
            string saveFilePath = EditorUtility.SaveFilePanel("Export HUD", "", hudTarget.hudName + ".hud", "hud");
            string filename = Path.GetFileName(saveFilePath);
            
            // Create bundle
            var bundleBuild = new AssetBundleBuild();
            bundleBuild.assetBundleName = filename;
            bundleBuild.assetNames = new string[] { hudManifestTarget, hudVersion, hudAsset };

            // Create build output directory
            if (!AssetDatabase.IsValidFolder("Assets/_SH Build"))
            {
                AssetDatabase.CreateFolder("Assets", "_SH Build");
            }

            // Build bundle
            AssetBundleBuild[] bundles = { bundleBuild };
            BuildPipeline.BuildAssetBundles("Assets/_SH Build", bundles, BuildAssetBundleOptions.None,
                BuildTarget.StandaloneWindows64);

            // Copy output to proper save location
            string buildOutput = FileUtil.GetPhysicalPath(Path.Combine("Assets/_SH Build", filename));
            File.Copy(buildOutput, saveFilePath, true);
            
            EditorUtility.RevealInFinder(saveFilePath);
        }
    }
}

#endif