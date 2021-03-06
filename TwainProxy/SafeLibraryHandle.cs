﻿////////////////////////////////////////////////////////////////////////
//
// This file is part of pdn-twainable-plus, an Effect plugin for
// Paint.NET that imports images from TWAIN devices.
//
// Copyright (c) 2014, 2017, 2018 Nicholas Hayes
//
// This file is licensed under the MIT License.
// See LICENSE.txt for complete licensing and attribution information.
//
////////////////////////////////////////////////////////////////////////

using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;

/* The following code is quoted from Mike Stall's blog
 * Type-safe Managed wrappers for kernel32!GetProcAddress
 * http://blogs.msdn.com/b/jmstall/archive/2007/01/06/typesafe-getprocaddress.aspx
 */

namespace TwainProxy
{
	/// <summary>
	/// See http://msdn.microsoft.com/msdnmag/issues/05/10/Reliability/
	/// for more about safe handles.
	/// </summary>
	[SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
	internal sealed class SafeLibraryHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		/// <summary>
		/// Create safe library handle
		/// </summary>
		private SafeLibraryHandle() : base(true) { }

		/// <summary>
		/// Release handle
		/// </summary>
		protected override bool ReleaseHandle()
		{
			return UnsafeNativeMethods.FreeLibrary(handle);
		}
	}

}


