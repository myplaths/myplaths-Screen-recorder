using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyPlathsRecordingSoftware.DependencyProperties
{
    public static class MyMouseBehaviour 
    {
        #region Dependecy Property
        private static readonly DependencyProperty MouseDownCommandProperty = DependencyProperty.RegisterAttached
                    (
                        "MouseDownCommand",
                        typeof(ICommand),
                        typeof(MyMouseBehaviour),
                        new PropertyMetadata(MouseDownCommandPropertyChangedCallBack)
                    );
        #endregion

        #region Methods
        public static void SetMouseDownCommand(this UIElement inUIElement, ICommand inCommand)
        {
            inUIElement.SetValue(MouseDownCommandProperty, inCommand);
        }

        private static ICommand GetMouseDownCommand(UIElement inUIElement)
        {
            return (ICommand)inUIElement.GetValue(MouseDownCommandProperty);
        }
        #endregion

        #region CallBack Method
        private static void MouseDownCommandPropertyChangedCallBack(DependencyObject inDependencyObject, DependencyPropertyChangedEventArgs inEventArgs)
        {
            UIElement uiElement = inDependencyObject as UIElement;
            if(null == uiElement) return;

            uiElement.MouseDown += (sender, args) =>
            {
                GetMouseDownCommand(uiElement).Execute(args);
                args.Handled = true;
            };
        }
        #endregion

    }
}
