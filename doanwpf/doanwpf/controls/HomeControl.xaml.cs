using doanwpf.MODEL;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace doanwpf
{
    /// <summary>
    /// Interaction logic for HomeControl.xaml
    /// </summary>
    public partial class HomeControl : UserControl
    {
        private List<string> _imagePaths; // Danh sách đường dẫn ảnh
        private int _currentIndex = 0;    // Ảnh hiện tại
        private DispatcherTimer _slideshowTimer; // Timer để chuyển ảnh
        public HomeControl()
        {
            InitializeComponent();
            LoadImages(); // Gọi hàm để tải danh sách ảnh
            InitializeSlideshow(); // Thiết lập slideshow

        }
        private void LoadImages()
        {
            // Đường dẫn ảnh (sửa lại đường dẫn tùy thuộc vào ứng dụng của bạn)
            _imagePaths = dataprovider.Ins.DB.SANPHAMs
                .Select(sp => sp.FilePath).ToList();
        }

        private void InitializeSlideshow()
        {
            if (_imagePaths == null || _imagePaths.Count == 0)
            {
                MessageBox.Show("Không tìm thấy ảnh để hiển thị.");
                return;
            }

            // Khởi tạo Timer
            _slideshowTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3) // Chuyển ảnh mỗi 3 giây
            };
            _slideshowTimer.Tick += (s, e) => ShowNextImage();
            _slideshowTimer.Start();

            // Hiển thị ảnh đầu tiên
            ShowImage(_currentIndex);
        }

        private void ShowNextImage()
        {
            if (_imagePaths.Count == 0) return;

            // Hiệu ứng mờ dần (fade out)
            var fadeOut = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            fadeOut.Completed += (s, e) =>
            {
                // Cập nhật ảnh khi hiệu ứng mờ dần kết thúc
                _currentIndex = (_currentIndex + 1) % _imagePaths.Count;
                ShowImage(_currentIndex);

                // Hiệu ứng xuất hiện (fade in)
                var fadeIn = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.5)
                };
                slideshowImage.BeginAnimation(UIElement.OpacityProperty, fadeIn);
            };

            slideshowImage.BeginAnimation(UIElement.OpacityProperty, fadeOut);
        }

        private void ShowImage(int index)
        {
            if (_imagePaths == null || _imagePaths.Count == 0) return;

            // Tải ảnh từ đường dẫn
            try
            {
                BitmapImage bitmap = new BitmapImage(new Uri(_imagePaths[index]));
                slideshowImage.Source = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}");
            }
        }

    }
}
