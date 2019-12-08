using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


namespace Assets.Scripts
{
    class Iron : Item
    {

        public override void Craft(Inventory inventory)
        {
            if (Input.GetKey("c"))
            {
                inventory.AddMunition(50);
            }
        }
    }
}
