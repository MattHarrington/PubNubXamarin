// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PubNubXamarin
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton button { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton subButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton unsubButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (button != null) {
				button.Dispose ();
				button = null;
			}
			if (subButton != null) {
				subButton.Dispose ();
				subButton = null;
			}
			if (unsubButton != null) {
				unsubButton.Dispose ();
				unsubButton = null;
			}
		}
	}
}
