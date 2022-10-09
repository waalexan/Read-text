using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using Guna.UI;
namespace Readtext
{
    public class speech
    {
        private static SpeechSynthesizer sp = new SpeechSynthesizer();
        public static void speak(string text)
        {
            // Caso ele esteja falando
            if (sp.State == SynthesizerState.Speaking)
                sp.SpeakAsyncCancelAll();
            sp.SpeakAsync(text);
        }
        public static void stop()
        {
            sp.SpeakAsyncCancelAll();
        }
    }
}
