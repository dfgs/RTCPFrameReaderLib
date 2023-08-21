using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPFrameReaderLib
{
	public struct SDESItem
	{
		public SDESItemTypes Type
		{
			get;
			private set;
		}
		public byte Length
		{
			get;
			private set;
		}
		public string Text
		{
			get;
			private set;
		}

		public SDESItem(SDESItemTypes Type, byte Length, string Text)
		{
			this.Type = Type;this.Length = Length;this.Text = Text;
		}

	}
}
