﻿using System;
using System.Globalization;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.BrowserDisplayBinding;
using MSHelpSystem.Core;

namespace MSHelpSystem
{
	public class BrowserScheme : DefaultSchemeExtension
	{
		public override void GoHome(HtmlViewPane pane)
		{
			if (pane == null) {
				throw new ArgumentNullException("pane");
			}
			DisplayHelp.Catalog();
		}

		public override void GoSearch(HtmlViewPane pane)
		{
			if (pane == null) {
				throw new ArgumentNullException("pane");
			}
			pane.Navigate(new Uri(string.Format(@"http://social.msdn.microsoft.com/Search/{0}", CultureInfo.CurrentCulture.Name.ToLower())));
		}
	}
}
