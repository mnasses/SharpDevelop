//
// SharpDevelop ReportEditor
//
// Copyright (C) 2005 Peter Forstmeier
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//
// Peter Forstmeier (Peter.Forstmeier@t-online.de)

namespace SharpReportCore{
	using System;
	using System.Globalization;
	using System.Windows.Forms;
	/// <summary>
	/// This Class handles the formatting of Output Values depending on there
	/// Type and DbValue
	/// </summary>
	/// <remarks>
	/// 	created by - Forstmeier Peter
	/// 	created on - 30.03.2005 09:14:20
	/// </remarks>
	public class DefaultFormatter : AbstractFormatter {
		
		
		public DefaultFormatter() {
		}
		
		///<summary>Looks witch formatting Class to use, call the approbiate formatter
		/// and update the DbValue with the formatted String value
		/// </summary>
		///<param name="item">A ReportDataItem</param>
		/// 
		public string FormatItem (BaseDataItem item) {
			string retValue = String.Empty;
			try {
				switch (item.DataType) {
					
					case "System.DateTime" :
						retValue = DateValues(item.DbValue,item.FormatString);
						break;
						
					case "System.Int16":	
						retValue = IntegerValues ("16",item.DbValue,item.FormatString);
						break;
						
					case "System.Int32" :
						retValue = IntegerValues ("32",item.DbValue,item.FormatString);
						break;	
					case "System.Decimal":
						retValue = DecimalValues (item.DbValue,item.FormatString);
						break;

					case "System.Boolean":
						retValue = BoolValue (item.DbValue,item.FormatString);
						break;
					default:
						retValue = item.DbValue;
						break;
				}
			} catch (Exception) {
				throw ;
			}

			return retValue;
		}
		
		public string BoolValue (string toFormat, string format){
			string str = String.Empty;
			if (base.CheckFormat(format) == true) {
				
				if (base.CheckValue (toFormat)) {
					try {
						bool b = bool.Parse (toFormat);
//						bool b = Convert.ToBoolean(toFormat,CultureInfo.CurrentCulture);
						str = b.ToString (CultureInfo.CurrentCulture);
						
					} catch (Exception e) {
						string s = String.Format("\tBool Value < {0} > {1}",toFormat,e.Message);
					System.Console.WriteLine("\t\t{0}",s);
					}
				}
			} else {
				str = toFormat;
			}
			return str;
		}
		
		public  string IntegerValues(string valueType,string toFormat, string format) {
			string str = String.Empty;
			if (base.CheckFormat(format) == true) {
				if (base.CheckValue (toFormat)) {
					try {
						int number;
						switch (valueType) {
							case "16":
								number = Int16.Parse (toFormat,
								                      System.Globalization.NumberStyles.Any,
								                      CultureInfo.CurrentCulture.NumberFormat);
//								number = Convert.ToInt16 (toFormat,NumberFormatInfo.CurrentInfo);
								break;
							case "32" :
								number = Int32.Parse (toFormat,
								                      System.Globalization.NumberStyles.Any,
								                      CultureInfo.CurrentCulture.NumberFormat);
								
//								number = Convert.ToInt32 (toFormat,NumberFormatInfo.CurrentInfo);
								break;
							default:
								throw new ArgumentException("DefaultFormater:IntegerValues Unknown intType ");
								
						}
						str = number.ToString (format);
						
					} catch (Exception e) {
						string s = String.Format("\tDecimalValue < {0} > {1}",toFormat,e.Message);
						System.Console.WriteLine("\t{0}",s);
					}
					return str;
				} else {
					str = (0.0M).ToString();
				}
				
			} else {
				str = toFormat;
			}
			return str;
		}
		
		public  string DecimalValues(string toFormat, string format) {
			string str = String.Empty;
			if (base.CheckFormat(format) == true) {
				
				if (base.CheckValue (toFormat)) {
					try {
						decimal dec =	Decimal.Parse(toFormat,
						                            System.Globalization.NumberStyles.Any,
						                            CultureInfo.CurrentCulture.NumberFormat);
						
//						decimal dec = Convert.ToDecimal (toFormat,NumberFormatInfo.InvariantInfo);
						str = dec.ToString (format);
						
					} catch (Exception e) {
						string s = String.Format("\tDecimalValue < {0} > {1}",toFormat,e.Message);
						System.Console.WriteLine("\t{0}",s);
					}
					return str;
				} else {
					str = (0.0M).ToString();
				}
				
			} else {
				str = toFormat;
			}
			return str;
		}
		
		public  string DateValues(string toFormat, string format) {
			
			if (base.CheckFormat(format) == true) {
				try {
					DateTime date = DateTime.Parse (toFormat.Trim(),
					                                CultureInfo.CurrentCulture.DateTimeFormat);
					string str = date.ToString(format,
					                           DateTimeFormatInfo.CurrentInfo);
					
					return str.Trim();
				} catch (Exception e) {
					string s = String.Format("< {0} > {1}",toFormat,e.Message);
					System.Console.WriteLine("\t\tDateValue {0}",s);
				}
			} else {
				return toFormat.Trim();
			}
			return toFormat.Trim();
		}
	}
}
