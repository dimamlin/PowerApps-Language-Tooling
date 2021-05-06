// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.PowerPlatform.Formulas.Tools.Schemas
{
    internal enum ContentKind
    {
        Unknown,
        Image,
        Audio,
        Video,
        Pdf,
    }

    internal enum ResourceKind
    {
        LocalFile,
        Uri,
    }

    internal class ResourcesJson
    {
        public ResourceJson[] Resources { get; set; }
    }

    internal class ResourceJson
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public ResourceKind ResourceKind { get; set; }
        public string Path { get; set; }
        public ContentKind Content { get; set; }

        // For LocalFiles, this root path is regenerated by the server during load, and points to a temporary resource url
        // There is no impact if it's missing.
        // We preserve it in Entropy.json for roundtrip purposes only.
        public string RootPath { get; set; }

        // Original filename used if there were collisions when rewriting the filenames
        // This only exists in the unpacked app, and must not be present in the
        // packed msapp 
        public string OriginalName { get; set; }

        [JsonExtensionData]
        public Dictionary<string, JsonElement> ExtensionData { get; set; }
    }
}
