using Foundation;
using LocalAuthentication;
using System;
using UIKit;

namespace TouchIDTest
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            
         
            
            this.btn.TouchUpInside += (sender, e) =>
            {
                var laContext = new LAContext();
                NSError error = new NSError();
                if (laContext.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out error))
                {
                    string reason = "請輸入指紋進行驗證";
                    laContext.EvaluatePolicy(
                        LAPolicy.DeviceOwnerAuthenticationWithBiometrics, 
                        reason, 
                        new LAContextReplyHandler((isSuccess, err) =>
                    {
                        this.InvokeOnMainThread(() =>
                        {
                            if (isSuccess)
                            {
                                lbl.Text = "指紋辨識通過";
                            }
                            else
                            {
                                Console.WriteLine(err.LocalizedDescription);
                                var laError = ((LAStatus)(int)err.Code);
                                switch (laError)
                                {
                                    case LAStatus.SystemCancel:
                                        lbl.Text = "系統取消";
                                        break;
                                    case LAStatus.UserCancel:
                                        lbl.Text = "使用者取消";
                                        break;
                                    case LAStatus.UserFallback:
                                        lbl.Text = "使用者要求輸入密碼(自行定義)";
                                        break;
                                    default:
                                        lbl.Text = "指紋辨識失敗";
                                        break;

                                }
                            }
                        });
                    }));


                }
                else
                {
                    Console.WriteLine(error.LocalizedDescription);//錯誤訊息
                    var laError=((LAStatus)(int)error.Code);

                    switch (laError)
                    {
                        case LAStatus.TouchIDNotEnrolled:
                            lbl.Text = "未設定指紋辨識";
                            break;
                        case LAStatus.PasscodeNotSet:
                            lbl.Text = "未設定密碼";
                            break;
                        default://TouchIDNotAvailable
                            Console.WriteLine("無法使用指紋辨識");
                            break;
                    }
                }



            };


        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }


    }
}