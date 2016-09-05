using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			//dynamic型
			try {
				DynamicSample();
			}
			catch { }

			//************************************************
			{ 
			var e1 = new Employee("abe1") { Name = "abe2" };
			var e2 = new Employee(name: "ok");
			var e3 = new Employee("kiyo", age: 12);

			Console.WriteLine($"e1.Name={e1.Name}");//abe2
			}
			//************************************************
			{ 
			string[] a = { "a", "b", "c" };
			foreach (var n in a.Select((s, i) => new { i, s }))
				Console.WriteLine($"{n.s}さんは、{n.i + 1}位です。");
			}
			//************************************************
			{ 
			string[] a = { "a", "b", null, "d" };
			foreach (var n in a.Where(c => c != null).Select((s, i) => new { i, s }))
				Console.WriteLine($"{n.s}さんは、{n.i + 1}位です。");
			}
			//************************************************
			{
				string str = "123a";
				int result;
				result = int.TryParse(str, out result) ? result : -1;
				Console.WriteLine($"{result}");//-1
				result = -2;
				int.TryParse(str, out result);
				Console.WriteLine($"{result}");//0
			}
			//************************************************
			{
				有効無効 a;
				Enum.TryParse<有効無効>("はてな", out a);
				Console.WriteLine($"{a}");	//無効
				Enum.TryParse<有効無効>("有効", out a);
				Console.WriteLine($"{a}");	//有効

			}
			//************************************************
			{
				string a = null;
				Console.WriteLine(a ?? "(null)");	//(null)
				a = "a";
				Console.WriteLine(a ?? "(null)");	//a
			}
			//************************************************
			{
				var ex = new Example() { A = "{0} {1}", B = "bbb", C = "cccc" };
				Console.WriteLine($"{ex.A}", $"{ex.B}", $"{ex.C}");
			}
			//************************************************
			{ 
				Action cut = () => { };
				string str = "abc";
				if (str.Length > 0)
				{
					cut = () => str = str.Remove(str.Length - 1, 1);
				}
				cut();
				Console.WriteLine($"{str}");
			}
			//************************************************
			{
				Action<string> action = s => { };
				Greeting(s => { Console.WriteLine($"{s}さん"); });
				Greeting(s => { Console.WriteLine($"{s}くん"); });
			}
			//************************************************
			{
				//パラメータの設定
				TestOptionParam(amt:100, shop:"ok");
			}
			//************************************************
			{
				//Properties.Settings setting = new Properties.Settings();
				//DataClasses1DataContext context = new DataClasses1DataContext(setting.WAStorageEmulatorDb30ConnectionString);

				//var c = context.Account.Count();
				//Console.WriteLine("Account Count:" + c);

			}
			{ 
				var model = new Model1();

				//model.Database.Log = p => Console.WriteLine(p);

				Console.WriteLine("Account Count:" + model.Accounts.Count());

			}

			{
				//即興で連番を作成してチェックする。（C# Interactiveでチェック可能）
				//http://cheesememo.blog39.fc2.com/blog-entry-721.html
				Enumerable.Range(0, 100).All(i => { Console.WriteLine($"{(i / 5) + 1}");return true;});

			}

			{
				//実行する。
				C_逆引きレシピ.Run();
			}
			Console.ReadLine();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shop">店舗コード（空(null)の場合は担当店舗）</param>
		/// <param name="amt"></param>
		/// <param name="age"></param>
		static void TestOptionParam(string shop = null, int amt = 0, int age = 0)
		{

		}

		static void Greeting(Action<string> action)
		{
			Console.WriteLine("start");
			action("hogehoge");
			Console.WriteLine("end");
		}

		class Example { internal string A, B, C; }

		enum 有効無効
		{
			有効 = 1,
			無効 = 0
		}

		class Employee
		{
			public Employee(string name, int age = 0, string bikou = "")
			{
				Name = name;
			}

			public string Name { get; set; }
		}

		static void DynamicSample()
		{
			dynamic dyn = 1;
			object obj = 1;

			Console.WriteLine(dyn.GetType());
			Console.WriteLine(obj.GetType());

			dyn.HogeHoge();
			//obj.HogeHoge();
			/*
  Microsoft.CSharp.RuntimeBinder.RuntimeBinderException はハンドルされませんでした。
  HResult=-2146233088
  Message='int' に 'HogeHoge' の定義がありません
  Source=Anonymously Hosted DynamicMethods Assembly
  StackTrace:
       場所 CallSite.Target(Closure , CallSite , Object )
       場所 System.Dynamic.UpdateDelegates.UpdateAndExecuteVoid1[T0](CallSite site, T0 arg0)
       場所 ConsoleApplication.Program.DynamicSample() 場所 D:\dev\sample\20160426_C#4.0\ConsoleApplication\ConsoleApplication\Program.cs:行 30
       場所 ConsoleApplication.Program.Main(String[] args) 場所 D:\dev\sample\20160426_C#4.0\ConsoleApplication\ConsoleApplication\Program.cs:行 14
       場所 System.AppDomain._nExecuteAssembly(RuntimeAssembly assembly, String[] args)
       場所 System.AppDomain.ExecuteAssembly(String assemblyFile, Evidence assemblySecurity, String[] args)
       場所 Microsoft.VisualStudio.HostingProcess.HostProc.RunUsersAssembly()
       場所 System.Threading.ThreadHelper.ThreadStart_Context(Object state)
       場所 System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
       場所 System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
       場所 System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
       場所 System.Threading.ThreadHelper.ThreadStart()
  InnerException: 
			 */
		}


	}
}
