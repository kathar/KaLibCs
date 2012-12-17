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

			var m = Activator.CreateInstance( typeof( KaModel ) ) as KaModel;
			var v = Activator.CreateInstance( typeof( KaView ) ) as KaView;
			var c = Activator.CreateInstance( typeof( KaController ) ) as KaController;
			KaMvcBase.setMvc( m, v, c );

			var mInit = m.GetType().GetMethod( "init", BindingFlags.Instance | BindingFlags.NonPublic );
			var vInit = v.GetType().GetMethod( "init", BindingFlags.Instance | BindingFlags.NonPublic );
			var cInit = c.GetType().GetMethod( "init", BindingFlags.Instance | BindingFlags.NonPublic );

			mInit.Invoke( m, null );
			vInit.Invoke( v, null );
			cInit.Invoke( c, null );

			Application.Run( c.ac.MainForm );
		}
	}
}
