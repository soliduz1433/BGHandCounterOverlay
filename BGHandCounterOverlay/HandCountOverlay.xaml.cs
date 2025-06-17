using System.Windows;
using System.Windows.Input;

namespace BGHandCounterOverlay
{
    public partial class HandCountOverlay : Window
    {
        public HandCountOverlay()
        {
            InitializeComponent();
            // Attach the event handler in code
            this.MouseLeftButtonDown += (sender, e) =>
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            };
        }
    }
}
