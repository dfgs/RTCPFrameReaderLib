using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPFrameReaderLib
{
	public struct SenderInfo
	{

		public uint NTPTimeStampIntegerPart
		{
			get;
			private set;
		}
		public uint NTPTimeStampFractionalPart
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

		public SenderInfo(uint NTPTimeStampIntegerPart, uint NTPTimeStampFractionalPart, uint RTPTimeStamp,uint SenderPacketCount,uint SenderOctetCount)
		{
			this.NTPTimeStampIntegerPart = NTPTimeStampIntegerPart;
			this.NTPTimeStampFractionalPart = NTPTimeStampFractionalPart;
			this.RTPTimeStamp = RTPTimeStamp;this.SenderPacketCount = SenderPacketCount;this.SenderOctetCount = SenderOctetCount;
		}


	}
}
