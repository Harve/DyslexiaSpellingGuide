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
using System.Speech.Recognition;

namespace DyslexiaSpellingGuide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static SpeechRecognitionEngine engine;
        public MainWindow()
        {
            engine = new SpeechRecognitionEngine();
            engine.SetInputToDefaultAudioDevice();

            engine.LoadGrammar(new DictationGrammar());

            engine.RecognizeAsync(RecognizeMode.Multiple);

            engine.SpeechRecognized += addWord;

            InitializeComponent();
            
        }

        public void addWord(object sender, SpeechRecognizedEventArgs result)
        {
            wordTextBox.Text = (result.Result.Text);
        }
    }
}
