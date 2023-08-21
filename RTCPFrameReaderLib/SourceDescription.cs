using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPFrameReaderLib
{
	public record SourceDescription : RTCP
	{
		public SourceDescriptionHeader Header
		{
			get;
			private set;
		}

		public Chunk[] Chunks
		{
			get;
			private set;
		}

		public SourceDescription(SourceDescriptionHeader Header, Chunk[] Chunks) : base()
		{
			this.Header = Header;this.Chunks = Chunks;
		}

	}
}
