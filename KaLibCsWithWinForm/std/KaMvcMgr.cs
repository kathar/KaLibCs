using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace KaLib.WinForm
{
	/// <summary>
	/// Windows Form アプリで MVC パターンを用いる際、<br />
	/// 様々な手助けするクラス。
	/// </summary>
	public static class KaMvcMgr
	{
		/// <summary>
		/// 初期化から初回実行までを行うクラス。
		/// </summary>
		/// <remarks>
		/// 現状、エラー処理などは行なっていない。
		/// </remarks>
		public static void Run()
		{
			var asm = Assembly.GetCallingAssembly();
			var types = asm.GetTypes();
			var typeDic = new Dictionary<string, Type>();

			foreach ( var type in types )
			{
				typeDic[ type.BaseType.Name ] = type;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );

			// MVC 各クラスのインスタンスを生成。
			var m = Activator.CreateInstance( typeDic[ "KaModel" ] ) as KaModel;
			var v = Activator.CreateInstance( typeDic[ "KaView" ] ) as KaView;
			var c = Activator.CreateInstance( typeDic[ "KaController" ] ) as KaController;
			KaMvcBase.setMvc( m, v, c );

			// 初期化メソッドを実行。
			var flag = BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic;
			m.GetType().InvokeMember( "init", flag, null, m, null );
			v.GetType().InvokeMember( "init", flag, null, v, null );
			c.GetType().InvokeMember( "init", flag, null, c, null );

			Application.Run( c.ac.MainForm );
		}
	}
}
