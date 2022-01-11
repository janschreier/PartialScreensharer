using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace PartialScreensharerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Height = SystemParameters.WorkArea.Height;
            Width = SystemParameters.WorkArea.Width / 2;

            Top = SystemParameters.WorkArea.Top;
            Left = SystemParameters.WorkArea.Left;
            _ = RunUpdateImageTask();
        }


        private async Task RunUpdateImageTask()
        {
            while (true)
            {
                await Task.Delay(200);

                if (!IsActive)
                {
                    WarningText.Visibility = Visibility.Collapsed;
                    UpdateImage();
                }
                else
                {
                    WarningText.Visibility = Visibility.Visible;
                }
            }
        }

        private void UpdateImage()
        {
            var height = (int)(Image.ActualHeight == 0 ? Height : Image.ActualHeight);
            var width = (int)(Image.ActualWidth == 0 ? Width : Image.ActualWidth);
            var imageLeftPos = (int)(Left + (Width - width) / 2);
            var imageTopPos = (int)(Top + (Height - height) / 2);

            using var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using var graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(imageLeftPos, imageTopPos, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
            Image.Source = BitmapToImageSource(bitmap);
        }


        private static BitmapImage BitmapToImageSource(Image bitmap)
        {
            using var memory = new MemoryStream();
            bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
            memory.Position = 0;
            var bitmapimage = new BitmapImage();
            bitmapimage.BeginInit();
            bitmapimage.StreamSource = memory;
            bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapimage.EndInit();
            return bitmapimage;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    }


}
