using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTankReplacement : MonoBehaviour
{
    //ESTE SCRIP ES PARA COGEER EL SECUNDARIO
    private bool _inRange;



    public GameObject _oxygenSlot, _runOxygenSlot;
    public GameObject _oxygenDrop;
    public GameObject _mainTank;


    public MeshRenderer _oxygenRender;
    [SerializeField] Color _myColor;
    [SerializeField] Color _myColor2;
    private PlayerInputActions _playerInputActions;
    public Animator _KeepBreathign, _lestGetGoing, _plantFlag;
    private bool _nashe;

    int cont;

    private Vector2 _moveInput;



    public GameObject _player;

    void Start()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.PlayerMov.ChangeTank.started += ChangeTank_started;
        _playerInputActions.PlayerMov.Enable();



        _oxygenRender = GetComponent<MeshRenderer>();
        _inRange = false;

    }

    private void ChangeTank_started(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!PickUpScript._isHolding && GameManager.Instance._holdingMainTank)
        {
            GameManager.Instance.timer2 -= Time.deltaTime;
            if (_inRange)
            {
                if (GameManager.Instance._firstTimeChangeTank && !_nashe)
                {
                    _KeepBreathign.Play("Exit");
                    _lestGetGoing.Play("Entry");
                    _nashe = true;
                }

                if (context.started && GameManager.Instance.timer2 < 0)
                {
                    _mainTank.transform.position = _oxygenDrop.transform.position;
                    GameManager.Instance._holdingSecondaryTank = true;
                    GameManager.Instance._holdingMainTank = false;
                    GameManager.Instance.timer = 0.5f;
                }
            }
        }
    }

    



    void Update()
    {
   
        if(GameManager.Instance._FixedParts == 3 && cont <1)
        {
            
            _lestGetGoing.Play("Exit");
            _plantFlag.Play("Entry");
            cont++;
        }



        //Debug.Log(GameManager.Instance._item);
        SetLimits();

        //_oxygenRender.material.color = Color.Lerp(_myColor, _myColor2, GameManager.Instance._tank2OxygenLevel / 100);
           //Lo explico xq al igual en otro momento ns q he hecho, le digo aqui q puede cambiar de tanke, si el item es igual a null o si no es igual a oxigeno, ya que
           //si lo fuese sinificaria q lo esta sujetando
        if (!PickUpScript._isHolding && GameManager.Instance._holdingMainTank)
        {
            GameManager.Instance.timer2 -= Time.deltaTime;
        }

        if (GameManager.Instance._holdingSecondaryTank)
        {





            if (_moveInput != Vector2.zero)
            {


                transform.eulerAngles = new Vector3(115, _player.transform.eulerAngles.y, 0);
                // transform.eulerAngles = new Vector3 (115, _player.transform.eulerAngles.y, 0);
                //transform.position = _runOxygenSlot.transform.position;
                transform.position = Vector3.Lerp(transform.position, _runOxygenSlot.transform.position, 0.5f);



            }
            else
            {



                transform.eulerAngles = new Vector3(90, _player.transform.eulerAngles.y, 0);
                //   transform.eulerAngles = new Vector3(90, _player.transform.eulerAngles.y, 0);
                //transform.position = _oxygenSlot.transform.position;
                transform.position = Vector3.Lerp(transform.position, _oxygenSlot.transform.position, 0.5f);
                //transform.position = Vector3.Lerp(_runOxygenSlot.transform.position, _oxygenSlot.transform.position, 0.5f);


            }









            this.transform.position = _oxygenSlot.transform.position;
           // this.transform.rotation = Quaternion.Euler(_oxygenDrop.transform.rotation.x + 90, _oxygenDrop.transform.rotation.y, _oxygenDrop.transform.rotation.z);


            //oxygen level goes down
            GameManager.Instance._tank2OxygenLevel -= Time.deltaTime * 2;
        }


    }


    private void SetLimits()
    {
        GameManager.Instance._tank2OxygenLevel = (GameManager.Instance._tank2OxygenLevel >= 100) ? 100 : GameManager.Instance._tank2OxygenLevel;

        GameManager.Instance._tank2OxygenLevel = (GameManager.Instance._tank2OxygenLevel <= 0) ? 0 : GameManager.Instance._tank2OxygenLevel;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            _inRange = true;


        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            _inRange = false;
        }

    }
}
