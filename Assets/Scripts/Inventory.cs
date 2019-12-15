using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;



namespace Assets.Scripts
{
    public class Inventory
    {        
        private List<GameObject> listGameObjects = new List<GameObject>();
        private List<GameObject> listGameObjectsEquiped = new List<GameObject>();    
        private List<Item> listItemsEquiped = new List<Item>();

        private Player player;
        private int munition = 0;
        private int coin = 0;      
        


        public void SetPlayer(Player _player)
        {
            player = _player;
        }

        public void Add(GameObject item)
        {
            listGameObjects.Add(item);  
        }
        
        public void AddMunition(int amount)
        {
            AudioClip clip1 = Resources.Load<AudioClip>("MentalDreamsAssets/SoldierSoundsPack/reload");
            player.GetComponent<AudioSource>().PlayOneShot(clip1);
            munition += amount;
        }

        public void DecreaseMunition(int amount)
        {
            
            AudioClip clip1 = Resources.Load<AudioClip>("MentalDreamsAssets/SoldierSoundsPack/fire");
            AudioClip clip2 = Resources.Load<AudioClip>("MentalDreamsAssets/SoldierSoundsPack/bulletshells04");
            player.GetComponent<AudioSource>().PlayOneShot(clip1);
            player.GetComponent<AudioSource>().PlayOneShot(clip2);

            munition -= amount;
        }

        public void AddCoin(int amount)
        {
            coin += amount;
        }

        public void UseEquipItem()
        {
            foreach (Item item in listItemsEquiped)
            {               
                item.Use(player);
            }
        }

        public void EquipedItems()
        {
            foreach (GameObject item in listGameObjectsEquiped)           
            {
                if (player.GetSide().Equals("right"))
                {
                    item.transform.position = new Vector3(player.transform.position.x + 1, player.transform.position.y, -2);
                    item.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    item.transform.position = new Vector3(player.transform.position.x - 1, player.transform.position.y, -2);
                    item.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
        }

        public void EquipItem(GameObject item)
        {
            if (item.CompareTag("Gun") && !IsEquiped())
            {
                listItemsEquiped.Add(new Gun());
                listGameObjectsEquiped.Add(item);
            }
        }

        public void RemoveEquipItem(GameObject item)
        {
            listGameObjectsEquiped.Remove(item);          
        }

        public int Contain(string itemName)
        {
            int nbItems = 0;
            foreach (GameObject item in listGameObjects)
            {
                if (item.name.Equals(itemName))
                {
                    nbItems++;
                }
            }
            return nbItems;
        }

        public void Craft()
        {
            if (Input.GetKey("c"))
            {
                AddMunition(50);
            }
        }

        public void Remove(string itemName, int nbRemove)
        {
            int index = 0;
            int nbRemoved = 0;
            List<int> indexes = new List<int>();
            foreach (GameObject item in listGameObjects)
            {
                if (item.name.Equals(itemName))
                {
                    if (nbRemoved < nbRemove)
                    {                       
                        indexes.Add(index);
                        nbRemoved++;
                    }                 
                }
                index++;
            }
            foreach (int i in indexes)
            {
                listGameObjects.RemoveAt(i);
            }
        }

        public bool IsEquiped()
        {
            return listItemsEquiped.Count() > 0;
        }

        public int GetNbMunition()
        {
            return munition;
        }

        public int GetNbCoin()
        {
            return coin;
        }


    }
}
