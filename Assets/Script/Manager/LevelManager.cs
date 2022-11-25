using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LevelsSO _levels;
    [SerializeField] StarBehaviour[] _stars;
    [SerializeField] StarBehaviour[] _endStars;
    [SerializeField] Animator _endSceneAnim;
    [SerializeField] GameObject _uiScene;
    [SerializeField] AudioClip _btnSound;
    [SerializeField] AudioClip[] _starSound;

    AudioSource _audioSource;
    int _starLooted;

    public bool LevelWon { get; set; }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Physics2D.gravity = new Vector2(0f, Physics2D.gravity.y);
    }

    private void Update()
    {
        if (LevelWon)
        {
            Victory();
        }
    }

    private void Victory()
    {
        for (int i = 0; i < _starLooted; i++)
        {
            _endStars[i].IsLooted = true;
        }
        _uiScene.SetActive(false);
        _endSceneAnim.SetTrigger("LevelWon");
    }

    public void NextLevel()
    {
        _levels.CurrentIndex++;
        if (_levels.LevelNames.Length > _levels.CurrentIndex)
        {
            SceneManager.LoadScene(_levels.LevelNames[_levels.CurrentIndex]);
        }
        else
            SceneManager.LoadScene(_levels.MenuName);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        SceneManager.LoadScene(_levels.MenuName);
    }

    public void StarLoot()
    {
        AudioSourcePlay(_starSound[_starLooted]);
        _stars[_starLooted].IsLooted = true;
        _starLooted++;
    }

    public void BtnPushed()
    {
        AudioSourcePlay(_btnSound); 
    }

    public void AudioSourcePlay(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }
}

