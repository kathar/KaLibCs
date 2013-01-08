using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ka
{
	public static class KaExtensionForObject
	{
		/// <summary>
		/// 変数が有効な値かどうかを判定する。
		/// </summary>
		/// <remarks>
		/// プリミティブ型は、bool はその値、それ以外は false。<br />
		/// それ以外の型は、null の場合、string 型、char 型は空文字・空文字列も false。
		/// </remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="self"></param>
		/// <returns></returns>
		public static bool KaIs<T>( this T self )
		{
			if ( self == null )
			{
				return false;
			}

			var t = self.GetType();

			if ( t.IsPrimitive )
			{
				// bool 型はそのままの値を返す
				if ( t == typeof( bool ) )
				{
					return ( bool )Convert.ChangeType( self, typeof( bool ) );
				}

				return false;
			}
			else
			{
				if ( self == null )
				{
					return false;
				}

				// string 型
				if ( t == typeof( string ) )
				{
					var s = ( string )Convert.ChangeType( self, typeof( string ) );
					if ( s == "" )
					{
						return false;
					}
				}

				// char 型
				if ( t == typeof( char ) )
				{
					var c = ( char )Convert.ChangeType( self, typeof( char ) );
					if ( c == '\0' )
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}
