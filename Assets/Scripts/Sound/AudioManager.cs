using UnityEngine;
using System.Collections;

/**
 *
 * Ideas from http://www.blog.silentkraken.com/2010/04/06/audiomanager/
**/

public class AudioManager : MonoBehaviour
{

    // Singleton variables and functions
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = (AudioManager)GameObject.FindObjectOfType(typeof(AudioManager));

                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = "SoundBoard";
                    instance = (AudioManager)container.AddComponent(typeof(AudioManager));
                }
            }
            return instance;
        }
    }





    [SerializeField]
    private GameSound EngineMainThrust;
    [SerializeField]
    private GameSound EngineSideThrust;

    [SerializeField]
    private GameSound LaserType1;
    private GameSound LaserType2;
    private GameSound LaserType3;
    private GameSound LaserType4;

    [SerializeField]
    private GameSound ImpactDamage1;
    [SerializeField]
    private GameSound ImpactDamage2;
    [SerializeField]
    private GameSound ImpactDamage3;

    [SerializeField]
    private GameSound PlayerDied1;
    [SerializeField]
    private GameSound PlayerDied2;
    [SerializeField]
    private GameSound PlayerDied3;


    [SerializeField]
    private GameSound Pickup1;
    [SerializeField]
    private GameSound Pickup2;
    [SerializeField]
    private GameSound Pickup3;

    [SerializeField]
    private GameSound GuiSelect1;

    [SerializeField]
    private GameSound HelpTriggered;
    [SerializeField]
    private GameSound HelpTriggered2;

    [SerializeField]
    private GameSound Explosion1;
    [SerializeField]
    private GameSound Explosion2;
    [SerializeField]
    private GameSound Explosion3;

    [SerializeField]
    private GameSound HelpTrigger;

	[SerializeField]
    private GameSound OpenDoor01;
	[SerializeField]
    private GameSound CloseDoor01;


    public enum Sounds
    {
        ENGINE_THRUST_MAIN,
        ENGINE_THRUST_SIDE,
        LASER_TYPE_1,
        LASER_TYPE_2,
        LASER_TYPE_3,
        LASER_TYPE_4,
        IMPACT_DAMAGE_1,
        IMPACT_DAMAGE_2,
        IMPACT_DAMAGE_3,
        PLAYER_DIED_1,
        PLAYER_DIED_2,
        PLAYER_DIED_3,
        PICKUP_1,
        PICKUP_2,
        PICKUP_3,
        GUI_SELECT_1,
        GUI_SELECT_2,
        GUI_SELECT_3,
        HELP_TRIGGERED_1,
        HELP_TRIGGERED_2,
        EXPLOSION_1,
        EXPLOSION_2,
        EXPLOSION_3,
        OPEN_DOOR_01,
        CLOSE_DOOR_01
    }


    public static void Play(Sounds sound)
    {
        AudioManager.Instance.playSound(sound);
    }

    public static void Play(Sounds sound, AudioSource audioSource)
    {
        AudioManager.Instance.playSound(sound, audioSource);
    }

    private void playSound(Sounds sound)
    {
        playSound(sound, GetComponent<AudioSource>());
    }

    private void playSound(Sounds soundEnum, AudioSource audioSource)
    {

        GameSound sound = getSound(soundEnum);

        if (sound == null)
        {
            Debug.LogError("sound is null.");
            return;
        }
        if (audioSource == null)
        {
            Debug.LogError("audioSource is null. Not playing ["+sound.SoundEffect.name+"]");
            return;
        }

        if (!sound.Enabled)
        {
            Debug.LogError("SoundEffect is disabled. Not playing [" + sound.SoundEffect.name + "]");
            return;
        }




        //Create an empty game object
        GameObject go = new GameObject("Audio: " + sound.SoundEffect.name);
        go.transform.position = transform.position;
        go.transform.parent = transform;

        //Create the source
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = sound.SoundEffect;
        source.volume = sound.Volume;
//        source.pitch = pitch;
        source.Play();
        Destroy(go, sound.SoundEffect.length);
        
        
        
        
//        audioSource.PlayOneShot(sound.SoundEffect, sound.Volume);
    }


    public GameSound getSound(Sounds sound)
    {
        GameSound soundObj = null;


        switch (sound)
        {
            case Sounds.ENGINE_THRUST_MAIN:
            case Sounds.ENGINE_THRUST_SIDE:
                soundObj = EngineMainThrust;
                break;
            case Sounds.LASER_TYPE_1:
            case Sounds.LASER_TYPE_2:
            case Sounds.LASER_TYPE_3:
            case Sounds.LASER_TYPE_4:
                soundObj = LaserType1;
                break;
            case Sounds.IMPACT_DAMAGE_1:
            case Sounds.IMPACT_DAMAGE_2:
                soundObj = ImpactDamage1;
                break;
            case Sounds.IMPACT_DAMAGE_3:
                soundObj = ImpactDamage3;
                break;
            case Sounds.PICKUP_1:
                soundObj = Pickup1;
                break;
            case Sounds.PLAYER_DIED_1:
                soundObj = PlayerDied1;
                break;
            case Sounds.EXPLOSION_1:
                soundObj = Explosion1;
                break;
            case Sounds.EXPLOSION_2:
                soundObj = Explosion2;
                break;
            case Sounds.EXPLOSION_3:
                soundObj = Explosion3;
                break;
                case Sounds.HELP_TRIGGERED_1:
                case Sounds.HELP_TRIGGERED_2:
                soundObj = HelpTrigger;
				break;
			case Sounds.OPEN_DOOR_01:
				case Sounds.CLOSE_DOOR_01:
				soundObj = OpenDoor01;
				break;
        }

        if (soundObj == null)
        {
            Debug.LogWarning("GameSound is null for sound ["+sound+"]");
        }
        return soundObj;
    }


}





