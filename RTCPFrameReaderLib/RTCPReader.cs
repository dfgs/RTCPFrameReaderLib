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
			if (Data == null) throw new ArgumentNullException(nameof(Data));
			if (Data.Length < 4) throw new ArgumentOutOfRangeException(nameof(Data));
			return Read(new BigEndianReader(Data));
		}

		public RTCP Read(IBigEndianReader Reader)
		{

			ReportHeader reportHeader;
			SenderInfo senderInfo;

			SourceDescriptionHeader sdesHeader;

			byte value;

			// header
			byte version;
			bool padding;
			uint count;
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
			Chunk[] chunks;
			List<SDESItem> items;
			SDESItemTypes sdesItemType;
			string text;
			byte sdesLength;
			//


			if (Reader == null) throw new ArgumentNullException(nameof(Reader));


			// header
			value = Reader.ReadByte();

			version = (byte)((value & 192)>>6);
			padding= (value & 32) !=0;
			count = (uint)(value & 31);
			packetType = (PacketTypes)Reader.ReadByte();
			length =Reader.ReadUInt16();
			
			switch(packetType)
			{
				case PacketTypes.SR:
					senderSSRC = Reader.ReadUInt32();

					reportHeader = new ReportHeader(version, padding, count, packetType, length, senderSSRC);

					// sender info
					ntpTimeStamp = Reader.ReadUInt64();
					rtpTimeStamp = Reader.ReadUInt32();
					senderPacketCount = Reader.ReadUInt32();
					senderOctetCount = Reader.ReadUInt32();

					senderInfo = new SenderInfo(ntpTimeStamp, rtpTimeStamp, senderPacketCount, senderOctetCount);

					// reception reports
					receptionReports = new ReceptionReport[count];
					for (int t = 0; t < count; t++)
					{
						ssrc = Reader.ReadUInt32();
						fractionLost = Reader.ReadByte();
						cumulatedPacketLost = Reader.ReadUInt24();
						sequenceNumberCycles = Reader.ReadUInt16();
						highestSequenceNumberReceived = Reader.ReadUInt16();
						interarrivalJitter = Reader.ReadUInt32();
						lastSRTimeStamp = Reader.ReadUInt32();
						delaySinceLastSRTimeStamp = Reader.ReadUInt32();

						receptionReports[t] = new ReceptionReport(ssrc, fractionLost, cumulatedPacketLost, sequenceNumberCycles, highestSequenceNumberReceived, interarrivalJitter, lastSRTimeStamp, delaySinceLastSRTimeStamp);
					}

					return new SenderReport(reportHeader, senderInfo, receptionReports);
				case PacketTypes.SDES:
					sdesHeader = new SourceDescriptionHeader(version, padding, count, packetType, length);


					chunks= new Chunk[count];
					for(int t= 0; t < count;t++)
					{
						senderSSRC = Reader.ReadUInt32();

						items = new List<SDESItem>();
						do
						{
							sdesItemType = (SDESItemTypes)Reader.ReadByte();
							if (sdesItemType != SDESItemTypes.END)
							{
								sdesLength = Reader.ReadByte();
								text = Reader.ReadString(sdesLength, Encoding.UTF8);
							}
							else
							{
								// no length byte for SDESItemTypes.END, only 32b padding
								sdesLength = 0;text = "";
							}

							items.Add(new SDESItem(sdesItemType, sdesLength, text));

						} while (sdesItemType != SDESItemTypes.END);
						// need to align to 32 bits boundary position
						chunks[t] = new Chunk(senderSSRC, items.ToArray());
					}

					return new SourceDescription(sdesHeader,chunks);
				default:
					throw new NotImplementedException($"Report type {packetType} is not supported");
			}

			
			

		}

	}


}
