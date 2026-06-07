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
using UnityEngine;

namespace SpectatorHUD.SDK
{
    public static class Setup
    {
        [MenuItem("Window/SpectatorHUD/Configure Project")]
        public static void SetupAssets()
        {
            string path = FileUtil.GetPhysicalPath("Packages/dev.millzy.spectatorhud.sdk");
            string packageAssets = Path.Join(path, "Editor", "Assets~");
            string projectAssetsRoot = FileUtil.GetPhysicalPath("Assets/SpectatorHUD");
            string projectAssets = Path.Join(projectAssetsRoot, "SDK");

            // Remove old assets directory
            if (Directory.Exists(projectAssetsRoot))
            {
                Directory.Delete(projectAssetsRoot, true);
            }
            // Recreate assets directory
            AssetDatabase.CreateFolder("Assets", "SpectatorHUD");
            AssetDatabase.CreateFolder("Assets/SpectatorHUD", "SDK");

            // Copy all files from the package's to the main project
            string[] files = Directory.GetFiles(packageAssets);
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string dest = Path.Join(projectAssets, fileName);
                File.Copy(file, dest, true);
            }
            
            // Reload scripts
            AssetDatabase.Refresh();
        }
    }
}