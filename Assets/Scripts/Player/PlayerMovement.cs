using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent (typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{

    //Configurações de movmento da nave que podem ser alteradas
    [Header("Ship Movement Settings ")]
    [SerializeField]
    public float thrust = 100f; //Força de impulso

    [SerializeField]
    public float maxSpeed = 300f; //Velocidade Máxima

    [SerializeField]
    private float yawTorque = 15f; //Força de Rotacao com relacao ao eixo apontado para cima

    [SerializeField]
    private float pitchTorque = 15f; //Força de Rotacao com relacao ao eixo apontado para Lateral

    [SerializeField, Range(0.01f,0.99f)]
    private float yawSensibility = 0.5f;

    [SerializeField, Range(0.01f, 0.99f)]
    private float pitchSensibility = 0.5f;


    //Valores de Entrada
    private float thrustInput;
    private float yawInput;
    private float pitchInput;

    private Rigidbody ship; //Rigidbody da nave


    //Chamado quando o objeto eh instanciado
    private void Awake()
    {
        ship = GetComponent<Rigidbody>();
    }

    //Metodo chamado para atualizações de física
    private void FixedUpdate()
    {
        MovementHandler();
    }

    //Método chamado ao pressionar a tecla de aceleração
    public void OnThrust(InputAction.CallbackContext context)
    {
        thrustInput = context.ReadValue<float>();
    }

    //Método chamado para controlar rotação em relação ao eixo y
    public void OnPitchYaw(InputAction.CallbackContext context)
    {
        Vector2 pitchYawInput = context.ReadValue<Vector2>();

        yawInput = Mathf.Clamp(pitchYawInput.x,-1f,1f);
        pitchInput = Mathf.Clamp(pitchYawInput.y,-1f,1f);
    }

    //Método para cuidar do movimento da nave com base nas entradas
    private void MovementHandler()
    {

        if(Mathf.Abs(thrustInput)>0.1)
        {
            ship.AddRelativeForce(Vector3.forward * thrust * thrustInput);//Acelera a nave em sua direção frontal
        }

        if(Mathf.Abs(yawInput)>yawSensibility)
        {
            ship.AddRelativeTorque(Vector3.up * yawTorque * yawInput);
        }

        if(Mathf.Abs(pitchInput)>pitchSensibility)
        {
            ship.AddRelativeTorque(-Vector3.right * pitchTorque * pitchInput);
        }

        ship.velocity = Vector3.ClampMagnitude(ship.velocity, maxSpeed);//Limita a velocidade máxima
    }

    public void SetThrust(float newThrust)
    {
        thrust = newThrust;
    }

    public void SetMaxSpeed(float newMaxSpeed)
    {
        maxSpeed = newMaxSpeed;
    }

    public float GetMaxSpeed()
    {
        return maxSpeed;
    }

    public float GetThrust()
    {
        return thrust;
    }
}
