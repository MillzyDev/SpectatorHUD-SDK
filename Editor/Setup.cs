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
            // Recurse over all subdirectories
            string[] directories = Directory.GetDirectories(source, "*", SearchOption.AllDirectories);
            foreach (string directory in directories)
            {
                string dirName = Path.GetRelativePath(source, directory);
                string destDir = Path.Join(destination, dirName);
                Directory.CreateDirectory(destDir); // Create directory for next recursion
                
                // Recursive copy to new subdirectory
                CopyDirectoryForceRecurse(directory, destDir);
            }

            // Copy each top-level file
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
#endif