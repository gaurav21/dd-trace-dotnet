// <copyright file="UserState.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable
using System;

namespace Datadog.Trace.ClrProfiler.AutoInstrumentation.AspNetCore.UserEvents;

internal class UserState
{
    public string? UserId { get; set; }

    public bool Exists { get; set; }

    public bool IsUserIdGuid() => UserId != null && Guid.TryParse(UserId, out _);
}
