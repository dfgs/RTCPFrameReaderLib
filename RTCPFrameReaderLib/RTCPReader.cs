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

			if (Data == null) throw new ArgumentNullException(nameof(Data));
			if (Data.Length <2) throw new ArgumentOutOfRangeException(nameof(Data));

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

			return new SenderReport(header,senderInfo);

			//throw new NotImplementedException();
		}

	}


}
