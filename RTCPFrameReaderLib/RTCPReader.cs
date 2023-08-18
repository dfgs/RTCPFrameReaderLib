using BigEndianReaderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPFrameReaderLib
{
	public class RTCPReader:IRTCPReader
	{
		public RTCP Read(byte[] Data)
		{
			BigEndianReader reader;

			RTCPHeader header;
			SenderInfo senderInfo;


			byte value;

			// header
			byte version;
			bool padding;
			uint receptionReportCount;
			PacketTypes packetType;
			ushort length;
			uint senderSSRC;

			// sender info
			ulong ntpTimeStamp;
			uint rtpTimeStamp, senderPacketCount, senderOctetCount;

			// reception report
			uint ssrc;
			byte fractionLost;
			uint cumulatedPacketLost;
			ushort sequenceNumberCycles;
			ushort highestSequenceNumberReceived;
			uint interarrivalJitter;
			uint lastSRTimeStamp;
			uint delaySinceLastSRTimeStamp;

			ReceptionReport[] receptionReports;


			//

			if (Data == null) throw new ArgumentNullException(nameof(Data));
			if (Data.Length <4) throw new ArgumentOutOfRangeException(nameof(Data));

			reader = new BigEndianReader(Data);


			// header
			value=reader.ReadByte();

			version = (byte)((value & 192)>>6);
			padding= (value & 32) !=0;
			receptionReportCount = (uint)(value & 31);
			packetType = (PacketTypes)reader.ReadByte();
			length =reader.ReadUInt16();
			
			if (packetType != PacketTypes.SR) throw new NotImplementedException($"Report type {packetType} is not supported");
			
			senderSSRC = reader.ReadUInt32();

			header = new RTCPHeader(version,padding,receptionReportCount,packetType,length,senderSSRC);

			// sender info
			ntpTimeStamp = reader.ReadUInt64();
			rtpTimeStamp = reader.ReadUInt32();
			senderPacketCount = reader.ReadUInt32();
			senderOctetCount = reader.ReadUInt32();

			senderInfo = new SenderInfo(ntpTimeStamp,rtpTimeStamp,senderPacketCount,senderOctetCount);

			// reception reports
			receptionReports = new ReceptionReport[receptionReportCount];
			for (int t=0;t<receptionReportCount;t++)
			{
				ssrc = reader.ReadUInt32();
				fractionLost = reader.ReadByte();
				cumulatedPacketLost = reader.ReadUInt24();
				sequenceNumberCycles = reader.ReadUInt16();
				highestSequenceNumberReceived= reader.ReadUInt16();
				interarrivalJitter = reader.ReadUInt32();
				lastSRTimeStamp = reader.ReadUInt32();
				delaySinceLastSRTimeStamp = reader.ReadUInt32();

				receptionReports[t]=new ReceptionReport(ssrc,fractionLost,cumulatedPacketLost,sequenceNumberCycles,highestSequenceNumberReceived,interarrivalJitter,lastSRTimeStamp,delaySinceLastSRTimeStamp);
			}


			return new SenderReport(header,senderInfo,receptionReports);

			//throw new NotImplementedException();
		}

	}


}
