namespace RTCPFrameReaderLib
{
	public struct ReportHeader
	{
		public byte Version
		{
			get;
			private set;
		}
		public bool Padding
		{
			get;
			private set;
		}
		public uint ReceptionReportCount
		{
			get;
			private set;
		}

		public PacketTypes PacketType
		{
			get;
			private set;
		}

		public ushort Length
		{
			get;
			private set;
		}
		public uint SenderSSRC
		{
			get;
			private set;
		}


		public ReportHeader( byte Version,bool Padding,uint ReceptionReportCount, PacketTypes PacketType, ushort Length, uint SenderSSRC)
		{
			this.Version = Version;this.Padding= Padding;this.ReceptionReportCount= ReceptionReportCount;this.PacketType= PacketType;this.Length= Length;this.SenderSSRC= SenderSSRC;
		}
	}
}