// <copyright file="StringModuleImpl.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using Datadog.Trace.Iast.Dataflow;
using Datadog.Trace.Logging;

namespace Datadog.Trace.Iast.Propagation;

internal static class StringModuleImpl
{
    private static readonly IDatadogLogger Log = DatadogLogging.GetLoggerFor(typeof(StringModuleImpl));

    internal static bool CanBeTainted(string? txt)
    {
        return txt != null && txt.Length > 0;
    }

    internal static TaintedObject? GetTainted(TaintedObjects taintedObjects, object? value)
    {
        return value == null ? null : taintedObjects.Get(value);
    }

    public static string TaintStringFormat(string result, IFormatProvider provider, string format, params object[] args)
    {
        try
        {
            var context = ContextHolder.Current;
            var t = context.TaintedObjects;
            t?.TaintStringFormat(context, result, provider, format, args);
            return result;
        }
        catch (AST.Commons.Exceptions.HdivException) { throw; }
        catch (Exception ex)
        {
            logger.Error(ex.ToFormattedString());
            return result;
        }
    }

    public bool TaintStringFormat(IHttpContext context, string result, IFormatProvider provider, string formatString, object[] args)
    {
        bool res = false;
        var taintedObjectString = Get(formatString);
        if (taintedObjectString != null) //Si lo que está tainted es la cadena de formato, tainteamos todo
        {
            res = true;
            add(context, result, taintedObjectString, taintedObjectString.Ranges[0].CopyWithRange(0, result.Length));
        }
        else
        {
            List<TaintedRange> ranges = new List<TaintedRange>();

            // this loop it is really operating throught arguments (in this case also with range reference)
            foreach (var tuple in GetFormatRanges(provider, formatString, args))
            {
                Range range = tuple.Item1;
                object arg = tuple.Item2;

                var taintedArg = get(arg);
                if (taintedArg != null) //Si está tainteado un argumento, tainteamos el rango en el resultado
                {
                    taintedObjectString ??= taintedArg;
                    if (AddRangesWithinTaintedRangeLimit(taintedArg.Ranges, range.Start, ranges))
                    {
                        break;
                    }
                }
            }

            if (ranges.Count > 0)
            {
                add(context, result, taintedObjectString, ranges);
                res = true;
            }
        }

        return res;
    }

    static List<Commons.Tuple<Range, object>> GetFormatRanges(IFormatProvider provider, string formatString, object[] args)
    {
        List<Commons.Tuple<Range, object>> res = new List<Commons.Tuple<Range, object>>();

        //Format converts {{ into { and does not use this new bracket for arguments
        formatString = formatString.Replace("{{{", "%{").Replace("}}}", "}%");
        formatString = formatString.Replace("{{", "%").Replace("}}", "%");

        int openIndex = formatString.IndexOf("{");
        int formatOffset = 0;

        while (openIndex >= 0)
        {
            int closeIndex = formatString.IndexOf("}", openIndex);
            if (closeIndex > 0)
            {
                string formatFragment = formatString.Substring(openIndex, closeIndex - openIndex + 1);
                string resFragment = provider != null
                    ? string.Format(provider, formatFragment, args)
                    : string.Format(formatFragment, args);
                object arg = GetArg(formatFragment, args);

                res.Add(new Commons.Tuple<Range, object>(
                    new Range(formatOffset + openIndex, formatOffset + openIndex + resFragment.Length), arg));

                formatOffset += resFragment.Length - formatFragment.Length;
                openIndex = formatString.IndexOf("{", closeIndex);
            }
            else
            {
                break;
            }
        }

        return res;
    }

    public static object GetArg(string formatString, object[] args)
    {
        var separatorIndex = -1;
        var chars = formatString.ToCharArray();
        for (var i = 0; i < chars.Length; i++)
        {
            if (chars[i] == ':')
            {
                separatorIndex = i;
                break;
            }

            if (chars[i] == ',')
            {
                separatorIndex = i;
                break;
            }
        }
        var indexTxt = formatString.Substring(1, separatorIndex > 0 ? separatorIndex - 1 : formatString.Length - 2);
        return args[Convert.ToInt32(indexTxt)];
    }

    /// <summary> Mostly used overload </summary>
    /// <param name="left"> Param 1 </param>
    /// <param name="right"> Param 2</param>
    /// <param name="result"> Result </param>
    /// <param name="filter"> Literal filter </param>
    /// <returns> resiñt </returns>
    public static string OnStringConcat(string left, string right, string result, AspectFilter filter = AspectFilter.None)
    {
        try
        {
            if (string.IsNullOrEmpty(left) || string.IsNullOrEmpty(right))
            {
                return result;
            }

            if (!CanBeTainted(result) || (!CanBeTainted(left) && !CanBeTainted(right)))
            {
                return result;
            }

            var iastContext = IastModule.GetIastContext();
            if (iastContext == null)
            {
                return result;
            }

            TaintedObjects taintedObjects = iastContext.GetTaintedObjects();
            TaintedObject? taintedLeft = filter != AspectFilter.StringLiteral_1 ? GetTainted(taintedObjects, left) : null;
            TaintedObject? taintedRight = filter != AspectFilter.StringLiteral_0 ? GetTainted(taintedObjects, right) : null;
            if (taintedLeft == null && taintedRight == null)
            {
                return result;
            }

            Range[]? ranges;
            if (taintedRight == null)
            {
                ranges = taintedLeft!.Ranges;
            }
            else if (taintedLeft == null)
            {
                ranges = new Range[taintedRight!.Ranges!.Length];
                Ranges.CopyShift(taintedRight!.Ranges, ranges, 0, left.Length);
            }
            else
            {
                ranges = Ranges.MergeRanges(left.Length, taintedLeft!.Ranges, taintedRight!.Ranges);
            }

            taintedObjects.Taint(result, ranges);
        }
        catch (Exception err)
        {
            Log.Error(err, "StringModuleImpl.OnstringConcat(string,string) exception {Exception}", err.Message);
        }

        return result;
    }

