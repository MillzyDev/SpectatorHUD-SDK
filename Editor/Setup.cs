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

using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace SpectatorHUD.SDK
{
    public static class Setup
    {
        private static void CopyDirectoryForceRecurse(string source, string destination)
        {
            string[] directories = Directory.GetDirectories(source, "*", SearchOption.AllDirectories);
            foreach (string directory in directories)
            {
                string dirName = Path.GetRelativePath(source, directory);
                string destDir = Path.Join(destination, dirName);
                Directory.CreateDirectory(destDir);
                
                // Recursive copy to new subdirectory
                CopyDirectoryForceRecurse(directory, destDir);
            }

            string[] files = Directory.GetFiles(source);
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Join(destination, fileName);
                File.Copy(file, destFile, true);
            }
        }
        
        [MenuItem("Window/SpectatorHUD/Configure Project")]
        public static void SetupAssets()
        {
            string packagePath = FileUtil.GetPhysicalPath("Packages/dev.millzy.spectatorhud.sdk");
            string packageAssets = Path.Join(packagePath, "Editor", "Assets~");
            string projectAssets = FileUtil.GetPhysicalPath("Assets/SpectatorHUD");
            
            // Copy to project directory so mod can deserialize properly, as well as allowing references in editor
            CopyDirectoryForceRecurse(packageAssets, projectAssets);
            
            // Reload scripts
            AssetDatabase.Refresh();
        }
    }
}