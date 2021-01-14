using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;

namespace BatchFileRenamer.Models
{
    public sealed class RenameFileInfo : IComparable
    {
        private FileInfo FileInfo { get; }

        private DirectoryInfo RootPath { get; }

        private string OriginalName { get; set; }
        public string CurrentName { get; set; } 
        public string PreviewName { get; set; }

        private bool isConflicting;
        public bool IsConflicting() => isConflicting;
        public bool SetConflicting(bool value) => isConflicting = value;


        private bool _isMatch;
        public void SetMatch(bool value) => _isMatch = value;
        public bool IsMatch() => _isMatch;

        private bool isModified => CurrentName != OriginalName;
        public bool IsModified() => isModified;


        public RenameFileInfo(FileInfo fileInfo, DirectoryInfo rootPath)
        {
            FileInfo = fileInfo;
            RootPath = rootPath;
            var name = string.Join("", fileInfo.FullName.Skip(RootPath.FullName.Length)).Trim('\\', '/');
            OriginalName = CurrentName = PreviewName = name ;
        }

        public void ApplyChanges(string alternateRoot = null)
        {
            if (CurrentName != OriginalName)
            {
                var root = alternateRoot ?? RootPath.FullName;
                var newName = Path.Combine(root, PreviewName);
                Directory.CreateDirectory(new FileInfo(newName).DirectoryName);
                FileInfo.MoveTo(newName);
                _isMatch = false;
            }
        }

        public void ResetName()
        {
            CurrentName = PreviewName = OriginalName;
            _isMatch = false;
        }

        public override string ToString() => FileInfo.FullName;
    
        public int CompareTo(object obj)
        {
            RenameFileInfo mfi = obj as RenameFileInfo;
            if (mfi != null)
            {
                return string.Compare(CurrentName, mfi.CurrentName, StringComparison.CurrentCultureIgnoreCase);
            }
            return 0;
        }

        public void UpdateNameByRegexReplace(Regex searchExpression, string replacePattern)
        {
            CurrentName = searchExpression.Replace(CurrentName, replacePattern);
            _isMatch = false;
        }

        public void UpdateNameBySimpleReplace(string searchString, string replaceString, bool ignoreCase)
        {
            CurrentName = CurrentName.Replace(searchString, replaceString, ignoreCase, CultureInfo.CurrentCulture);
            _isMatch = false;
        }

    }
}
