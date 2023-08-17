using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPFrameReaderLib
{
	public struct SenderInfo
	{

		public ulong NTPTimeStamp
		{
			get;
			private set;
		}
		public uint RTPTimeStamp
		{
			get;
			private set;
		}
		public uint SenderPacketCount
		{
			get;
			private set;
		}

		public uint SenderOctetCount
		{
			get;
			private set;
		}

		public SenderInfo(ulong NTPTimeStamp,uint RTPTimeStamp,uint SenderPacketCount,uint SenderOctetCount)
		{
			this.NTPTimeStamp = NTPTimeStamp;this.RTPTimeStamp = RTPTimeStamp;this.SenderPacketCount = SenderPacketCount;this.SenderOctetCount = SenderOctetCount;
		}


	}
}
