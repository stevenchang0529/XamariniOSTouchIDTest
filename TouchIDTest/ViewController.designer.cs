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

namespace TouchIDTest
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btn != null) {
                btn.Dispose ();
                btn = null;
            }

            if (lbl != null) {
                lbl.Dispose ();
                lbl = null;
            }
        }
    }
}