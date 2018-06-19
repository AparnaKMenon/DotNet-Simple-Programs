using System.Windows;
using System.Windows.Forms;

namespace MeetingAssist
{    
    /// Interaction logic for MainWindow.xaml    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        } 
        
        //Function to enable Dragging by clicking on any point on the Window
        private void MainWindowMouseLeftBtnDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            // Begin dragging the window
            this.DragMove();
        }
    }
}
