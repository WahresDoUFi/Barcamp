using Barcamp.Utilities;

namespace Barcamp.Behaviors.Pet;

public class PetSound : IPetBehavior
{
    private readonly SoundType soundType;
    
    public PetSound(SoundType soundType)
    {
        this.soundType = soundType;
    }
    public void Pet(Animal animal)
    {
        SoundPlayer.Play(soundType);
    }
}