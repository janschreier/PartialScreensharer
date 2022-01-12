using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace PartialScreensharerApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly System.Windows.Media.ImageSource _originalImage;
    private int? _height;
    private int _width;
    private int _imageLeftPos;
    private int _imageTopPos;
    private bool _manuallySetArea;

    public MainWindow()
    {
        InitializeComponent();
        Height = SystemParameters.WorkArea.Height;
        Width = SystemParameters.WorkArea.Width / 2;
        Top = SystemParameters.WorkArea.Top;
        Left = SystemParameters.WorkArea.Left;
        _originalImage = Image.Source;
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
                Image.Source = _originalImage;
            }
        }
    }

    private void UpdateImage()
    {
        if (_manuallySetArea is false)
        {
            SetArea();
        }
        using var bitmap = new Bitmap(_width, _height!.Value, PixelFormat.Format32bppArgb);
        using var graphics = Graphics.FromImage(bitmap);
        graphics.CopyFromScreen(_imageLeftPos, _imageTopPos, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
        Image.Source = BitmapToImageSource(bitmap);
    }

    private void SetArea()
    {
        _height = (int)(Image.ActualHeight == 0 ? Height : Image.ActualHeight);
        _width = (int)(Image.ActualWidth == 0 ? Width : Image.ActualWidth);
        _imageLeftPos = (int)(Left + (Width - _width) / 2);
        _imageTopPos = (int)(Top + (Height - _height) / 2);
        if (_manuallySetArea is true)
        {
            SetAreaButton.Content = $"Set Area (currently defined area: {_imageLeftPos}, {_imageTopPos}, {_width}, {_height} )";
        }
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

    private void CloseApp(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    private void SetArea(object sender, RoutedEventArgs e)
    {
        _manuallySetArea = true;
        SetArea();
    }


}
