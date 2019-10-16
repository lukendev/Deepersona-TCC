using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class AI_Patrulha : MonoBehaviour
{
    public static bool funcionando = true;

    public enum ProtocoloDeDefesa { Patrulhar, Esperar, Perseguir, Combater, Atacar };

    public ProtocoloDeDefesa protocolo;

    public NavMeshAgent defensor;

    public GameObject pontos;

    public Transform[] pontoDePatrulha;

    private Transform alvo = null;

    private int numeroDoPonto;

    public float minDistancia;

    public float tempoParado;

    public bool taAgressivo;

    public ThirdPersonCharacter character;

    public NavMeshAgent agent;

    public GameObject player;

    public float maxDistanciaCombate;

    private Vector3 pontoInicial;

    public float timeToAttack;


    // CAMERAS
    public GameObject enemyCam;
    public GameObject battleCam;

    // ANIMAÇÃO
    Animator anim;

    // Use this for initialization
    void Start()
    {
        pontoDePatrulha = pontos.GetComponentsInChildren<Transform>();
        numeroDoPonto = Random.Range(1, pontoDePatrulha.Length);
        protocolo = ProtocoloDeDefesa.Patrulhar;
        defensor.SetDestination(pontoDePatrulha[numeroDoPonto].position);
        alvo = null;

        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        switch (protocolo)
        {
            case ProtocoloDeDefesa.Patrulhar:
                Patrulhando();
                break;

            case ProtocoloDeDefesa.Esperar: break;

            case ProtocoloDeDefesa.Perseguir: Perseguindo(); break;

            case ProtocoloDeDefesa.Combater: Combatendo(); break;

            case ProtocoloDeDefesa.Atacar: Atacando(); break;

            default: break;
        }

        if(agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        } else
        {
            character.Move(Vector3.zero, false, false);
        }

        /* if (funcionando == false)
        {
            protocolo = ProtocoloDeDefesa.Esperar;
            defensor.isStopped = true;
        }

        if (funcionando == true)
        {
            protocolo = ProtocoloDeDefesa.Patrulhar;
            defensor.isStopped = false;
        } */
    }

    public void Patrulhando()
    {

        Vector3 mag = transform.position - pontoDePatrulha[numeroDoPonto].position;

        if (mag.magnitude <= minDistancia)
        {
            protocolo = ProtocoloDeDefesa.Esperar;
            defensor.isStopped = true;
            StartCoroutine(TempoDeEspera());
        }
    }

    public IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(timeToAttack);
        protocolo = ProtocoloDeDefesa.Atacar;

    }

    public IEnumerator TempoDeEspera()
    {

        yield return new WaitForSeconds(tempoParado);

        numeroDoPonto++;
        if (numeroDoPonto >= pontoDePatrulha.Length)
        {
            numeroDoPonto = 0;
        }

        defensor.SetDestination(pontoDePatrulha[numeroDoPonto].position);
        defensor.isStopped = false;
        protocolo = ProtocoloDeDefesa.Patrulhar;

    }

    public void Atacando()
    {
        enemyCam.SetActive(true);
        battleCam.SetActive(false);

        anim.SetTrigger("AgressivaEnemy");
        protocolo = ProtocoloDeDefesa.Esperar;
    }

    public void Perseguindo()
    {

        defensor.SetDestination(alvo.position);

        Vector3 mag = transform.position - alvo.position;
        if (mag.magnitude <= minDistancia)
        {

        }

    }

    public void IniciarCombate() //para o inimigo para o turno do player
    {
        protocolo = ProtocoloDeDefesa.Esperar;
        defensor.isStopped = true;
    }

    public void IniciarTurno() //inimigo começa a andar
    {
        protocolo = ProtocoloDeDefesa.Combater;
        defensor.isStopped = false;
    }

    public void Combatendo()
    {

        defensor.SetDestination(player.transform.position); ///coloca o inimigo para ir em direção do player

        Vector3 mag1 = transform.position - player.transform.position; ///calcula quanto falta pra chegar no player

        Vector3 mag2 = pontoInicial - transform.position; ///calcula quanto o inimigo já andou


        if (mag1.magnitude <= maxDistanciaCombate) //se o inimigo está a pelo menos 1 andada de chegar no player, ele para
        {
            protocolo = ProtocoloDeDefesa.Esperar; //para o inimigo
            defensor.isStopped = true;
        }

        if (mag2.magnitude >= maxDistanciaCombate) //se o inimigo passou do limite de andar, ele para
        {
            protocolo = ProtocoloDeDefesa.Esperar; //para o inimigo
            defensor.isStopped = true;
            
            StartCoroutine(WaitAttack());
        }

    }

    public void OnTriggerEnter(Collider col)
    {
       
        if (col.gameObject.CompareTag("Player")&&(taAgressivo))
        {
            alvo = col.transform;
            defensor.isStopped = false;
            StopAllCoroutines();
            protocolo = ProtocoloDeDefesa.Perseguir;
            defensor.SetDestination(alvo.position);
            return;
        }

    }
   
}
