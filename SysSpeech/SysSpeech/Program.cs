using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Speech.Recognition;

namespace SysSpeech
{
    public class Program
    {
        public static SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();

        public static void Main(string[] args)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "say hello", "print my name" });

            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);

            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammar(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;

            recEngine.RecognizeAsync(RecognizeMode.Multiple);

            recEngine.RecognizeAsyncStop();

            Console.ReadLine();
        }

        public static void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine(e.Result.Text);
        }
    }
}
