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
        private static string _FolderB = "";
        private static string _FolderR = "";
        private static string _FolderMcAddon = "";
        private static string _Name = "";

        public static void SetName(string name)
        {
            _FolderB = $"./com.mojang/development_behavior_packs/{name}_Behavior";
            _FolderR = $"./com.mojang/development_resource_packs/{name}_Resource";
            _FolderMcAddon = $"./com.mojang/{name}.mcaddon";
            _Name = name;
        }

        public static void CreateMcAddonFile()
        {
            if (String.IsNullOrEmpty(_Name)) throw new ArgumentNullException("Name Addon is null");
            using(var file = new FileStream(_FolderMcAddon, FileMode.Create))
            {
                using(var archive = new ZipArchive(file, ZipArchiveMode.Create))
                {
                    AddFolderToZip(archive, _FolderB, $"Resource_{_Name}");
                    AddFolderToZip(archive, _FolderR, $"Behavior_{_Name}");
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