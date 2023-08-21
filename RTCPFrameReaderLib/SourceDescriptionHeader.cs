namespace RTCPFrameReaderLib
{
	public struct SourceDescriptionHeader
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
		public uint SourceCount
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
		


		public SourceDescriptionHeader( byte Version,bool Padding,uint SourceCount, PacketTypes PacketType, ushort Length)
		{
			this.Version = Version;this.Padding= Padding;this.SourceCount= SourceCount;this.PacketType= PacketType;this.Length= Length;
		}
	}
}