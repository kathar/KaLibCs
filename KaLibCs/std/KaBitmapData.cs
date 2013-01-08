using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ka
{
	/// <summary>
	/// Bitmap バイナリデータの 1 ピクセルのデータを扱うクラス。
	/// </summary>
	public class KaBitmapData
	{
		public readonly int w;
		public readonly int h;
		public byte[,] a { get; set; }
		public byte[,] r { get; set; }
		public byte[,] g { get; set; }
		public byte[,] b { get; set; }

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="buf"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		public KaBitmapData( byte[] buf, int w, int h )
		{
			if ( !buf.KaIs() )
			{
				new ArgumentNullException();
			}

			if ( buf.Length <= 0
				|| w <= 0
				|| h <= 0 )
			{
				new ArgumentException();
			}

			this.w = w;
			this.h = h;

			a = new byte[ this.h, this.w ];
			r = new byte[ this.h, this.w ];
			g = new byte[ this.h, this.w ];
			b = new byte[ this.h, this.w ];

			for ( int y = 0; y < this.h; y++ )
			{
				for ( int x = 0; x < this.w; x++ )
				{
					a[ x, y ] = buf[ ( y * w + x ) * 4 + 3 ];
					r[ x, y ] = buf[ ( y * w + x ) * 4 + 2 ];
					g[ x, y ] = buf[ ( y * w + x ) * 4 + 1 ];
					b[ x, y ] = buf[ ( y * w + x ) * 4 ];
				}
			}
		}
	}
}
