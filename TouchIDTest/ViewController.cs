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
                    string reason = "�п�J�����i������";
                    laContext.EvaluatePolicy(
                        LAPolicy.DeviceOwnerAuthenticationWithBiometrics, 
                        reason, 
                        new LAContextReplyHandler((isSuccess, err) =>
                    {
                        this.InvokeOnMainThread(() =>
                        {
                            if (isSuccess)
                            {
                                lbl.Text = "�������ѳq�L";
                            }
                            else
                            {
                                Console.WriteLine(err.LocalizedDescription);
                                var laError = ((LAStatus)(int)err.Code);
                                switch (laError)
                                {
                                    case LAStatus.SystemCancel:
                                        lbl.Text = "�t�Ψ���";
                                        break;
                                    case LAStatus.UserCancel:
                                        lbl.Text = "�ϥΪ̨���";
                                        break;
                                    case LAStatus.UserFallback:
                                        lbl.Text = "�ϥΪ̭n�D��J�K�X(�ۦ�w�q)";
                                        break;
                                    default:
                                        lbl.Text = "�������ѥ���";
                                        break;

                                }
                            }
                        });
                    }));


                }
                else
                {
                    Console.WriteLine(error.LocalizedDescription);//���~�T��
                    var laError=((LAStatus)(int)error.Code);

                    switch (laError)
                    {
                        case LAStatus.TouchIDNotEnrolled:
                            lbl.Text = "���]�w��������";
                            break;
                        case LAStatus.PasscodeNotSet:
                            lbl.Text = "���]�w�K�X";
                            break;
                        default://TouchIDNotAvailable
                            Console.WriteLine("�L�k�ϥΫ�������");
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