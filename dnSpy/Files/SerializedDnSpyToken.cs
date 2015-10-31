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

using System;
using dnlib.DotNet;

namespace dnSpy.Files {
	public struct SerializedDnSpyToken : IEquatable<SerializedDnSpyToken> {
		public SerializedDnSpyModule Module {
			get { return module; }
		}
		/*readonly*/ SerializedDnSpyModule module;

		public uint Token {
			get { return token; }
		}
		readonly uint token;

		public SerializedDnSpyToken(SerializedDnSpyModule module, MDToken mdToken)
			: this(module, mdToken.Raw) {
		}

		public SerializedDnSpyToken(SerializedDnSpyModule module, uint token) {
			this.module = module;
			this.token = token;
		}

		public bool Equals(SerializedDnSpyToken other) {
			return token == other.token &&
					module.Equals(other.module);
		}

		public override bool Equals(object obj) {
			var other = obj as SerializedDnSpyToken?;
			if (other != null)
				return Equals(other.Value);
			return false;
		}

		public override int GetHashCode() {
			return module.GetHashCode() ^ (int)token;
		}

		public override string ToString() {
			return string.Format("{0:X8} {1}", token, module);
		}
	}
}
