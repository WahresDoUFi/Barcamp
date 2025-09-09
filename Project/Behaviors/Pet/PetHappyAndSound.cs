using Barcamp.Utilities;

namespace Barcamp.Behaviors.Pet;

public class PetHappyAndSound : IPetBehavior
{
    private readonly SoundType soundType;
    
    public PetHappyAndSound(SoundType soundType)
    {
        this.soundType = soundType;
    }
    public void Pet(Animal animal)
    {
        animal.happiness++;
        SoundPlayer.Play(soundType);
    }
}