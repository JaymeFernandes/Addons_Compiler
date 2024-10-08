﻿using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addons
{
    internal static class McAddonManager
    {
        internal static string _Folder = AppContext.BaseDirectory;
        private static string _FolderB = "";
        private static string _FolderR = "";
        private static string _FolderMcAddon = "";
        private static string _Name = "";

        public static void SetName(string name)
        {
            _FolderB = $"{_Folder}/com.mojang/development_behavior_packs/{name}_Behavior";
            _FolderR = $"{_Folder}/com.mojang/development_resource_packs/{name}_Resource";
            _FolderMcAddon = $"{_Folder}/com.mojang/{name}.mcaddon";
            _Name = name;
        }

        public static void CreateMcAddonFile()
        {
            
            if (String.IsNullOrEmpty(_Name)) throw new ArgumentNullException("Name Addon is null");
            
            using(var file = new FileStream(_FolderMcAddon, FileMode.Create))
            {
                using(var archive = new ZipArchive(file, ZipArchiveMode.Create))
                {
                    AddFolderToZip(archive, _FolderB, $"Behavior_{_Name}");
                    Logs.Log($"Add Behavior-pack in {_Name}.mcaddon", Logs.Status.Complete, 1, 2);

                    AddFolderToZip(archive, _FolderR, $"resource_{_Name}");
                    Logs.Log($"Add Resource-pack in {_Name}.mcaddon", Logs.Status.Complete, 1, 2);
                }
            }
        }

        private static void AddFolderToZip(ZipArchive archive, string folderPath, string entryFolderName)
        {
            var files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                string entryName = Path.Combine(entryFolderName, file.Substring(folderPath.Length + 1)).Replace('\\', '/');
                archive.CreateEntryFromFile(file, entryName);
            }
        }

    }
}
