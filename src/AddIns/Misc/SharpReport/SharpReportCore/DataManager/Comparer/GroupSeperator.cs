//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Text;
using System.ComponentModel;
using SharpReportCore;
	
	
/// <summary>
/// TODO - Add class summary
/// </summary>
/// <remarks>
/// 	created by - Forstmeier Peter
/// 	created on - 28.11.2005 13:43:22
/// </remarks>

namespace SharpReportCore {
	public class GroupSeperator : SharpReportCore.GroupComparer,IHierarchyData {
		private string typeName = "GroupSeperator";
		
		int groupLevel = 0;
//		GroupSeperator parent = null;
		IHierarchicalArray childs ;
		
		public GroupSeperator(ColumnCollection owner, int listIndex, object[] values,int groupLevel):
			base(owner,listIndex,values) {
			this.groupLevel = groupLevel;
//			this.parent = parent;
		}
		
		
		public int GroupLevel {
			get {
				return groupLevel;
			}
		}
		
		public IHierarchicalArray Childs {
			get {
				return childs;
			}
			set {
				childs = value;
			}
		}
		
		
		
		
		#region SharpReportCore.IHierarchyData interface implementation
		
		public virtual bool HasChildren {
			get {
				return (this.childs.Count > 0);
			}
			
			
		}
		
		public object Item {
			get {
				return this;
			}
		}
		
		public string Path {
			get {
				StringBuilder sb = new StringBuilder();
				foreach (object o in base.ObjectArray) {
					sb.Append(o.ToString() + ";");
				}
				sb.Remove(sb.Length -1,1);
				return sb.ToString();
			}
		}
		
		public string Type {
			get {
				return this.typeName;
			}
		}
		
		public IHierarchicalEnumerable GetChildren() {
			return this.childs;
		}
		
		public IHierarchyData GetParent() {
			return null;
		}
	
		#endregion
		
		public override string ToString (){
			return this.typeName;
		}
	}
}
