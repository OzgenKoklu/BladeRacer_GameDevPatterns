using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    public float maxSpeed = 2.0f;
    public float turnDistance = 2.0f;
    public float CurrentSpeed { get; set; }

    private string _status;

    void OnEnable()
    {
        RaceEventBus.Subscribe(
        RaceEventType.START, StartBike);
        RaceEventBus.Subscribe(
        RaceEventType.STOP, StopBike);
    }

    void OnDisable()
    {
        RaceEventBus.Unsubscribe(
        RaceEventType.START, StartBike);
        RaceEventBus.Unsubscribe(
        RaceEventType.STOP, StopBike);
    }

    public Direction CurrentTurnDirection
    {
        get; private set;
    }
    private IBikeState
    _startState, _stopState, _turnState;
    private BikeStateContext _bikeStateContext;
    private void Start()
    {
        _bikeStateContext =
new BikeStateContext(this);
        _startState =
        gameObject.AddComponent<BikeStartState>();
        _stopState =
        gameObject.AddComponent<BikeStopState>();
        _turnState =
        gameObject.AddComponent<BikeTurnState>();
        _bikeStateContext.Transition(_stopState);
    }

    private void StartBike()
    {
        _status = "Started";
    }
    private void StopBike()
    {
        _status = "Stopped";
    }

    /*public void StartBike()
    {
        _bikeStateContext.Transition(_startState);
    }
    public void StopBike()
    {
        _bikeStateContext.Transition(_stopState);
    } From the state pattern chapter */

    public void Turn(Direction direction)
    {
        CurrentTurnDirection = direction;
        _bikeStateContext.Transition(_turnState);
    }

    void OnGUI()
    {
        GUI.color = Color.green;
        GUI.Label(
        new Rect(10, 60, 200, 20),
        "BIKE STATUS: " + _status);
    }
}
