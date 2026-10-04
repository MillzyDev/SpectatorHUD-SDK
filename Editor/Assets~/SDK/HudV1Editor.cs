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