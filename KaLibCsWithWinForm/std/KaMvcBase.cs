using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaLib.WinForm
{
	/// <summary>
	/// 各 MVC クラスの親クラス。
	/// </summary>
	public class KaMvcBase
	{
		protected static KaModel model { get; private set; }
		protected static KaView view { get; private set; }
		protected static KaController controller { get; private set; }

		/// <summary>
		/// MVC インスタンスをセット。<br />
		/// インスタンスは各 MVC クラスで共有される。
		/// </summary>
		/// <param name="m"></param>
		/// <param name="v"></param>
		/// <param name="c"></param>
		public static void setMvc(
			KaModel m,
			KaView v,
			KaController c )
		{
			model = m;
			view = v;
			controller = c;
		}

		/// <summary>
		/// 初期化メソッド。
		/// </summary>
		/// <remarks>
		/// KaMvcMgr.run 経由で実行した場合は、<br />
		/// model, view contrller の順で呼ばれる。
		/// </remarks>
		protected virtual void init() { }
	}
}