    /// <summary> Overload for multi params (up to 5) </summary>
    /// <param name="parameters"> StringConcat params struct </param>
    /// <param name="result"> Result </param>
    /// <returns> result </returns>
    public static string OnStringConcat(StringConcatParams parameters, string result)
    {
        try
        {
            if (!CanBeTainted(result) || !parameters.CanBeTainted())
            {
                return result;
            }

            var iastContext = IastModule.GetIastContext();
            if (iastContext == null)
            {
                return result;
            }

            TaintedObjects taintedObjects = iastContext.GetTaintedObjects();

            Range[]? ranges = null;
            int length = 0;
            for (int parameterIndex = 0; parameterIndex < parameters.ParamCount; parameterIndex++)
            {
                var currentParameter = parameters[parameterIndex];
                if (!CanBeTainted(currentParameter))
                {
                    continue;
                }

                var parameterTainted = GetTainted(taintedObjects, currentParameter);
                if (parameterTainted != null)
                {
                    if (ranges == null)
                    {
                        if (parameterTainted != null)
                        {
                            if (length == 0)
                            {
                                ranges = parameterTainted.Ranges;
                            }
                            else
                            {
                                ranges = new Range[parameterTainted!.Ranges!.Length];
                                Ranges.CopyShift(parameterTainted!.Ranges, ranges, 0, length);
                            }
                        }

                        length += currentParameter!.Length;
                        continue;
                    }

                    ranges = Ranges.MergeRanges(length, ranges, parameterTainted.Ranges);
                }

                length += currentParameter!.Length;
            }

            if (ranges != null)
            {
                taintedObjects.Taint(result, ranges);
            }
        }
        catch (Exception err)
        {
            Log.Error(err, "StringModuleImpl.OnstringConcat(StringConcatParams) exception {Exception}", err.Message);
        }

        return result;
    }

    /// <summary> Overload for multi params (up to 5) </summary>
    /// <param name="parameters"> StringConcat params struct </param>
    /// <param name="result"> Result </param>
    /// <returns> result </returns>
    public static string OnStringConcat(IEnumerable parameters, string result)
    {
        try
        {
            if (!CanBeTainted(result))
            {
                return result;
            }

            var iastContext = IastModule.GetIastContext();
            if (iastContext == null)
            {
                return result;
            }

            TaintedObjects taintedObjects = iastContext.GetTaintedObjects();

            Range[]? ranges = null;
            int length = 0;
            foreach (var parameterAsObject in parameters)
            {
                var currentParameter = parameterAsObject?.ToString();
                if (!CanBeTainted(currentParameter))
                {
                    continue;
                }

                var taintedParameter = GetTainted(taintedObjects, currentParameter);
                if (taintedParameter != null)
                {
                    if (ranges == null)
                    {
                        if (taintedParameter != null)
                        {
                            if (length == 0)
                            {
                                ranges = taintedParameter.Ranges;
                            }
                            else
                            {
                                ranges = new Range[taintedParameter!.Ranges!.Length];
                                Ranges.CopyShift(taintedParameter!.Ranges, ranges, 0, length);
                            }
                        }

                        length += currentParameter!.Length;
                        continue;
                    }

                    ranges = Ranges.MergeRanges(length, ranges, taintedParameter.Ranges);
                }

                length += currentParameter!.Length;
            }

            if (ranges != null)
            {
                taintedObjects.Taint(result, ranges);
            }
        }
        catch (Exception err)
        {
            Log.Error(err, "StringModuleImpl.OnstringConcat(IEnumerable) exception {Exception}", err.Message);
        }

        return result;
    }

    public readonly struct StringConcatParams
    {
        public readonly string? P0;
        public readonly string? P1;
        public readonly string? P2;
        public readonly string? P3;
        public readonly string? P4;
        public readonly int ParamCount;

        public StringConcatParams(string? p0, string? p1, string? p2)
        {
            P0 = p0;
            P1 = p1;
            P2 = p2;
            ParamCount = 3;
        }

        public StringConcatParams(string? p0, string? p1, string? p2, string? p3)
        {
            P0 = p0;
            P1 = p1;
            P2 = p2;
            P3 = p3;
            ParamCount = 4;
        }

        public StringConcatParams(string? p0, string? p1, string? p2, string? p3, string? p4)
        {
            P0 = p0;
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
            ParamCount = 5;
        }

        public string? this[int index]
        {
            get
            {
                if (index < 0 || index >= ParamCount)
                {
                    throw new IndexOutOfRangeException();
                }

                return index switch
                {
                    0 => P0,
                    1 => P1,
                    2 => P2,
                    3 => P3,
                    4 => P4,
                    _ => null,
                };
            }
        }

        public bool CanBeTainted()
        {
            for (int x = 0; x < ParamCount; x++)
            {
                if (StringModuleImpl.CanBeTainted(this[x]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
