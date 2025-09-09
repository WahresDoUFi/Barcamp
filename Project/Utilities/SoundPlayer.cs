using Raylib_cs;

namespace Barcamp.Utilities
{
    public enum SoundType
    {
        Barking,
        Meowing,
        Hissing,
        Tweeting,
        Squeaking
    }
    internal static class SoundPlayer
    {
        private static readonly Dictionary<SoundType, Sound> sounds = new()
        {
            { SoundType.Barking, Raylib.LoadSound("Assets/Sounds/barking.wav") },
            { SoundType.Meowing, Raylib.LoadSound("Assets/Sounds/meowing.wav") },
            { SoundType.Hissing, Raylib.LoadSound("Assets/Sounds/hissing.wav") },
            { SoundType.Tweeting, Raylib.LoadSound("Assets/Sounds/tweeting.wav") },
            { SoundType.Squeaking, Raylib.LoadSound("Assets/Sounds/squeaking.wav") },
        };

        public static void Play(SoundType type)
        {
            Raylib.PlaySound(sounds[type]);
        }
    }
}
