using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace ka.WinForm
{
	/// <summary>
	/// リソースに関するクラス。
	/// </summary>
	public class KaResource
	{
		/// <summary>
		/// プロジェクト規定の Resource.resx からリソースを取得。
		/// </summary>
		/// <typeparam name="T">取得するリソースの型。</typeparam>
		/// <param name="obj">取得したリソースを入れる変数。</param>
		/// <param name="name">取得するリソース名。拡張子無しで指定。</param>
		/// <returns></returns>
		public static bool get<T>( out T obj, string name )
			where T : class
		{
			obj = null;

			if ( !name.KaIs() )
			{
				return false;
			}

			// このメソッドが呼ばれたアセンブリを取得し、リソースマネージャを生成。
			var asm = Assembly.GetCallingAssembly();
			var asmName = asm.GetName().Name;
			var mgr = new ResourceManager( asmName + ".Properties.Resources", asm );

			var tmpObj = mgr.GetObject( name );
			if ( !tmpObj.KaIs() )
			{
				return false;
			}

			if ( !( tmpObj is T ) )
			{
				return false;
			}

			obj = tmpObj as T;

			return true;
		}
	}
}
