﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.IO;
using Debugger;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.SharpDevelop.Dom.ClassBrowser;
using System.Linq;

namespace ICSharpCode.SharpDevelop.Gui.Pads
{
	/// <summary>
	/// Description of ClassBrowserSupport.
	/// </summary>
	public static class ClassBrowserSupport
	{
		public static void Attach(Debugger.Process process)
		{
			var classBrowser = SD.GetService<IClassBrowser>();
			classBrowser.SpecialNodes.Add(new DebuggerProcessTreeNode(process));
		}
		
		public static void Detach(Debugger.Process process)
		{
			var classBrowser = SD.GetService<IClassBrowser>();
			var nodes = classBrowser.SpecialNodes
				.Where(n => n.Model == process)
				.ToArray();
			foreach (var node in nodes) {
				classBrowser.SpecialNodes.Remove(node);
			}
		}
	}
	
	class DebuggerTreeNodesFactory : ITreeNodeFactory
	{
		public Type GetSupportedType(object model)
		{
			if (model is Debugger.Process)
				return typeof(Debugger.Process);
			if (model is Debugger.Module)
				return typeof(Debugger.Module);
			return null;
		}
		
		public ICSharpCode.TreeView.SharpTreeNode CreateTreeNode(object model)
		{
			if (model is Debugger.Process)
				return new DebuggerProcessTreeNode((Debugger.Process)model);
			if (model is Debugger.Module)
				return new DebuggerModuleTreeNode((Debugger.Module)model);
			return null;
		}
	}
	
	class DebuggerProcessTreeNode : ModelCollectionTreeNode
	{
		Debugger.Process process;
		IMutableModelCollection<Debugger.Module> modules;
		
		public DebuggerProcessTreeNode(Debugger.Process process)
		{
			if (process == null)
				throw new ArgumentNullException("process");
			this.process = process;
			this.modules = new SimpleModelCollection<Debugger.Module>(this.process.Modules);
			this.process.ModuleLoaded += ModuleLoaded;
			this.process.ModuleUnloaded += ModuleUnloaded;
		}
		
		void ModuleLoaded(object sender, ModuleEventArgs e)
		{
			modules.Add(e.Module);
		}
		
		void ModuleUnloaded(object sender, ModuleEventArgs e)
		{
			modules.Remove(e.Module);
		}
		
		protected override object GetModel()
		{
			return process;
		}
		
		protected override IModelCollection<object> ModelChildren {
			get {
				return modules;
			}
		}
		
		protected override System.Collections.Generic.IComparer<ICSharpCode.TreeView.SharpTreeNode> NodeComparer {
			get {
				return NodeTextComparer;
			}
		}
		
		public override object Text {
			get {
				return Path.GetFileName(process.Filename);
			}
		}
		
		public override object Icon {
			get {
				return IconService.GetImageSource("Icons.16x16.Debug.Start");
			}
		}
	}
	
	class DebuggerModuleTreeNode : AssemblyTreeNode
	{
		Debugger.Module module;
		
		public DebuggerModuleTreeNode(Module module)
			: base(CreateAssemblyModel(module))
		{
			if (module == null)
				throw new ArgumentNullException("module");
			this.module = module;
		}
		
		public override object Icon {
			get {
				return IconService.GetImageSource("PadIcons.LoadedModules");
			}
		}
		
		public override object Text {
			get {
				return module.Name;
			}
		}
		
		static IAssemblyModel CreateAssemblyModel(Module module)
		{
			// references??
			IEntityModelContext context = new AssemblyEntityModelContext(module.Assembly.UnresolvedAssembly);
			IAssemblyModel model = SD.GetRequiredService<IModelFactory>().CreateAssemblyModel(context);
			if (model is IUpdateableAssemblyModel) {
				((IUpdateableAssemblyModel)model).Update(EmptyList<IUnresolvedTypeDefinition>.Instance, module.Assembly.TopLevelTypeDefinitions.SelectMany(td => td.Parts).ToList());
			}
			return model;
		}
	}
}
