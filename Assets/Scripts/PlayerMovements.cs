using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayerMovements
    {
        public void Move(PlayerView playerView, float speed, Vector3 _vector)
        {
            playerView.transform.Translate(_vector * speed);
        }
        public void Rotate(PlayerView playerView, float rotate, Vector3 _vector)
        {
            playerView.transform.Rotate(_vector * rotate);
        }
    }
}
