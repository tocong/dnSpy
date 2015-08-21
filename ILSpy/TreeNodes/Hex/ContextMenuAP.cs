﻿/*
    Copyright (C) 2014-2015 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using ICSharpCode.ILSpy;

namespace dnSpy.TreeNodes.Hex {
	sealed class ContextMenuAP : DependencyObject {
		public static readonly DependencyProperty InstallProperty = DependencyProperty.RegisterAttached(
			"Install", typeof(bool), typeof(ContextMenuAP), new UIPropertyMetadata(false, InstallPropertyChangedCallback));

		public static void SetInstall(FrameworkElement element, bool value) {
			element.SetValue(InstallProperty, value);
		}

		public static bool GetInstall(FrameworkElement element) {
			return (bool)element.GetValue(InstallProperty);
		}

		static void InstallPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			if (!(bool)e.NewValue)
				return;
			var fwe = d as FrameworkElement;
			if (fwe == null)
				return;

			if (fwe is ListView)
				ContextMenuProvider.Add(fwe, ListViewIgnore);
			else
				ContextMenuProvider.Add(fwe);
		}

		static bool ListViewIgnore(DependencyObject o) {
			return o is GridViewHeaderRowPresenter ||
					o is ScrollBar;
		}
	}
}
