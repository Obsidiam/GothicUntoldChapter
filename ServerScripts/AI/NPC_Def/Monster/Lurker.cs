﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GUC.Server.Scripting.Objects.Character;
using GUC.Enumeration;
using GUC.Server.Scripts.AI.Enumeration;

namespace GUC.Server.Scripts.AI.NPC_Def.Monster
{
    public class Lurker: NPC
    {
        public Lurker()
            : base()
        {
            Name = "Lurker";

            Strength = 60;
            Dexterity = 60;
            HPMax = 120;
            HP = 120;

            
            setProtection(DamageTypeIndex.DAM_INDEX_BLUNT, 60);
            setProtection(DamageTypeIndex.DAM_INDEX_POINT, 60);
            setProtection(DamageTypeIndex.DAM_INDEX_EDGE, 60);
            setProtection(DamageTypeIndex.DAM_INDEX_FIRE, 60);
            setProtection(DamageTypeIndex.DAM_INDEX_FLY, 60);

            setDamageType(DamageType.DAM_EDGE);

            WeaponMode = 1;




            this.setVisual("Lurker.mds", "Lur_Body", 0, 0, "", 0, 0);

            this.InitNPCAI();

            this.setGuild(Guilds.MON_LURKER);

            CreateVob();
        }
    }
}
