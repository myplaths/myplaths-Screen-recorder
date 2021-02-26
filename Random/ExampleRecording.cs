//using AForge.Video;
//using System;
//using System.Drawing;
//using System.Linq;
//using System.Windows;
//using System.Windows.Forms;
//using System.Windows.Input;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;
//using Accord.Video.FFMPEG;
//using AForge.Video.DirectShow;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.IO;
//using MessageBox = System.Windows.Forms.MessageBox;
//using myplaths_Recording_Software.Commands;

//namespace myplaths_Recording_Software
//{
//    public class ExampleRecording:INotifyPropertyChanged
//    {
//        #region Private fields
//        private FilterInfo _currentDevice;
//        private BitmapImage _image;
//        private string _ipCameraUrl;
//        private bool _isDesktopSource;
//        private bool _isIpCameraSource;
//        private bool _isWebcamSource;
//        private IVideoSource _videoSource;
//        private VideoFileWriter _writer;
//        private bool _recording;
//        private DateTime? _firstFrameTime;

//        public event PropertyChangedEventHandler PropertyChanged;
//        #endregion
//        #region Constructor
//        public ExampleRecording()
//        {
//            VideoDevices = new ObservableCollection<FilterInfo>();
//            GetVideoDevices();
//            IsDesktopSource = true;
//            StartSourceCommand = new DelegateCommand(StartCamera);
//            StopSourceCommand = new DelegateCommand(StopCamera);
//            StartRecordingCommand = new DelegateCommand(StartRecording);
//            StopRecordingCommand = new DelegateCommand(StopRecording);
//            SaveSnapshotCommand = new DelegateCommand(SaveSnapshot);
//            IpCameraUrl = "http://88.53.197.250/axis-cgi/mjpg/video.cgi?resolution=320×240";
//        }
//        #endregion
//        #region Properties
//        public ObservableCollection<FilterInfo> VideoDevices { get; set; }
//        public BitmapImage Image
//        {
//            get { return _image; }
//            set { _image = value; OnPropertyChanged(nameof(Image)); }
//        }

//        private void OnPropertyChanged(string v)
//        {
//            throw new NotImplementedException();
//        }

//        public bool IsDesktopSource
//        {
//            get { return _isDesktopSource; }
//            set { _isDesktopSource = value; OnPropertyChanged(nameof(IsDesktopSource)); }
//        }
//        public bool IsWebcamSource
//        {
//            get { return _isWebcamSource; }
//            set { _isWebcamSource = value; OnPropertyChanged(nameof(IsWebcamSource)); }
//        }
//        public bool IsIpCameraSource
//        {
//            get { return _isIpCameraSource; }
//            set { _isIpCameraSource = value; OnPropertyChanged(nameof(IsIpCameraSource)); }
//        }
//        public string IpCameraUrl
//        {
//            get { return _ipCameraUrl; }
//            set { _ipCameraUrl = value; OnPropertyChanged(nameof(IpCameraUrl)); }
//        }
//        public FilterInfo CurrentDevice
//        {
//            get { return _currentDevice; }
//            set { _currentDevice = value; OnPropertyChanged(nameof(CurrentDevice)); }
//        }
//        public ICommand StartRecordingCommand { get; private set; }
//        public ICommand StopRecordingCommand { get; private set; }
//        public ICommand StartSourceCommand { get; private set; }
//        public ICommand StopSourceCommand { get; private set; }
//        public ICommand SaveSnapshotCommand { get; private set; }
//        #endregion
//        private void GetVideoDevices()
//        {
//            var devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
//            foreach(FilterInfo device in devices)
//            {
//                VideoDevices.Add(device);
//            }
//            if(VideoDevices.Any())
//            {
//                CurrentDevice = VideoDevices[0];
//            }
//            else
//            {
//                System.Windows.MessageBox.Show("No webcam found");
//            }
//        }
//        private void StartCamera()
//        {
//            if(IsDesktopSource)
//            {
//                var rectangle = new System.Drawing.Rectangle();
//                foreach(var screen in System.Windows.Forms.Screen.AllScreens)
//                {
//                    rectangle = System.Drawing.Rectangle.Union(rectangle, screen.Bounds);
//                }
//                _videoSource = new ScreenCaptureStream(rectangle);
//                _videoSource.NewFrame += video_NewFrame;
//                _videoSource.Start();
//            }
//            else if(IsWebcamSource)
//            {
//                if(CurrentDevice != null)
//                {
//                    _videoSource = new VideoCaptureDevice(CurrentDevice.MonikerString);
//                    _videoSource.NewFrame += video_NewFrame;
//                    _videoSource.Start();
//                }
//                else
//                {
//                    MessageBox.Show("Current device can't be null");
//                }
//            }
//            else if(IsIpCameraSource)
//            {
//                _videoSource = new MJPEGStream(IpCameraUrl);
//                _videoSource.NewFrame += video_NewFrame;
//                _videoSource.Start();
//            }
//        }
//        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
//        {
//            try
//            {
//                if(_recording)
//                {
//                    using(var bitmap = (Bitmap)eventArgs.Frame.Clone())
//                    {
//                        if(_firstFrameTime != null)
//                        {
//                            _writer.WriteVideoFrame(bitmap, DateTime.Now - _firstFrameTime.Value);
//                        }
//                        else
//                        {
//                            _writer.WriteVideoFrame(bitmap);
//                            _firstFrameTime = DateTime.Now;
//                        }
//                    }
//                }
//            }
//            catch(Exception exc)
//            {
//                MessageBox.Show("Error on _videoSource_NewFrame:\n" + exc.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK,
//                    (MessageBoxIcon)MessageBoxImage.Error);
//                StopCamera();
//            }
//        }
//        private void StopCamera()
//        {
//            if(_videoSource != null && _videoSource.IsRunning)
//            {
//                _videoSource.SignalToStop();
//                _videoSource.NewFrame -= video_NewFrame;
//            }
//            Image = null;
//        }
//        private void StopRecording()
//        {
//            _recording = false;
//            _writer.Close();
//            _writer.Dispose();
//        }
//        private void StartRecording()
//        {
//            var dialog = new SaveFileDialog();
//            dialog.FileName = "Video1";
//            dialog.DefaultExt = ".avi";
//            dialog.AddExtension = true;
//            var dialogresult = dialog.ShowDialog();
//            //if(dialogresult != true)
//            //{
//            //    return;
//            //}
//            _firstFrameTime = null;
//            _writer = new VideoFileWriter();
//            _writer.Open(dialog.FileName, (int)Math.Round(Image.Width, 0), (int)Math.Round(Image.Height, 0));
//            _recording = true;
//        }
//        private void SaveSnapshot()
//        {
//            var dialog = new SaveFileDialog();
//            dialog.FileName = "Snapshot1";
//            dialog.DefaultExt = ".png";
//            var dialogresult = dialog.ShowDialog();
//            //if(dialogresult != true)
//            //{
//            //    return;
//            //}
//            var encoder = new PngBitmapEncoder();
//            encoder.Frames.Add(BitmapFrame.Create(Image));
//            using(var filestream = new FileStream(dialog.FileName, FileMode.Create))
//            {
//                encoder.Save(filestream);
//            }
//        }
//        public void Dispose()
//        {
//            if(_videoSource != null && _videoSource.IsRunning)
//            {
//                _videoSource.SignalToStop();
//            }
//            _writer?.Dispose();
//        }

//        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
//        {
//            SaveFileDialog saveFileDialog = new SaveFileDialog();
//            //if(saveFileDialog.ShowDialog() != true)
//            //    return;
//            //File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);
//        }
//    }
//}
