﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPFrameReaderLib.UnitTest
{
	internal static class Consts
	{
		//public static byte[] RTCPInvalidSize = new byte[] { 0x81, 0xc8, 0x00, 0x0c, 0x5b, 0x91, 0x7d, 0x5a, 0xe8, 0x88, 0x56, 0x0b, 0xb3, 0x8c, 0xc9, 0xa7, 0x00, 0x00, 0xaf, 0x0c, 0x00, 0x00, 0x00, 0xf7, 0x00, 0x00, 0x9a, 0x60, 0x99, 0x49, 0x2c, 0xc5, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x7d, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
		public static byte[] RTCPTooSmall = new byte[] { 0x81 };
		public static byte[] SenderReport1 = new byte[] { 0x81, 0xc8, 0x00, 0x0c, 0x5b, 0x91, 0x7d, 0x5a, 0xe8, 0x88, 0x56, 0x0b, 0xb3, 0x8c, 0xc9, 0xa7, 0x00, 0x00, 0xaf, 0x0c, 0x00, 0x00, 0x00, 0xf7, 0x00, 0x00, 0x9a, 0x60, 0x99, 0x49, 0x2c, 0xc5, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x7d, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
		public static byte[] SenderReport2 = new byte[] { 0x81, 0xc8, 0x00, 0x0c, 0x99, 0x49, 0x2c, 0xc5, 0xe8, 0x88, 0x56, 0x15, 0xbb, 0x17, 0x04, 0xff, 0x78, 0x84, 0xa1, 0x8b, 0x00, 0x00, 0x02, 0xec, 0x00, 0x01, 0xd3, 0x80, 0x5b, 0x91, 0x7d, 0x5a, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4d, 0x50, 0x00, 0x00, 0x00, 0x04, 0x56, 0x15, 0xb4, 0xef, 0x00, 0x00, 0x05, 0x60 };
	}
}
