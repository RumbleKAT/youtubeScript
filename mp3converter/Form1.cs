using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NAudio.Wave;
using YoutubeExtractor;
using System.IO;
using JDP;
using MediaToolkit.Model;
using MediaToolkit.Options;
using MediaToolkit;
using WMPLib;
using Microsoft.CognitiveServices.SpeechRecognition;



namespace mp3converter
{


    public partial class StudyEV : Form
    {
       
        private DataRecognitionClient m_dataClient;
        private SpeechRecognitionMode m_recoMode = SpeechRecognitionMode.LongDictation;
        public string[] DefaultLocale = { "en-US", "ja-JP", "ko-KR","zh-CN" };
       

        //private string primaryKey1 = "b53923eb9d4a42abb9016f28ce8fb887";
        private string primaryKey2 = "4154a6488c024226a13ecab7f3b3207f";

        private void CreateDataRecoClient()
        {
            m_dataClient = SpeechRecognitionServiceFactory.CreateDataClient(
                m_recoMode,
                itemSelected,
                primaryKey2);

            m_dataClient.OnResponseReceived += this.OnResponseReceivedHandler;
            m_dataClient.OnPartialResponseReceived += this.OnPartialResponseReceivedHandler;
            m_dataClient.OnConversationError += this.OnConversationErrorHandler;

        }

        public StudyEV()
        {
            InitializeComponent();
            initalize();

        }

        private void OnDataDictationResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
        {
            this.WriteLine("--- OnDataDictationResponseReceivedHandler ---");
            if (e.PhraseResponse.RecognitionStatus == RecognitionStatus.EndOfDictation ||
                e.PhraseResponse.RecognitionStatus == RecognitionStatus.DictationEndSilenceTimeout)
            {
              
                 
            }

            WriteResponseResult(e);
        }

        private void WriteResponseResult(SpeechResponseEventArgs e)
        {
            textBox5.AppendText(e.ToString());
            textBox5.ScrollToCaret();
        }



        private void initalize()
        {
            //DataRecognitionClientWithIntent intentDataClient;

            m_dataClient = SpeechRecognitionServiceFactory.CreateDataClient(m_recoMode, itemSelected, primaryKey2);

            // Event handlers for speech recognition results
            m_dataClient.OnResponseReceived += this.OnResponseReceivedHandler;
            m_dataClient.OnPartialResponseReceived += this.OnPartialResponseReceivedHandler;
            m_dataClient.OnConversationError += this.OnConversationErrorHandler;

            comboBox2.Items.AddRange(DefaultLocale);
            comboBox2.SelectedIndex = 0; 

        }

         void OnConversationErrorHandler(object sender, SpeechErrorEventArgs e)
        {
            this.WriteLine("********* Error Detected *********");
            this.WriteLine("{0}", e.SpeechErrorCode.ToString());
            this.WriteLine("{0}", e.SpeechErrorText);
            this.WriteLine();
        }

        private void OnPartialResponseReceivedHandler(object sender, PartialSpeechResponseEventArgs e)
        {
            this.WriteLine("********* Partial Result *********");
            this.WriteLine("{0}", e.PartialResult);
            this.WriteLine();

        }

        private void OnResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
        {
            bool isFinalDicationMessage = m_recoMode == SpeechRecognitionMode.LongDictation &&
                                         (e.PhraseResponse.RecognitionStatus == RecognitionStatus.EndOfDictation ||
                                          e.PhraseResponse.RecognitionStatus == RecognitionStatus.DictationEndSilenceTimeout);
           // MessageBox.Show("S");

            if (!isFinalDicationMessage)
            {
                this.WriteLine("********* Final NBEST Results *********");
                for (int i = 0; i < e.PhraseResponse.Results.Length; i++)
                {
                    this.WriteLine("[{0}] Confidence={1} Text=\"{2}\"",
                                   i, e.PhraseResponse.Results[i].Confidence,
                                   e.PhraseResponse.Results[i].DisplayText);
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\송명진\Desktop\Script2.txt", true))
                    {
                        file.WriteLine(e.PhraseResponse.Results[i].DisplayText);
                    }
                }
                this.WriteLine();
                // 호출이 수십번 완성 
            }


        }

        void OnIntentHandler(object sender, SpeechIntentEventArgs e)
        {
            this.WriteLine("********* Final Intent *********");
            this.WriteLine("{0}", e.Payload);
            this.WriteLine();
        }

        private void WriteLine()
        {
            this.WriteLine(string.Empty);
        }

        private void WriteLine(string format, params object[] args)
        {
            var formattedStr = string.Format(format, args);
            Trace.WriteLine(formattedStr);
            System.Console.WriteLine(formattedStr);
            //MessageBox.Show(formattedStr);

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cboresolution.SelectedIndex = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var inputFile = @"C:\Users\송명진\Desktop\save.mp3";
            var outputFile = @"C:\Users\송명진\Desktop\save.wav";

            using (Mp3FileReader mp3 = new Mp3FileReader(inputFile)) 
            {
                using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                {
                    WaveFileWriter.CreateWaveFile(outputFile, pcm);
                }
            }
            MessageBox.Show("The work is done");
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
           // OpenFileDialog open = new OpenFileDialog();
           // open.Filter = "FLV File (*.flv)|*.flv;";
           // if (open.ShowDialog() != DialogResult.OK) return;

            var outputFile = @"C:\Users\송명진\Desktop\save.flv" ;

            FLVFile test = new FLVFile(outputFile);
            test.ExtractStreams(true, false, false, null);
            MessageBox.Show("mp3 convert is done");

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

        private void MakeText_Click(object sender, EventArgs e)
        {
            //this.MakeText.Enabled = false;
            //bool isReceivedResponse = false;
            int waitSeconds = (m_recoMode == SpeechRecognitionMode.LongDictation) ? 200 : 15;

            // sleep until the final result in OnResponseReceived event call, or waitSeconds, whichever is smaller.

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "WAV File (*.wav)|*.wav;";
            if (open.ShowDialog() != DialogResult.OK) return;

            this.SendAudioHelper(open.FileName);

            CreateDataRecoClient();
            MessageBox.Show("파일 전환이 완료되었습니다.");


        }

        private void SendAudioHelper(string wavFileName)
        {
            using (FileStream fileStream = new FileStream(wavFileName, FileMode.Open, FileAccess.Read))
            {
                // Note for wave files, we can just send data from the file right to the server.
                // In the case you are not an audio file in wave format, and instead you have just
                // raw data (for example audio coming over bluetooth), then before sending up any 
                // audio data, you must first send up an SpeechAudioFormat descriptor to describe 
                // the layout and format of your raw audio data via DataRecognitionClient's sendAudioFormat() method.
                int bytesRead = 0;
                byte[] buffer = new byte[1024];

                try
                {
                    do
                    {
                        // Get more Audio data to send into byte buffer.
                        bytesRead = fileStream.Read(buffer, 0, buffer.Length);

                        // Send of audio data to service. 
                        this.m_dataClient.SendAudio(buffer, bytesRead);
                    }
                    while (bytesRead > 0);
                }
                finally
                {
                    // We are done sending audio.  Final recognition results will arrive in OnResponseReceived event call.
                    this.m_dataClient.EndAudio();
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex >= 0)
            {
                this.itemSelected = comboBox2.SelectedItem as string;
            }

        }

        private string itemSelected;
    }
}
