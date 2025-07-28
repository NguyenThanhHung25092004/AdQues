using UnityEngine;

public class JumpSound : MonoBehaviour
{
    private SimpleCharacterMove scm;
    private void Awake()
    {
        scm = GetComponent<SimpleCharacterMove>();
    }

    private void Update()
    {
        if(scm.jump == true)
        {
            SoundLibrary.instance.PlaySound("Jump");
        }   
    }
}
