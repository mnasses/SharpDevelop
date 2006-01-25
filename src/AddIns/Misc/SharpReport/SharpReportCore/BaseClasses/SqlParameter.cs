//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace SharpReportCore {
	using System;
	using System.Data;
	using System.Globalization;
	
	using SharpReportCore;
	
	/// <summary>
	/// According to the definition in
	/// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/rsrdl/htm/rsp_ref_rdl_elements_qz_629g.asp
	/// 
	/// This Class definies a Reportparameter
	/// </summary>
	/// <remarks>
	/// 	created by - Forstmeier Peter
	/// 	created on - 30.05.2005 22:20:41
	/// </remarks>
	public class SqlParameter : AbstractParameter {
	
		DbType	dataType;
		object defaultValue;
//		bool allowBlank;
		ParameterDirection  parameterDirection = ParameterDirection.InputOutput;
	
		#region Constructor
		
		public SqlParameter():base() {
		}
		

		
		public SqlParameter(string parameterName,
		                    DbType dataType,
		                    object value)
			:this(parameterName,dataType,value,String.Empty,ParameterDirection.Input){
			
		}
		
		
		public SqlParameter(string parameterName,
		                    DbType dataType,
		                    object value,
		                    string prompt,
		                    ParameterDirection parameterDirection):base(){
		
			base.ParameterName = parameterName;
			this.DataType = dataType;
			this.defaultValue = value;
			base.Nullable = false;
			base.Prompt = prompt;
			this.parameterDirection = parameterDirection;
		}
		
		#endregion
	
		private void SetValue (string value) {
			switch( this.DataType )
			{
					//string type
				case DbType.Object					:
				case DbType.Binary					:
				case DbType.AnsiString				:
				case DbType.AnsiStringFixedLength	:
				case DbType.String					:
				case DbType.StringFixedLength		: this.defaultValue = value; break;
					
				case DbType.Boolean					: {
					
					this.defaultValue = bool.Parse( value);
					break;
					}
				                                                      
					
				case DbType.SByte					: {
					this.defaultValue = sbyte.Parse( value,
					                                CultureInfo.CurrentCulture );
					break;
				}
				case DbType.Byte					:{
						this.defaultValue = byte.Parse( value ,
					                               CultureInfo.CurrentCulture );
					break;
				}
				case DbType.Int16					: {
					this.defaultValue = short.Parse( value,CultureInfo.CurrentCulture  ); break;
				}
				case DbType.Int32					: {
					this.defaultValue = int.Parse( value,CultureInfo.CurrentCulture  ); 
					break;
				}
				case DbType.Int64					: {
					this.defaultValue = long.Parse( value,CultureInfo.CurrentCulture  );
					break;
				}
				case DbType.UInt16				: this.defaultValue = ushort.Parse( value,CultureInfo.CurrentCulture  ); break;
				case DbType.UInt32				: this.defaultValue = uint.Parse( value,CultureInfo.CurrentCulture  ); break;
				case DbType.UInt64				: this.defaultValue = long.Parse( value,CultureInfo.CurrentCulture  ); break;
					
				case DbType.Date					:
				case DbType.DateTime				:
				case DbType.Time					: this.defaultValue = DateTime.Parse( value,CultureInfo.CurrentCulture  ); break;
					
				case DbType.Decimal				: this.defaultValue = decimal.Parse( value ,CultureInfo.CurrentCulture ); break;
				case DbType.Currency				:
				case DbType.VarNumeric			:
				case DbType.Double				: this.defaultValue = double.Parse( value ,CultureInfo.CurrentCulture ); break;
				case DbType.Single				: this.defaultValue = float.Parse( value,CultureInfo.CurrentCulture  );  break;
					
				case DbType.Guid					: this.defaultValue = new Guid( value ); break;
				default								: {
					throw new ArgumentOutOfRangeException("value");
				}
			}
		}
		
		
		
		/// <summary>
		/// DataType of the Parameter
		/// <see cref="System.Data.DbType">DbType</see>
		/// </summary>
		public DbType DataType {
			get {
				return dataType;
			}
			set {
				
				dataType = value;
			
				switch( value ){
						//string type
					case DbType.AnsiString				:
					case DbType.AnsiStringFixedLength	:
					case DbType.String					:
					case DbType.StringFixedLength		:{
							this.defaultValue = new string( (char[])null );
							break;
					}
						//array type
					case DbType.Binary				: this.defaultValue = new byte[8000]; break;
						//bool type
					case DbType.Boolean				: this.defaultValue = new bool(); break;
						//interger type
					case DbType.SByte					: this.defaultValue = new sbyte(); break;
					case DbType.Byte					: this.defaultValue = new byte(); break;
					case DbType.Int16					: this.defaultValue = new short(); break;
					case DbType.Int32					: this.defaultValue = new int(); break;
					case DbType.Int64					: this.defaultValue = new long(); break;
					case DbType.UInt16				: this.defaultValue = new ushort(); break;
					case DbType.UInt32				: this.defaultValue = new uint(); break;
					case DbType.UInt64				: this.defaultValue = new long(); break;
						//Date type
					case DbType.Date					:
					case DbType.DateTime				:
					case DbType.Time					:{
							this.defaultValue = new DateTime();
							break;
						}
						//float type
					case DbType.Decimal				: this.defaultValue = new decimal(); break;
					case DbType.Currency				:
					case DbType.VarNumeric			:
					case DbType.Double				: this.defaultValue = new double(); break;
					case DbType.Single				: this.defaultValue = new float(); break;
						//user defined
					case DbType.Object				: this.defaultValue = new object(); break;
						//Guid
					case DbType.Guid					: this.defaultValue = new Guid(); break;
					default								: throw new ArgumentOutOfRangeException("value");
				}
				
			}
		}


//		/// <summary>
//		/// Is a Blank value allowed
//		/// </summary>
//		public bool AllowBlank {
//			get {
//				return allowBlank;
//			}
//		}
		/// <summary>
		/// When no value is entered, use this value
		/// </summary>
		public override object DefaultValue {
			get {
				return defaultValue;
			}
			set {
				SetValue (value.ToString());
			}
		}
		
		///<summary>
		/// Direction of Parameter 
		/// <see cref="System.Data.ParameterDirection">ParameterDirection</see>
		///</summary>
		
		public ParameterDirection ParameterDirection {
			get {
				return parameterDirection;
			}
			set {
				parameterDirection = value;
			}
		}
		
	}
}
