using System.Media;

namespace Battleships_V1._06.Audio
{
    public static class MainMenuAudio
    {
        private static SoundPlayer _soundPlayer;
        public static void Play()
        {
            _soundPlayer = new SoundPlayer(Properties.Resources.Intro);
            _soundPlayer.Play();
        }
        public static void Stop()
        {
            _soundPlayer?.Stop();
            _soundPlayer.Dispose();
        }
    }
    public static class WinAudio
    {
        private static SoundPlayer _soundPlayer;
        public static void Play()
        {
            _soundPlayer = new SoundPlayer(Properties.Resources.Win);
            _soundPlayer.Play();
        }
        public static void Stop()
        {
            _soundPlayer?.Stop();
            _soundPlayer.Dispose();
        }
    }
}
