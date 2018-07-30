using System;
using System.Threading.Tasks;
using CoreGraphics;
using UIKit;

namespace iosApp
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.Title = "Shake Animation";
            this.View.BackgroundColor = UIColor.White;
            var textField = new UITextField(new CGRect(20, 100, 280, 40));
            textField.BackgroundColor = UIColor.Black;
            textField.TextColor = UIColor.White;
            var clickBtn = new UIButton(UIButtonType.Custom);
            clickBtn.SetTitle("Click Me", UIControlState.Normal);
            clickBtn.SetTitleColor(UIColor.Black, UIControlState.Normal);
            clickBtn.Font = UIFont.SystemFontOfSize(14f);
            clickBtn.Frame = new CGRect(20, 160, 280, 40);
            clickBtn.TouchUpInside += async (sender, e) => {
                await AnimateShakeAsync(textField);
            };
            this.View.AddSubview(clickBtn);
            this.View.AddSubview(textField);
        }
        public static async Task AnimateShakeAsync(UITextField view)
        {
            await AnimateHorizontalMovementAsync(view, -10);
            await AnimateHorizontalMovementAsync(view, 20);
            await AnimateHorizontalMovementAsync(view, -20);
            await AnimateHorizontalMovementAsync(view, 20);
            await AnimateHorizontalMovementAsync(view, -15);
            await AnimateHorizontalMovementAsync(view, 10);
            await AnimateHorizontalMovementAsync(view, -5);
        }
        private static async Task AnimateHorizontalMovementAsync(UITextField view, float horizontalOffset)
        {
            await UIView.AnimateAsync(0.065, () => view.Frame =
           new CGRect(new CGPoint(view.Frame.Left + horizontalOffset, view.Frame.Top),
           view.Frame.Size));

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
