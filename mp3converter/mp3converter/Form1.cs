using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using YoutubeExtractor;
using System.IO;
using System.Threading;
using JDP;
using MediaToolkit.Model;
using MediaToolkit.Options;
using MediaToolkit;
using WMPLib;


namespace mp3converter
{
    public partial class StudyEV : Form
    {
        public StudyEV()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboresolution.SelectedIndex = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "MP3 File (*.mp3)|*.mp3;";
            if (open.ShowDialog() != DialogResult.OK) return;

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "WAV File (*.wav)|*.wav;";
            if (save.ShowDialog() != DialogResult.OK) return;

            using (Mp3FileReader mp3 = new Mp3FileReader(open.FileName))
            {
                using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                {
                    WaveFileWriter.CreateWaveFile(save.FileName, pcm);
                }
            }
        }

        private void btndownload_Click(object sender, EventArgs e)
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            IEnumerable<VideoInfo> videos = DownloadUrlResolver.GetDownloadUrls(txturl.Text);
            VideoInfo video = videos.First(p => p.VideoType == VideoType.Mp4 && p.Resolution == Convert.ToInt32(cboresolution.Text));
            if (video.RequiresDecryption)
                DownloadUrlResolver.DecryptDownloadUrl(video);
            VideoDownloader downloader = new VideoDownloader(video, Path.Combine(Application.StartupPath + "\\", video.Title + video.VideoExtension));
            downloader.DownloadProgressChanged += Downloader_DownloadProgressChanged;
            Thread thread = new Thread(() => { downloader.Execute(); }) { IsBackground = true };
            thread.Start();
        }

        private void Downloader_DownloadProgressChanged(object sender, ProgressEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                progressBar.Value = (int)e.ProgressPercentage;
                lblPercentage.Text = $"{string.Format("{0:0.##}", e.ProgressPercentage)}%";
                progressBar.Update();
            }));
        }

        private void makemp3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "FLV File (*.flv)|*.flv;";
            if (open.ShowDialog() != DialogResult.OK) return;

            FLVFile test = new FLVFile(open.FileName);
            test.ExtractStreams(true, false, false, null);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "MP4 File (*.mp4)|*.mp4;";
            if (open.ShowDialog() != DialogResult.OK) return;

            var inputFile = new MediaFile { Filename = open.FileName };
            var outputFile = new MediaFile { Filename = @"C:\Users\송명진\Desktop\save.flv" };
            
             var player = new WindowsMediaPlayer();
             var clip = player.newMedia(open.FileName);
             //Console.WriteLine(TimeSpan.FromSeconds(clip.duration));

             var conversionOptions = new ConversionOptions
             {
                 MaxVideoDuration = TimeSpan.FromSeconds(clip.duration), //몇초까지 설정할 것인지
                 VideoAspectRatio = VideoAspectRatio.R16_9,
                 VideoSize = VideoSize.Hd1080,
                 AudioSampleRate = AudioSampleRate.Hz44100
             };

             using (var engine = new Engine())
             {
                 engine.Convert(inputFile, outputFile, conversionOptions);
            }
                MessageBox.Show("파일 전환이 완료되었습니다.");
        }

    }
}
