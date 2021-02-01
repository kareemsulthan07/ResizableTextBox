using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ResizableTextBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double prevWidth, prevHeight;
        private Point prevPoint;

        public MainWindow()
        {
            InitializeComponent();

            mainTextBox.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec aliquam justo sit amet porttitor euismod. Sed id lectus dolor. Maecenas consectetur augue ac ante commodo bibendum. Curabitur suscipit, nisi sit amet posuere elementum, mi purus vestibulum massa, a ultricies nunc lorem sit amet lacus. Nam fermentum ligula at dictum cursus. Phasellus dignissim semper blandit. In hac habitasse platea dictumst. Sed id rutrum risus. Donec ac finibus magna, at ornare mauris." +
                                "\n\nQuisque eu risus vitae tortor vehicula elementum.Nullam sodales ipsum felis, ac dictum quam euismod ut. Maecenas tortor quam, vehicula vitae erat eu, ultricies venenatis diam. Donec nec turpis nec neque dictum condimentum.Morbi vestibulum sem ac sapien vehicula congue.Nam varius nibh luctus pharetra vulputate. In consequat tortor ac dolor vehicula consequat.Donec ultrices pharetra metus, eget malesuada nisi interdum quis. Nulla in nulla mi. Aliquam erat volutpat.Vivamus non gravida nisl. Duis eget augue porttitor, rutrum enim in, pellentesque ipsum." +
                                "\n\nVestibulum ultrices, sem vehicula hendrerit dapibus, metus lectus blandit tortor, eget viverra massa lectus quis justo.Donec placerat accumsan mauris, eget placerat ipsum facilisis in. Nam at erat faucibus, eleifend eros ac, consequat dui.Nulla quis odio ut mi efficitur pharetra.Nulla id vestibulum purus. Cras vehicula, ex aliquam lacinia dapibus, neque mauris iaculis nulla, ac feugiat arcu ipsum ac nunc.Cras felis urna, euismod sit amet malesuada ut, interdum nec lectus.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Ut id posuere est. In auctor nibh enim, et pharetra odio tempus eu. Nullam consequat nec sem ac molestie. Quisque in volutpat erat, sit amet imperdiet enim.Ut gravida, lectus varius finibus elementum, nibh mi congue nisi, nec interdum est nibh a enim.Suspendisse sed orci at nulla sagittis convallis nec a dolor. Aliquam vulputate scelerisque erat et vestibulum. Mauris a diam sit amet est commodo ornare." +
                                "\n\nNunc pulvinar tellus vel diam molestie tempus.Nulla suscipit ligula id quam dapibus, vitae luctus nibh iaculis.Proin ac fermentum velit, condimentum lobortis turpis. Nam tristique velit massa, eu rhoncus neque ultricies non. Morbi molestie dui ac metus faucibus dictum.Proin vitae auctor enim, non mattis justo. Donec id dapibus nisl. Ut vulputate auctor viverra." +
                                "\n\nPraesent ipsum nunc, convallis id urna sit amet, tincidunt accumsan ex.Morbi euismod quam in urna volutpat, id venenatis lectus volutpat.Sed posuere ipsum dolor, sed finibus augue varius vehicula. Sed maximus ex mauris, nec vulputate orci feugiat a. Aenean facilisis pretium tempor. Nam a quam iaculis nisi ornare rutrum.Donec eu dui sem. Nunc in iaculis felis. Quisque ultrices vitae lectus eget volutpat.";
        }

        private void resizeGripGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                e.Handled = true;
                Grid grid = (Grid)sender;
                grid.CaptureMouse();

                prevWidth = mainTextBox.ActualWidth;
                prevHeight = mainTextBox.ActualHeight;

                prevPoint = e.GetPosition(null);
            }
            catch (Exception)
            {
            }
        }

        private void resizeGripGrid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Point point = e.GetPosition(null);
                    var xDiff = point.X - prevPoint.X;
                    var yDiff = point.Y - prevPoint.Y;

                    mainTextBox.Width = prevWidth + xDiff;
                    mainTextBox.Height = prevHeight + yDiff;


                    prevWidth = mainTextBox.Width;
                    prevHeight = mainTextBox.Height;
                    prevPoint = e.GetPosition(null); 
                }
            }
            catch (Exception)
            {
            }
        }

        private void resizeGripGrid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                e.Handled = true;
                Grid grid = (Grid)sender;
                grid.ReleaseMouseCapture();

                prevWidth = mainTextBox.ActualWidth;
                prevHeight = mainTextBox.ActualHeight;
            }
            catch (Exception)
            {
            }
        }
    }
}
