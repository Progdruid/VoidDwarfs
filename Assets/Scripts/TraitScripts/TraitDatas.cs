﻿using UnityEngine;
using System.Collections.Generic;

public class TraitDatas
{
    public abstract class TraitData
    {
        public abstract Trait CreateThisTrait(Structure _structure);
    }

    #region Render

    public abstract class RenderData : TraitDatas.TraitData
    {
        public Sprite MainSprite { get; protected set; }
    }

    public class SimpleRenderData : RenderData
    {
        public SimpleRenderData(Sprite _sprite) => MainSprite = _sprite;

        public override Trait CreateThisTrait(Structure _structure)
        {
            return new SimpleRenderTrait(this, _structure);
        }
    }

    public class TiledRenderData : TraitDatas.RenderData
    {
        public readonly Sprite[] SpriteSet;

        public TiledRenderData(Sprite[] _sprites) 
        {
            MainSprite = _sprites[0];
            SpriteSet = _sprites;
        }

        public override Trait CreateThisTrait(Structure _structure)
        {
            return new TiledRenderTrait(this, _structure);
        }
    }

    #endregion

    public class PropData : TraitDatas.TraitData
    {
        public readonly float Range;

        public PropData(float _range)
        {
            Range = _range;
        }

        public override Trait CreateThisTrait(Structure _structure)
        {
            return new PropTrait(this, _structure);
        }
    }

    public class HealthData : TraitDatas.TraitData
    {
        public readonly int HP;

        public HealthData(int _health)
        {
            HP = _health;
        }

        public override Trait CreateThisTrait(Structure _structure)
        {
            return new HealthTrait(this, _structure);
        }
    }

    public class ExpanderData : TraitDatas.TraitData
    {
        public readonly float Cooldown;

        public ExpanderData(float _cooldown)
        {
            Cooldown = _cooldown;
        }

        public override Trait CreateThisTrait(Structure _structure)
        {
            return new ExpanderTrait(this, _structure);
        }
    }

    public class DiggerData : TraitDatas.TraitData
    {
        public readonly string[] AttackTargets;
        public readonly int DiggingSpeed;
        public readonly float Range;

        public DiggerData(string[] _targets, int _diggingSpeed, float _range)
        {
            AttackTargets = _targets;
            DiggingSpeed = _diggingSpeed;
            Range = _range;
        }

        public override Trait CreateThisTrait(Structure _structure)
        {
            return new DiggerTrait(this, _structure);
        }
    }

    public class VeinData : TraitDatas.TraitData
    {
        public readonly string ResourceName;

        public VeinData (string _resourceName)
        {
            ResourceName = _resourceName;
        }

        public override Trait CreateThisTrait(Structure _structure)
        {
            return new VeinTrait(_structure);
        }
    }

    public class MinerData : TraitData
    {
        public readonly int MineRate;
        public readonly float Range;

        public MinerData (int _efficiency, float _range)
        {
            MineRate = _efficiency;
            Range = _range;
        }

        public override Trait CreateThisTrait(Structure _structure)
        {
            return new MinerTrait(this, _structure);
        }
    }


}
