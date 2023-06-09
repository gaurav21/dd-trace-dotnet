﻿// <auto-generated/>
#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Datadog.Trace.ClrProfiler
{
    internal static partial class AspectDefinitions
    {
        public static string[] Aspects = new string[] {
"[AspectClass(\"EntityFramework\",[None],Propagation,[])] Datadog.Trace.Iast.Aspects.EntityCommandAspect",
"  [AspectMethodInsertBefore(\"System.Data.Entity.Core.EntityClient.EntityCommand::ExecuteReader(System.Data.CommandBehavior)\",\"\",[1],[False],[None],Propagation,[])] ReviewSqlCommand(System.Object)",
"  [AspectMethodInsertBefore(\"System.Data.Entity.Core.EntityClient.EntityCommand::ExecuteReaderAsync(System.Data.CommandBehavior,System.Threading.CancellationToken)\",\"\",[2],[False],[None],Propagation,[])] ReviewSqlCommand(System.Object)",
"  [AspectMethodInsertBefore(\"System.Data.Entity.Core.EntityClient.EntityCommand::ExecuteReaderAsync(System.Data.CommandBehavior)\",\"\",[1],[False],[None],Propagation,[])] ReviewSqlCommand(System.Object)",
"[AspectClass(\"System.Data,System.Data.Common\",[None],Propagation,[])] Datadog.Trace.Iast.Aspects.DbCommandAspect",
"  [AspectMethodInsertBefore(\"System.Data.Common.DbCommand::ExecuteNonQueryAsync(System.Threading.CancellationToken)\",\"\",[1],[False],[None],Propagation,[])] ReviewExecuteNonQuery(System.Object)",
"  [AspectMethodInsertBefore(\"System.Data.Common.DbCommand::ExecuteNonQueryAsync()\",\"\",[0],[False],[None],Propagation,[])] ReviewExecuteNonQuery(System.Object)",
"[AspectClass(\"mscorlib,System.IO.FileSystem,System.Runtime\",[None],Sink,[PathTraversal])] Datadog.Trace.Iast.Aspects.DirectoryAspect",
"  [AspectMethodInsertBefore(\"System.IO.Directory::CreateDirectory(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::Delete(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::Delete(System.String,System.Boolean)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::GetDirectories(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::GetDirectories(System.String,System.String)\",\"\",[0,1],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::GetDirectories(System.String,System.String,System.IO.SearchOption)\",\"\",[1,2],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::GetDirectoryRoot(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::GetFiles(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::GetFiles(System.String,System.String)\",\"\",[0,1],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::GetFiles(System.String,System.String,System.IO.SearchOption)\",\"\",[1,2],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::GetFileSystemEntries(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::GetFileSystemEntries(System.String,System.String)\",\"\",[0,1],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::GetFileSystemEntries(System.String,System.String,System.IO.SearchOption)\",\"\",[1,2],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::Move(System.String,System.String)\",\"\",[0,1],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::CreateDirectory(System.String,System.Security.AccessControl.DirectorySecurity)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::SetAccessControl(System.String,System.Security.AccessControl.DirectorySecurity)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::EnumerateDirectories(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::EnumerateDirectories(System.String,System.String)\",\"\",[0,1],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::EnumerateDirectories(System.String,System.String,System.IO.SearchOption)\",\"\",[1,2],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::EnumerateFiles(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::EnumerateFiles(System.String,System.String)\",\"\",[0,1],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::EnumerateFiles(System.String,System.String,System.IO.SearchOption)\",\"\",[1,2],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::EnumerateFileSystemEntries(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::EnumerateFileSystemEntries(System.String,System.String)\",\"\",[0,1],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::EnumerateFileSystemEntries(System.String,System.String,System.IO.SearchOption)\",\"\",[1,2],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.Directory::SetCurrentDirectory(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"[AspectClass(\"mscorlib,System.IO.FileSystem,System.Runtime\",[None],Sink,[PathTraversal])] Datadog.Trace.Iast.Aspects.DirectoryInfoAspect",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::.ctor(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::CreateSubdirectory(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::CreateSubdirectory(System.String,System.Security.AccessControl.DirectorySecurity)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::MoveTo(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::GetFileSystemInfos(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::GetFileSystemInfos(System.String,System.IO.SearchOption)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::GetFiles(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::GetFiles(System.String,System.IO.SearchOption)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::GetDirectories(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::GetDirectories(System.String,System.IO.SearchOption)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::EnumerateFileSystemInfos(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::EnumerateFileSystemInfos(System.String,System.IO.SearchOption)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::EnumerateFiles(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::EnumerateFiles(System.String,System.IO.SearchOption)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::EnumerateDirectories(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.DirectoryInfo::EnumerateDirectories(System.String,System.IO.SearchOption)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"[AspectClass(\"mscorlib,System.IO.FileSystem,System.Runtime\",[None],Sink,[PathTraversal])] Datadog.Trace.Iast.Aspects.FileAspect",
"  [AspectMethodInsertBefore(\"System.IO.File::Create(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::CreateText(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::Delete(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::OpenRead(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::OpenText(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::OpenWrite(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::ReadAllBytes(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::ReadAllLines(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::ReadAllLines(System.String,System.Text.Encoding)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::ReadAllText(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::ReadLines(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::AppendAllLines(System.String,System.Collections.Generic.IEnumerable`1<System.String>)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::AppendAllLines(System.String,System.Collections.Generic.IEnumerable`1<System.String>,System.Text.Encoding)\",\"\",[2],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::AppendAllText(System.String,System.String)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::AppendAllText(System.String,System.String,System.Text.Encoding)\",\"\",[2],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::AppendText(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::ReadLines(System.String,System.Text.Encoding)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::ReadAllText(System.String,System.Text.Encoding)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::ReadLines(System.String,System.Text.Encoding)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::Create(System.String,System.Int32)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::Create(System.String,System.Int32,System.IO.FileOptions)\",\"\",[2],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::Create(System.String,System.Int32,System.IO.FileOptions,System.Security.AccessControl.FileSecurity)\",\"\",[3],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::Open(System.String,System.IO.FileMode)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::Open(System.String,System.IO.FileMode,System.IO.FileAccess)\",\"\",[2],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::Open(System.String,System.IO.FileMode,System.IO.FileAccess,System.IO.FileShare)\",\"\",[3],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::SetAttributes(System.String,System.IO.FileAttributes)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::WriteAllBytes(System.String,System.Byte[])\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::WriteAllLines(System.String,System.String[])\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::WriteAllLines(System.String,System.String[],System.Text.Encoding)\",\"\",[2],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::WriteAllLines(System.String,System.Collections.Generic.IEnumerable`1<System.String>)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::WriteAllLines(System.String,System.Collections.Generic.IEnumerable`1<System.String>,System.Text.Encoding)\",\"\",[2],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::WriteAllText(System.String,System.String)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::WriteAllText(System.String,System.String,System.Text.Encoding)\",\"\",[2],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::Copy(System.String,System.String)\",\"\",[0,1],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::Copy(System.String,System.String,System.Boolean)\",\"\",[1,2],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::Move(System.String,System.String)\",\"\",[0,1],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::Replace(System.String,System.String,System.String)\",\"\",[0,1,2],[False,False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.File::Replace(System.String,System.String,System.String,System.Boolean)\",\"\",[1,2,3],[False,False,False],[None],Propagation,[])] ReviewPath(System.String)",
"[AspectClass(\"mscorlib,System.IO.FileSystem,System.Runtime\",[None],Sink,[PathTraversal])] Datadog.Trace.Iast.Aspects.FileInfoAspect",
"  [AspectMethodInsertBefore(\"System.IO.FileInfo::.ctor(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.FileInfo::CopyTo(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.FileInfo::CopyTo(System.String,System.Boolean)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.FileInfo::MoveTo(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.FileInfo::Replace(System.String,System.String)\",\"\",[0,1],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.FileInfo::Replace(System.String,System.String,System.Boolean)\",\"\",[1,2],[False,False],[None],Propagation,[])] ReviewPath(System.String)",
"[AspectClass(\"mscorlib,System.IO.FileSystem,System.Runtime\",[None],Sink,[PathTraversal])] Datadog.Trace.Iast.Aspects.FileStreamAspect",
"  [AspectMethodInsertBefore(\"System.IO.FileStream::.ctor(System.String,System.IO.FileMode)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.FileStream::.ctor(System.String,System.IO.FileMode,System.IO.FileAccess)\",\"\",[2],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.FileStream::.ctor(System.String,System.IO.FileMode,System.IO.FileAccess,System.IO.FileShare)\",\"\",[3],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.FileStream::.ctor(System.String,System.IO.FileMode,System.IO.FileAccess,System.IO.FileShare,System.Int32)\",\"\",[4],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.FileStream::.ctor(System.String,System.IO.FileMode,System.IO.FileAccess,System.IO.FileShare,System.Int32,System.Boolean)\",\"\",[5],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.FileStream::.ctor(System.String,System.IO.FileMode,System.IO.FileAccess,System.IO.FileShare,System.Int32,System.IO.FileOptions)\",\"\",[5],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.FileStream::.ctor(System.String,System.IO.FileMode,System.Security.AccessControl.FileSystemRights,System.IO.FileShare,System.Int32,System.IO.FileOptions)\",\"\",[5],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.FileStream::.ctor(System.String,System.IO.FileMode,System.Security.AccessControl.FileSystemRights,System.IO.FileShare,System.Int32,System.IO.FileOptions,System.Security.AccessControl.FileSecurity)\",\"\",[6],[False],[None],Propagation,[])] ReviewPath(System.String)",
"[AspectClass(\"mscorlib,System.IO.FileSystem,System.Runtime\",[None],Sink,[PathTraversal])] Datadog.Trace.Iast.Aspects.StreamReaderAspect",
"  [AspectMethodInsertBefore(\"System.IO.StreamReader::.ctor(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.StreamReader::.ctor(System.String,System.Boolean)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.StreamReader::.ctor(System.String,System.Text.Encoding)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.StreamReader::.ctor(System.String,System.Text.Encoding,System.Boolean)\",\"\",[2],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.StreamReader::.ctor(System.String,System.Text.Encoding,System.Boolean,System.Int32)\",\"\",[3],[False],[None],Propagation,[])] ReviewPath(System.String)",
"[AspectClass(\"mscorlib,System.IO.FileSystem,System.Runtime\",[None],Sink,[PathTraversal])] Datadog.Trace.Iast.Aspects.StreamWriterAspect",
"  [AspectMethodInsertBefore(\"System.IO.StreamWriter::.ctor(System.String)\",\"\",[0],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.StreamWriter::.ctor(System.String,System.Boolean)\",\"\",[1],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.StreamWriter::.ctor(System.String,System.Boolean,System.Text.Encoding)\",\"\",[2],[False],[None],Propagation,[])] ReviewPath(System.String)",
"  [AspectMethodInsertBefore(\"System.IO.StreamWriter::.ctor(System.String,System.Boolean,System.Text.Encoding,System.Int32)\",\"\",[3],[False],[None],Propagation,[])] ReviewPath(System.String)",
"[AspectClass(\"mscorlib\",[None],Propagation,[])] Datadog.Trace.Iast.Aspects.HashAlgorithmAspect",
"  [AspectMethodInsertBefore(\"System.Security.Cryptography.HashAlgorithm::ComputeHash(System.Byte[])\",\"\",[1],[False],[None],Propagation,[])] ComputeHash(System.Security.Cryptography.HashAlgorithm)",
"  [AspectMethodInsertBefore(\"System.Security.Cryptography.HashAlgorithm::ComputeHash(System.Byte[],System.Int32,System.Int32)\",\"\",[3],[False],[None],Propagation,[])] ComputeHash(System.Security.Cryptography.HashAlgorithm)",
"  [AspectMethodInsertBefore(\"System.Security.Cryptography.HashAlgorithm::ComputeHash(System.IO.Stream)\",\"\",[1],[False],[None],Propagation,[])] ComputeHash(System.Security.Cryptography.HashAlgorithm)",
"  [AspectMethodInsertBefore(\"System.Security.Cryptography.HashAlgorithm::ComputeHashAsync(System.IO.Stream,System.Threading.CancellationToken)\",\"\",[2],[False],[None],Propagation,[])] ComputeHash(System.Security.Cryptography.HashAlgorithm)",
"[AspectClass(\"mscorlib\",[None],Propagation,[])] Datadog.Trace.Iast.Aspects.SymmetricAlgorithmAspect",
"  [AspectCtorReplace(\"System.Security.Cryptography.DESCryptoServiceProvider::.ctor()\",\"\",[0],[False],[None],Propagation,[])] InitDES()",
"  [AspectCtorReplace(\"System.Security.Cryptography.RC2CryptoServiceProvider::.ctor()\",\"\",[0],[False],[None],Propagation,[])] InitRC2()",
"  [AspectCtorReplace(\"System.Security.Cryptography.TripleDESCryptoServiceProvider::.ctor()\",\"\",[0],[False],[None],Propagation,[])] InitTripleDES()",
"  [AspectCtorReplace(\"System.Security.Cryptography.RijndaelManaged::.ctor()\",\"\",[0],[False],[None],Propagation,[])] InitRijndaelManaged()",
"  [AspectCtorReplace(\"System.Security.Cryptography.AesCryptoServiceProvider::.ctor()\",\"\",[0],[False],[None],Propagation,[])] InitAesCryptoServiceProvider()",
"  [AspectMethodInsertAfter(\"System.Security.Cryptography.DES::Create()\",\"\",[0],[False],[None],Propagation,[])] Create(System.Security.Cryptography.SymmetricAlgorithm)",
"  [AspectMethodInsertAfter(\"System.Security.Cryptography.DES::Create(System.String)\",\"\",[0],[False],[None],Propagation,[])] Create(System.Security.Cryptography.SymmetricAlgorithm)",
"  [AspectMethodInsertAfter(\"System.Security.Cryptography.RC2::Create()\",\"\",[0],[False],[None],Propagation,[])] Create(System.Security.Cryptography.SymmetricAlgorithm)",
"  [AspectMethodInsertAfter(\"System.Security.Cryptography.RC2::Create(System.String)\",\"\",[0],[False],[None],Propagation,[])] Create(System.Security.Cryptography.SymmetricAlgorithm)",
"  [AspectMethodInsertAfter(\"System.Security.Cryptography.TripleDES::Create()\",\"\",[0],[False],[None],Propagation,[])] Create(System.Security.Cryptography.SymmetricAlgorithm)",
"  [AspectMethodInsertAfter(\"System.Security.Cryptography.TripleDES::Create(System.String)\",\"\",[0],[False],[None],Propagation,[])] Create(System.Security.Cryptography.SymmetricAlgorithm)",
"  [AspectMethodInsertAfter(\"System.Security.Cryptography.Rijndael::Create()\",\"\",[0],[False],[None],Propagation,[])] Create(System.Security.Cryptography.SymmetricAlgorithm)",
"  [AspectMethodInsertAfter(\"System.Security.Cryptography.Rijndael::Create(System.String)\",\"\",[0],[False],[None],Propagation,[])] Create(System.Security.Cryptography.SymmetricAlgorithm)",
"  [AspectMethodInsertAfter(\"System.Security.Cryptography.Aes::Create()\",\"\",[0],[False],[None],Propagation,[])] Create(System.Security.Cryptography.SymmetricAlgorithm)",
"  [AspectMethodInsertAfter(\"System.Security.Cryptography.Aes::Create(System.String)\",\"\",[0],[False],[None],Propagation,[])] Create(System.Security.Cryptography.SymmetricAlgorithm)",
"[AspectClass(\"mscorlib,netstandard,System.Runtime\",[None],Propagation,[])] Datadog.Trace.Iast.Aspects.System.Text.StringBuilderAspects",
"  [AspectCtorReplace(\"System.Text.StringBuilder::.ctor(System.String)\",\"\",[0],[False],[StringLiteral_1],Propagation,[])] Init(System.String)",
"  [AspectCtorReplace(\"System.Text.StringBuilder::.ctor(System.String,System.Int32)\",\"\",[0],[False],[StringLiteral_1],Propagation,[])] Init(System.String,System.Int32)",
"  [AspectCtorReplace(\"System.Text.StringBuilder::.ctor(System.String,System.Int32,System.Int32,System.Int32)\",\"\",[0],[False],[StringLiteral_1],Propagation,[])] Init(System.String,System.Int32,System.Int32,System.Int32)",
"  [AspectMethodReplace(\"System.Object::ToString()\",\"System.Text.StringBuilder\",[0],[False],[None],Propagation,[])] ToString(System.Text.StringBuilder)",
"  [AspectMethodReplace(\"System.Text.StringBuilder::ToString(System.Int32,System.Int32)\",\"\",[0],[False],[None],Propagation,[])] ToString(System.Text.StringBuilder,System.Int32,System.Int32)",
"  [AspectMethodReplace(\"System.Text.StringBuilder::Append(System.String)\",\"\",[0],[False],[StringLiteral_1],Propagation,[])] Append(System.Text.StringBuilder,System.String)",
"  [AspectMethodReplace(\"System.Text.StringBuilder::Append(System.String,System.Int32,System.Int32)\",\"\",[0],[False],[StringLiteral_1],Propagation,[])] Append(System.Text.StringBuilder,System.String,System.Int32,System.Int32)",
"  [AspectMethodReplace(\"System.Text.StringBuilder::Append(System.Char[],System.Int32,System.Int32)\",\"\",[0],[False],[None],Propagation,[])] Append(System.Text.StringBuilder,System.Char[],System.Int32,System.Int32)",
"  [AspectMethodReplace(\"System.Text.StringBuilder::Append(System.Object)\",\"\",[0],[False],[None],Propagation,[])] Append(System.Text.StringBuilder,System.Object)",
"  [AspectMethodReplace(\"System.Text.StringBuilder::Append(System.Char[])\",\"\",[0],[False],[None],Propagation,[])] Append(System.Text.StringBuilder,System.Char[])",
"  [AspectMethodReplace(\"System.Text.StringBuilder::AppendLine(System.String)\",\"\",[0],[False],[StringLiteral_1],Propagation,[])] AppendLine(System.Text.StringBuilder,System.String)",
"[AspectClass(\"System.Web\",[None],Propagation,[])] Datadog.Trace.Iast.Aspects.System.Web.HttpCookieAspect",
"  [AspectMethodReplace(\"System.Web.HttpCookie::get_Value()\",\"\",[0],[False],[None],Propagation,[])] GetValue(System.Web.HttpCookie)",
"[AspectClass(\"mscorlib,netstandard,System.Private.CoreLib,System.Runtime\",[StringOptimization],Propagation,[])] Datadog.Trace.Iast.Aspects.System.StringAspects",
"  [AspectMethodReplace(\"System.String::Trim()\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] Trim(System.String)",
"  [AspectMethodReplace(\"System.String::Trim(System.Char[])\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] Trim(System.String,System.Char[])",
"  [AspectMethodReplace(\"System.String::TrimStart(System.Char[])\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] TrimStart(System.String,System.Char[])",
"  [AspectMethodReplace(\"System.String::TrimEnd(System.Char[])\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] TrimEnd(System.String,System.Char[])",
"  [AspectMethodReplace(\"System.String::Concat(System.String,System.String)\",\"\",[0],[False],[StringLiterals_Any],Propagation,[])] Concat(System.String,System.String)",
"  [AspectMethodReplace(\"System.String::Concat(System.String,System.String)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] Concat_0(System.String,System.String)",
"  [AspectMethodReplace(\"System.String::Concat(System.String,System.String)\",\"\",[0],[False],[StringLiteral_1],Propagation,[])] Concat_1(System.String,System.String)",
"  [AspectMethodReplace(\"System.String::Concat(System.Object,System.Object)\",\"\",[0],[False],[None],Propagation,[])] Concat(System.Object,System.Object)",
"  [AspectMethodReplace(\"System.String::Concat(System.String,System.String,System.String)\",\"\",[0],[False],[StringLiterals],Propagation,[])] Concat(System.String,System.String,System.String)",
"  [AspectMethodReplace(\"System.String::Concat(System.Object,System.Object,System.Object)\",\"\",[0],[False],[None],Propagation,[])] Concat(System.Object,System.Object,System.Object)",
"  [AspectMethodReplace(\"System.String::Concat(System.String,System.String,System.String,System.String)\",\"\",[0],[False],[StringLiterals],Propagation,[])] Concat(System.String,System.String,System.String,System.String)",
"  [AspectMethodReplace(\"System.String::Concat(System.Object,System.Object,System.Object,System.Object)\",\"\",[0],[False],[None],Propagation,[])] Concat(System.Object,System.Object,System.Object,System.Object)",
"  [AspectMethodReplace(\"System.String::Concat(System.String[])\",\"\",[0],[False],[None],Propagation,[])] Concat(System.String[])",
"  [AspectMethodReplace(\"System.String::Concat(System.Object[])\",\"\",[0],[False],[None],Propagation,[])] Concat(System.Object[])",
"  [AspectMethodReplace(\"System.String::Concat(System.Collections.Generic.IEnumerable`1<System.String>)\",\"\",[0],[False],[None],Propagation,[])] Concat(System.Collections.IEnumerable)",
"  [AspectMethodReplace(\"System.String::Concat(System.Collections.Generic.IEnumerable`1<!!0>)\",\"\",[0],[False],[None],Propagation,[])] Concat2(System.Collections.IEnumerable)",
"  [AspectMethodReplace(\"System.String::Substring(System.Int32)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] Substring(System.String,System.Int32)",
"  [AspectMethodReplace(\"System.String::Substring(System.Int32,System.Int32)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] Substring(System.String,System.Int32,System.Int32)",
"  [AspectMethodReplace(\"System.String::ToCharArray()\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] ToCharArray(System.String)",
"  [AspectMethodReplace(\"System.String::ToCharArray(System.Int32,System.Int32)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] ToCharArray(System.String,System.Int32,System.Int32)",
"  [AspectMethodReplace(\"System.String::Join(System.String,System.String[],System.Int32,System.Int32)\",\"\",[0],[False],[None],Propagation,[])] Join(System.String,System.String[],System.Int32,System.Int32)",
"  [AspectMethodReplace(\"System.String::Join(System.String,System.Object[])\",\"\",[0],[False],[None],Propagation,[])] Join(System.String,System.Object[])",
"  [AspectMethodReplace(\"System.String::Join(System.String,System.String[])\",\"\",[0],[False],[None],Propagation,[])] Join(System.String,System.String[])",
"  [AspectMethodReplace(\"System.String::Join(System.String,System.Collections.Generic.IEnumerable`1<System.String>)\",\"\",[0],[False],[None],Propagation,[])] Join(System.String,System.Collections.IEnumerable)",
"  [AspectMethodReplace(\"System.String::Join(System.String,System.Collections.Generic.IEnumerable`1<!!0>)\",\"\",[0],[False],[None],Propagation,[])] Join2(System.String,System.Collections.IEnumerable)",
"  [AspectMethodReplace(\"System.String::ToUpper()\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] ToUpper(System.String)",
"  [AspectMethodReplace(\"System.String::ToUpper(System.Globalization.CultureInfo)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] ToUpper(System.String,System.Globalization.CultureInfo)",
"  [AspectMethodReplace(\"System.String::ToUpperInvariant()\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] ToUpperInvariant(System.String)",
"  [AspectMethodReplace(\"System.String::ToLower()\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] ToLower(System.String)",
"  [AspectMethodReplace(\"System.String::ToLower(System.Globalization.CultureInfo)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] ToLower(System.String,System.Globalization.CultureInfo)",
"  [AspectMethodReplace(\"System.String::ToLowerInvariant()\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] ToLowerInvariant(System.String)",
"  [AspectMethodReplace(\"System.String::Remove(System.Int32)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] Remove(System.String,System.Int32)",
"  [AspectMethodReplace(\"System.String::Remove(System.Int32,System.Int32)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] Remove(System.String,System.Int32,System.Int32)",
"  [AspectMethodReplace(\"System.String::Insert(System.Int32,System.String)\",\"\",[0],[False],[StringOptimization],Propagation,[])] Insert(System.String,System.Int32,System.String)",
"  [AspectMethodReplace(\"System.String::PadLeft(System.Int32)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] PadLeft(System.String,System.Int32)",
"  [AspectMethodReplace(\"System.String::PadLeft(System.Int32,System.Char)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] PadLeft(System.String,System.Int32,System.Char)",
"  [AspectMethodReplace(\"System.String::PadRight(System.Int32)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] PadRight(System.String,System.Int32)",
"  [AspectMethodReplace(\"System.String::PadRight(System.Int32,System.Char)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] PadRight(System.String,System.Int32,System.Char)",
"  [AspectMethodReplace(\"System.String::Format(System.String,System.Object)\",\"\",[0],[False],[None],Propagation,[])] Format(System.String,System.Object)",
"  [AspectMethodReplace(\"System.String::Format(System.String,System.Object,System.Object)\",\"\",[0],[False],[None],Propagation,[])] Format(System.String,System.Object,System.Object)",
"  [AspectMethodReplace(\"System.String::Format(System.String,System.Object,System.Object,System.Object)\",\"\",[0],[False],[None],Propagation,[])] Format(System.String,System.Object,System.Object,System.Object)",
"  [AspectMethodReplace(\"System.String::Format(System.String,System.Object[])\",\"\",[0],[False],[None],Propagation,[])] Format(System.String,System.Object[])",
"  [AspectMethodReplace(\"System.String::Format(System.IFormatProvider,System.String,System.Object)\",\"\",[0],[False],[None],Propagation,[])] Format(System.IFormatProvider,System.String,System.Object)",
"  [AspectMethodReplace(\"System.String::Format(System.IFormatProvider,System.String,System.Object,System.Object)\",\"\",[0],[False],[None],Propagation,[])] Format(System.IFormatProvider,System.String,System.Object,System.Object)",
"  [AspectMethodReplace(\"System.String::Format(System.IFormatProvider,System.String,System.Object,System.Object,System.Object)\",\"\",[0],[False],[None],Propagation,[])] Format(System.IFormatProvider,System.String,System.Object,System.Object,System.Object)",
"  [AspectMethodReplace(\"System.String::Format(System.IFormatProvider,System.String,System.Object[])\",\"\",[0],[False],[None],Propagation,[])] Format(System.IFormatProvider,System.String,System.Object[])",
"  [AspectMethodReplace(\"System.String::Replace(System.Char,System.Char)\",\"\",[0],[False],[None],Propagation,[])] Replace(System.String,System.Char,System.Char)",
"  [AspectMethodReplace(\"System.String::Replace(System.String,System.String)\",\"\",[0],[False],[None],Propagation,[])] Replace(System.String,System.String,System.String)",
"  [AspectMethodReplace(\"System.String::Split(System.Char[])\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] Split(System.String,System.Char[])",
"  [AspectMethodReplace(\"System.String::Split(System.Char[],System.Int32)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] Split(System.String,System.Char[],System.Int32)",
"  [AspectMethodReplace(\"System.String::Split(System.Char[],System.StringSplitOptions)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] Split(System.String,System.Char[],System.StringSplitOptions)",
"  [AspectMethodReplace(\"System.String::Split(System.Char[],System.Int32,System.StringSplitOptions)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] Split(System.String,System.Char[],System.Int32,System.StringSplitOptions)",
"  [AspectMethodReplace(\"System.String::Split(System.String[],System.StringSplitOptions)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] Split(System.String,System.String[],System.StringSplitOptions)",
"  [AspectMethodReplace(\"System.String::Split(System.String[],System.Int32,System.StringSplitOptions)\",\"\",[0],[False],[StringLiteral_0],Propagation,[])] Split(System.String,System.String[],System.Int32,System.StringSplitOptions)",
        };
    }
}
