using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ka.WinForm
{
	/// <summary>
	/// 各 MVC クラスの親クラス。
	/// </summary>
	public class KaMvcBase
	{
		public static KaModel model;
		public static KaView view;
		public static KaController controller;

		/// <summary>
		/// MVC インスタンスをセット。<br />
		/// インスタンスは各クラスで共有される。
		/// </summary>
		/// <param name="model"></param>
		/// <param name="view"></param>
		/// <param name="controller"></param>
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
