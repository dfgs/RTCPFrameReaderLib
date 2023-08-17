using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPFrameReaderLib
{
	public enum PacketTypes { SR = 200, RR = 201, SDES = 202, BYE = 203, APP = 204 }
	public enum SDESTypes { END = 0, CNAME =1,NAME=2,EMAIL=3,PHONE=4,LOC=5,TOOL=6,NOTE=7,PRIV=8 }

}
