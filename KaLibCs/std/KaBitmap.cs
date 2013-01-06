using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ka
{
	public class KaBmpDatMgr
	{
		public Bitmap org { get; private set; }
		public PixelFormat format { get; private set; }
		public BitmapData dat { get; private set; }
		//public byte[] buf { get; private set; }

		public KaBmpDatMgr( Bitmap bmp )
		{
			if ( !bmp.KaIs() )
			{
				new ArgumentNullException();
			}

			org = bmp.Clone() as Bitmap;
			format = PixelFormat.Format32bppRgb;

			var w = org.Width;
			var h = org.Height;
			//buf = new byte[ w * h * 4 ];

			dat = org.LockBits(
				new Rectangle( Point.Empty, org.Size ),
				ImageLockMode.WriteOnly,
				format );

			//Marshal.Copy( bmpDat.Scan0, buf, 0, buf.Length );

			org.UnlockBits( dat );
		}

		public virtual Bitmap magnify( int magnification )
		{
			if ( magnification <= 0 )
			{
				return null;
			}

			var w = org.Width;
			var h = org.Height;
			var newW = w * magnification;
			var newH = h * magnification;
			var newLen = newW * newH;

			var newBufList = new List<byte>();
			var pixelDat = new List<byte>();
			var lineBuf = new List<byte>();

			/*foreach ( var b in buf )
			{
				pixelDat.Add( b );

				// 1pixel 分のデータが集まったら倍率の分だけ行用のバッファに格納する
				if ( pixelDat.Count() == 4 )
				{
					for ( var j = 0; j < magnification; ++j )
					{
						lineBuf.AddRange( pixelDat );
					}
					pixelDat = new List<byte>();
				}

				// 1line 分のデータが集まったら倍率の分だけ新しい Bitmap 生成用バッファに格納する
				if ( lineBuf.Count() == newW )
				{
					for ( var j = 0; j < magnification; ++j )
					{
						newBufList.AddRange( lineBuf );
					}
					lineBuf = new List<byte>();
				}
			}*/

			var res = new Bitmap( w * magnification, h * magnification );
			var resDat = res.LockBits(
				new Rectangle( Point.Empty, res.Size ),
				ImageLockMode.WriteOnly,
				format );

			var newBuf = newBufList.ToArray();
			Marshal.Copy( newBuf, 0, resDat.Scan0, newBuf.Length );

			res.UnlockBits( resDat );

			return res;
		}
	}
}
