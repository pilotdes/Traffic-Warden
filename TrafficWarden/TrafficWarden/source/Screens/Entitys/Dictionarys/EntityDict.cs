using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TrafficWarden.source.Screens.Entitys.Dictionarys
{
    internal class EntityDict
    {
        private static ArrayList entityList = new ArrayList();

        public static void AddEnity(object entity)
        {
            entityList.Add(entity);
            Console.WriteLine(entity);
        }

        public static void RemoveEntity(object entity)
        {
            entityList.Remove(entity);
        }

        public static Boolean EntityExists(object entity)
        {
            Boolean val;
            if (entityList.Contains(entity))
            {
                val = true;
            }
            else
            {
                val = false;
            }
            return val;
        }

        public static int ListSize()
        {
            Console.WriteLine((entityList.Count - 1).ToString());
            return entityList.Count;
        }
    }
}