using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]private AudioClipRefsSO audioClipRefsSO;
    private void Start()
    {
        CuttingCounter.OnCut += CuttingCounter_OnCut;
        KitchenObjectHolder.OnDrop += KitchenObjectHolder_OnDrop;
        KitchenObjectHolder.OnPickup += KitchenObjectHolder_OnPickup;
        TrashCounter.OnObjectTrashed += TrashCounter_OnObjectTrashed;
    }

    private void TrashCounter_OnObjectTrashed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.trash);
    }

    private void KitchenObjectHolder_OnPickup(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.objectPickup);
    }

    private void KitchenObjectHolder_OnDrop(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.objectDrop);
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.chop);
    }
    private void PlaySound(AudioClip[] clips, float volume = 1.0f)
    {
        PlaySound(clips, Camera.main.transform.position);
    }
    private void PlaySound(AudioClip[] clips,Vector3 position,float volume =1.0f)
    {
        

        int index =Random.Range(0,clips.Length);

        AudioSource.PlayClipAtPoint(clips[index], position, volume);
    }
}
