using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class MaterialChanger
    {
        private Color _colorPlayer;
        private Color _colorEnemy;
        public Color ColorPlayer
        {
            get => _colorPlayer;
            set => _colorPlayer = value;
        }
        public Color ColorEnemy
        {
            get => _colorEnemy;
            set => _colorEnemy = value;
        }
    public void ChangeColor(MeshRenderer meshRendererPlayer, MeshRenderer meshRendererEnemy)
        {
            meshRendererPlayer.material.SetColor("_Color", Color.red);
            meshRendererEnemy.material.SetColor("_Color", Color.red);
        }
        public void BackColor(MeshRenderer meshRendererPlayer, MeshRenderer meshRendererEnemy)
        {
            meshRendererPlayer.material.SetColor("_Color", _colorPlayer);
            meshRendererEnemy.material.SetColor("_Color", _colorEnemy);
        }

    }
}
