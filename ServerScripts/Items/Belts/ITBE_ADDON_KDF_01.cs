﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GUC.Server.Scripting.Objects;
using GUC.Server.Scripting.Objects.Character;

namespace GUC.Server.Scripts.Items.Belts
{
    public class ITBE_ADDON_KDF_01 : AbstractBelts
    {
        static ITBE_ADDON_KDF_01 ii;
        public static ITBE_ADDON_KDF_01 get()
        {
            if (ii == null)
                ii = new ITBE_ADDON_KDF_01();
            return ii;
        }


        protected ITBE_ADDON_KDF_01()
            : base("ITBE_ADDON_KDF_01")
        {
            Description = "Schärpe des Feuers";
            Visual = "ItMi_Belt_02.3ds";


            OnEquip += new Scripting.Events.NPCEquipEventHandler(equip);
            OnUnEquip += new Scripting.Events.NPCEquipEventHandler(unequip);

            CreateItemInstance();
        }

        protected void equip(NPCProto npc, Item item)
        {
            npc.ProtectionEdge += 5;
            npc.ProtectionBlunt += 5;
            npc.ProtectionPoint += 5;
        }

        protected void unequip(NPCProto npc, Item item)
        {
            npc.ProtectionEdge -= 5;
            npc.ProtectionBlunt -= 5;
            npc.ProtectionPoint -= 5;
        }
    }
}
