using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    private readonly PlayerView _currentView;
    public MeshRenderer MeshRendererPlayer => _meshRenderer;

    public event EventHandler<(GameObject, string)> CollisionHappaned;
    public event EventHandler<(GameObject, string)> CollisionStay;
    public event EventHandler<(GameObject, string)> CollisionExit;

    //public event EventHandler<PlayerView> PlayerSpawned;

    private void OnCollisionEnter(Collision collision)
    {
        CollisionHappaned?.Invoke(this, (collision.gameObject, collision.transform.tag));
    }
    private void OnCollisionStay(Collision collision)
    {
        CollisionStay?.Invoke(this, (collision.gameObject, collision.transform.tag));
    }
    private void OnCollisionExit(Collision collision)
    {
        CollisionExit?.Invoke(this, (collision.gameObject, collision.transform.tag));
    }
    /*private void GetPlayerView(PlayerView playerView)
    {
        PlayerSpawned?.Invoke(this, _currentView);
        return;
    }*/
}

