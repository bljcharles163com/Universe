// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;

namespace RepoTasks.ProjectModel
{
    internal class ProjectInfo
    {
        public ProjectInfo(string fullPath,
            string projectExtensionsPath,
            IReadOnlyList<ProjectFrameworkInfo> frameworks,
            IReadOnlyList<DotNetCliReferenceInfo> tools,
            bool isPackable,
            string packageId,
            string packageVersion)
        {
            if (!Path.IsPathRooted(fullPath))
            {
                throw new ArgumentException("Path must be absolute", nameof(fullPath));
            }

            Frameworks = frameworks ?? throw new ArgumentNullException(nameof(frameworks));
            Tools = tools ?? throw new ArgumentNullException(nameof(tools));

            FullPath = fullPath;
            FileName = Path.GetFileName(fullPath);
            Directory = Path.GetDirectoryName(FullPath);
            ProjectExtensionsPath = projectExtensionsPath ?? Path.Combine(Directory, "obj");
            IsPackable = isPackable;
            PackageId = packageId;
            PackageVersion = packageVersion;
        }

        public string FullPath { get; }
        public string FileName { get; }
        public string ProjectExtensionsPath { get; }
        public string Directory { get; }
        public string PackageId { get; }
        public string PackageVersion { get; }
        public bool IsPackable { get; }

        public IReadOnlyList<ProjectFrameworkInfo> Frameworks { get; }
        public IReadOnlyList<DotNetCliReferenceInfo> Tools { get; }
    }
}
