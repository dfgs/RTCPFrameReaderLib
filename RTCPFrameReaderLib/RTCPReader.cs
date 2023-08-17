using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPFrameReaderLib
{
	public class RTCPReader
	{
		public RTCP Read(byte[] Data)
		{
			RTCPHeader header;
			SenderInfo senderInfo;

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

			// header
			version = (byte)((Data[0] & 192)>>6);
			padding= (Data[0] & 32) !=0;
			receptionReportCount = (uint)(Data[0] & 31);
			packetType = (PacketTypes)Data[1];
			length = (ushort)((Data[2] << 8) + Data[3]);

			if (packetType != PacketTypes.SR) throw new NotImplementedException($"Report type {packetType} is not supported");
			
			senderSSRC = ((uint)Data[4] << 24) + ((uint)Data[5] << 16) + ((uint)Data[6] << 8) + Data[7];

			header = new RTCPHeader(version,padding,receptionReportCount,packetType,length,senderSSRC);

			// sender info
			ntpTimeStamp = ((ulong)Data[8] << 56) + ((ulong)Data[9] << 48) +((ulong)Data[10] << 40) +((ulong)Data[11] << 32) +((ulong)Data[12] << 24) + ((ulong)Data[13] << 16) + ((ulong)Data[14] << 8) + Data[15];
			rtpTimeStamp = ((uint)Data[16] << 24) + ((uint)Data[17] << 16) + ((uint)Data[18] << 8) + Data[19];
			senderPacketCount = ((uint)Data[20] << 24) + ((uint)Data[21] << 16) + ((uint)Data[22] << 8) + Data[23];
			senderOctetCount = ((uint)Data[24] << 24) + ((uint)Data[25] << 16) + ((uint)Data[26] << 8) + Data[27];

			senderInfo = new SenderInfo(ntpTimeStamp,rtpTimeStamp,senderPacketCount,senderOctetCount);

			// reception reports
			receptionReports = new ReceptionReport[receptionReportCount];
			for (int t=0;t<receptionReportCount;t++)
			{
				ssrc = ((uint)Data[t * 24 + 28]<<24)+ ((uint)Data[t * 24 + 29] << 16)+ ((uint)Data[t * 24 + 30] << 8)+ ((uint)Data[t * 24 + 31] );
				fractionLost = Data[t * 24 + 32];
				cumulatedPacketLost = ((uint)Data[t * 24 + 33] << 16) + ((uint)Data[t * 24 + 34] << 8) + ((uint)Data[t * 24 + 35]);
				sequenceNumberCycles =(ushort)( ((uint)Data[t * 24 + 36] << 8) + ((uint)Data[t * 24 + 37]) );
				highestSequenceNumberReceived= (ushort)(((uint)Data[t * 24 + 38] << 8) + ((uint)Data[t * 24 + 39]));
				interarrivalJitter = ((uint)Data[t * 24 + 40] << 24) + ((uint)Data[t * 24 + 41] << 16) + ((uint)Data[t * 24 + 42] << 8) + ((uint)Data[t * 24 + 43]);
				lastSRTimeStamp = ((uint)Data[t * 24 +44] << 24) + ((uint)Data[t * 24 + 45] << 16) + ((uint)Data[t * 24 + 46] << 8) + ((uint)Data[t * 24 + 47]);
				delaySinceLastSRTimeStamp = ((uint)Data[t * 24 + 48] << 24) + ((uint)Data[t * 24 + 49] << 16) + ((uint)Data[t * 24 + 50] << 8) + ((uint)Data[t * 24 + 51]);

				receptionReports[t]=new ReceptionReport(ssrc,fractionLost,cumulatedPacketLost,sequenceNumberCycles,highestSequenceNumberReceived,interarrivalJitter,lastSRTimeStamp,delaySinceLastSRTimeStamp);
			}


			return new SenderReport(header,senderInfo,receptionReports);

			//throw new NotImplementedException();
		}

	}


}
