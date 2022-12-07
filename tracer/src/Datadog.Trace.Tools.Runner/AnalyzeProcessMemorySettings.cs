﻿// <copyright file="AnalyzeProcessMemorySettings.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

using Spectre.Console.Cli;

namespace Datadog.Trace.Tools.Runner
{
    internal class AnalyzeProcessMemorySettings : CommandSettings
    {
        [CommandArgument(0, "<pid>")]
        public int Pid { get; set; }

        [CommandOption("-u|--upload-to-datadog")]
        public bool UploadToDatadog { get; set; }
    }
}
