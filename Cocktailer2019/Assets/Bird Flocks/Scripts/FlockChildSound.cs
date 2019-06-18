using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class FlockChildSound:MonoBehaviour{
    public AudioClip[] _idleSounds;
    public float _idleSoundRandomChance = .05f;
    
    public AudioClip[] _flightSounds;
    public float _flightSoundRandomChance = .05f;
    
    
    public AudioClip[] _scareSounds;
    public float _pitchMin = .85f;
    public float _pitchMax = 1.0f;
    
    public float _volumeMin = .6f;
    public float _volumeMax = .8f;
    
    // FlockChild _flockChild;
    AudioSource _audio;
    bool _hasLanded;
    
    public void Start() {
    	// _flockChild = GetComponent<FlockChild>();
    	_audio = GetComponent<AudioSource>();
    	InvokeRepeating("PlayRandomSound", Random.value+1, 1.0f);	
    	if(_scareSounds.Length > 0)
    	InvokeRepeating("ScareSound", 1.0f, .01f);
    }
    
    public void PlayRandomSound() {
    	if(gameObject.activeInHierarchy){
    		if(!_audio.isPlaying && _flightSounds.Length > 0 && _flightSoundRandomChance > Random.value){
    			_audio.clip = _flightSounds[Random.Range(0,_flightSounds.Length)];
    			_audio.pitch = Random.Range(_pitchMin, _pitchMax);
    			_audio.volume = Random.Range(_volumeMin, _volumeMax);
    			_audio.Play();
    		}
    	}
    }
    
    public void ScareSound() {	
    if(gameObject.activeInHierarchy){
    	if(_hasLanded && _idleSoundRandomChance*2 > Random.value){
    		_audio.clip = _scareSounds[Random.Range(0,_scareSounds.Length)];
    		_audio.volume = Random.Range(_volumeMin, _volumeMax);
    		_audio.PlayDelayed(Random.value*.2f);
    		_hasLanded = false;
    	}
    	}
    }
}
