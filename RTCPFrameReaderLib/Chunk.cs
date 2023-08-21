using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPFrameReaderLib
{
	public struct Chunk
	{
		public uint SSRC
		{
			get;
			private set;
		}

		public Chunk(uint SSRC)
		{
			this.SSRC = SSRC;
		}
	}
}
