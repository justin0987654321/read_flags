using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_vibrate : MonoBehaviour
{
    
    [Header("Info")]
    private Vector3 _startPos;
    private float _timer;
    private Vector3 _randomPos;
    private Vector3 _currentPos;
    [Header("Settings")]
    [Range(0f, 2f)]
    public float _time = 0.2f;
    [Range(0f, 2f)]
    public float _distance = 0.1f;
    [Range(0f, 0.1f)]
    public float _delayBetweenShakes = 0f;

    public bool _pos_check = false;
    // Start is called before the first frame update
    private void OnValidate()
    {
        if (_delayBetweenShakes > _time)
            _delayBetweenShakes = _time;
    }

    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Shake()
    {
        _timer = 0f;

        while (_timer < _time)
        {
          

            _timer += Time.deltaTime;

            _randomPos = _startPos + (Random.insideUnitSphere * _distance);

            transform.position = _randomPos;

            /*yield return new WaitForSeconds(_delayBetweenShakes);
            sprite_ren.color = new Color(1, 0, 0, 1);
            yield return new WaitForSeconds(_delayBetweenShakes);
            sprite_ren.color = new Color(1, 1, 1, 1);*/
        }
        if (_delayBetweenShakes > 0f)
        {
            yield return new WaitForSeconds(_delayBetweenShakes);
        }

        else
        {

            yield return null;
        }
       //  _startPos = new Vector3(_startPos.x + 0.2f, _startPos.y, _startPos.z);
       
        transform.position = _startPos; // = transform.position;
        _pos_check = true;
        
    }
    public void shake_Call()
    {
        StartCoroutine(Shake());
    }
}
