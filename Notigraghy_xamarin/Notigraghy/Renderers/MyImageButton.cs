using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Notigraghy.Renderers
{
    public class MyImageButton : Image
    {
        public static readonly BindableProperty TagProperty = BindableProperty.Create("Tag", typeof(object), typeof(MyImageButton), null);

        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(MyImageButton), null);

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(MyImageButton), null);

        public event EventHandler ItemTapped = (e, a) => { };

        public MyImageButton()
        {
            Initialize();
        }

        public object Tag
        {
            get { return (object)GetValue(TagProperty); }
            set { SetValue(TagProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Added to ensure images are released from memory
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (Equals(base.BindingContext, null))
            {
                base.Source = null;
            }

        }

        private ICommand TransitionCommand
        {
            get
            {
                return new Command(async () =>
                {
                    AnchorX = 0.48;
                    AnchorY = 0.48;
                    await this.ScaleTo(0.8, 50, Easing.Linear);
                    await Task.Delay(100);
                    await this.ScaleTo(1, 50, Easing.Linear);
                    Command?.Execute(CommandParameter);

                    ItemTapped(this, EventArgs.Empty);
                });
            }
        }

        public void Initialize()
        {
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = TransitionCommand
            });
        }
    }


    //public static readonly BindableProperty CommandProperty = BindableProperty.Create<TWImageButton, ICommand>(p => p.Command, null);
    //    public ICommand Command
    //    {
    //        get { return (ICommand)GetValue(CommandProperty); }
    //        set { SetValue(CommandProperty, value); }
    //    }


    //    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create<TWImageButton, object>(p => p.CommandParameter, null);
    //    public object CommandParameter
    //    {
    //        get { return (object)GetValue(CommandParameterProperty); }
    //        set { SetValue(CommandParameterProperty, value); }
    //    }

    //    private ICommand TransitionCommand
    //    {
    //        get
    //        {
    //            return new Command(async () =>
    //            {
    //                this.AnchorX = 0.48;
    //                this.AnchorY = 0.48;
    //                await this.ScaleTo(0.8, 50, Easing.Linear);
    //                await Task.Delay(100);
    //                await this.ScaleTo(1, 50, Easing.Linear);
    //                if (Command != null)
    //                {
    //                    Command.Execute(CommandParameter);
    //                }
    //            });
    //        }
    //    }

    //    public TWImageButton()
    //    {
    //        Initialize();
    //    }


    //    public void Initialize()
    //    {
    //        GestureRecognizers.Add(new TapGestureRecognizer()
    //        {
    //            Command = TransitionCommand
    //        });
    //    }

    //}
}

