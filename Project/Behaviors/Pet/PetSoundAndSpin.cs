using Barcamp.Utilities;

namespace Barcamp.Behaviors.Pet;

public class PetSoundAndSpin : IPetBehavior
{
    private readonly SoundType soundType;
    
    public PetSoundAndSpin(SoundType soundType)
    {
        this.soundType = soundType;
    }
    
    public void Pet(Animal animal)
    {
        SoundPlayer.Play(soundType);
        animal.sprite.Flip();
    }
}