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
	/// <summary>
	/// Bitmap のバイナリデータを扱うクラス。
	/// </summary>
	public class KaBmpDatMgr
	{
		public Bitmap org { get; private set; }
		public PixelFormat format { get; private set; }
		public KaBitmapData dat { get; private set; }

		private static readonly int pixelDatLen = 4;

		/// <summary>
		/// コンストラクタ。ピクセルフォーマットはデフォルトで ARGB を扱う。
		/// </summary>
		/// <remarks>
		/// 現状、32bit の ARGB, RGB のみを扱う。
		/// </remarks>
		/// <param name="bmp"></param>
		/// <param name="format"></param>
		public KaBmpDatMgr( Bitmap bmp, PixelFormat format = PixelFormat.Format32bppArgb )
		{
			if ( !bmp.KaIs() )
			{
				new ArgumentNullException();
			}

			org = bmp.Clone() as Bitmap;
			this.format = format;

			var w = org.Width;
			var h = org.Height;
			var buf = new byte[ w * h * pixelDatLen ];

			var tmpDat = org.LockBits(
				new Rectangle( Point.Empty, org.Size ),
				ImageLockMode.WriteOnly,
				format );

			Marshal.Copy( tmpDat.Scan0, buf, 0, buf.Length );

			org.UnlockBits( tmpDat );

			dat = new KaBitmapData( buf, w, h );
		}

		/// <summary>
		/// 特定倍率に拡大した Bitmap オブジェクトを返す。補完処理ではなく、ピクセル自体が拡大するようなもの。
		/// </summary>
		/// <param name="magnification"></param>
		/// <returns></returns>
		public virtual Bitmap magnify( int magnification )
		{
			if ( magnification <= 0 )
			{
				return null;
			}

			var w = dat.w;
			var h = dat.h;

			var newBufList = new List<byte>();
			var newLineBufList = new List<byte>();
			for ( var x = 0; x < w; ++x )
			{
				for ( var y = 0; y < h; ++y )
				{
					// ピクセルデータを横に増やす。
					for ( var cnt = 0; cnt < magnification; ++cnt )
					{
						// b, g, r, a の順に入れる
						newLineBufList.Add( dat.b[ y, x ] );
						newLineBufList.Add( dat.g[ y, x ] );
						newLineBufList.Add( dat.r[ y, x ] );
						newLineBufList.Add( dat.a[ y, x ] );
					}

					// 1 行分溜まったら、行を増やす。
					if( newLineBufList.Count()
						== w * pixelDatLen * magnification )
					{
						for ( var cnt = 0; cnt < magnification; ++cnt )
						{
							newBufList.AddRange( newLineBufList );
						}
						newLineBufList = new List<byte>();
					}
				}
			}

			// 拡大した Bitmap オブジェクトを生成する。
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
