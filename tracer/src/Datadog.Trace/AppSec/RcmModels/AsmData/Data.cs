// <copyright file="Data.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System;
using System.Collections.Generic;
using Datadog.Trace.Vendors.Newtonsoft.Json;

namespace Datadog.Trace.AppSec.RcmModels.AsmData;

internal class Data
{
    /// <summary>
    /// Gets or sets an integer representing a UNIX timestamp. Past this timestamp, the entry is ignored. Without a timestamp a value never expires.
    /// </summary>
    public long? Expiration { get; set; }

    public string Value { get; set; }
}
