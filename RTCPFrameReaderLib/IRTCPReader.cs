using BigEndianReaderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPFrameReaderLib
{
	public interface IRTCPReader
	{
		RTCP Read(byte[] Data);
		RTCP Read(IBigEndianReader Reader);
	}
}
