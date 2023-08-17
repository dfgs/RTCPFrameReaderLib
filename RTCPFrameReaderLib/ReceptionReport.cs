using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPFrameReaderLib
{
	public struct ReceptionReport
	{

		
		public uint SSRC
		{
			get;
			private set;
		}
		public byte FractionLost
		{
			get;
			private set;
		}
		public uint CumulatedPacketLost
		{
			get;
			private set;
		}
		
		public ushort SequenceNumberCycles
		{
			get;
			private set;
		}
		public ushort HighestSequenceNumberReceived
		{
			get;
			private set;
		}
		public uint InterarrivalJitter
		{
			get;
			private set;
		}

		public uint LastSRTimeStamp
		{
			get;
			private set;
		}
		public uint DelaySinceLastSRTimeStamp
		{
			get;
			private set;
		}

		public ReceptionReport(uint SSRC,byte FractionLost,uint CumulatedPacketLost, ushort SequenceNumberCycles, ushort HighestSequenceNumberReceived, uint InterarrivalJitter, uint LastSRTimeStamp, uint DelaySinceLastSRTimeStamp)
		{
			this.SSRC = SSRC;this.FractionLost = FractionLost;this.CumulatedPacketLost = CumulatedPacketLost;this.SequenceNumberCycles = SequenceNumberCycles;this.HighestSequenceNumberReceived = HighestSequenceNumberReceived;this.InterarrivalJitter = InterarrivalJitter;this.LastSRTimeStamp = LastSRTimeStamp;this.DelaySinceLastSRTimeStamp = DelaySinceLastSRTimeStamp;
		}


	}
}
