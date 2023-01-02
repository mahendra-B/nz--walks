using DALayer.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Repo
{
    public class Generic_RepoService<T> : IGenericRepo<T> where T : class
    {
        private NZWalksContext NZ;
        private DbSet<T> table;

        public Generic_RepoService(NZWalksContext NZZ)
        {
            NZ = NZZ;
            table = NZ.Set<T>();
        }
        public void Delete(object id)
        {
            try
            {
                T rec = table.Find();
                
                if (rec != null)
                {
                    table.Remove(rec);
                    NZ.SaveChanges();
                }
                else
                {
                    throw new Exception("Record Not Found");
                }
            }
            catch (CustomExp e)
            {
                if (e.InnerException != null)
                {
                    throw new Exception(e.InnerException.Message);
                }
                else
                {
                    throw new Exception(e.Message);
                }

            }



        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();

        }

        public IEnumerable<T> GetById(object id)
        {
            try
            {
                var Walkrecord = table.Find(id);
                IEnumerable<T> record = new[] { Walkrecord };
                if (Walkrecord != null)
                {
                    return record;
                }
                else
                {
                    throw new Exception("REcord not found...");
                }
            }
            catch(CustomExp e)
            {
                if (e.InnerException != null)
                {
                    throw new Exception(e.InnerException.Message);
                }
                else
                {
                    throw new Exception(e.Message);
                }

            }


        }

                //public T GetById(object id)
                //{
                //    T rec = table.Find(id);
                //    if (rec != null)
                //    {
                //        return table.Find();

                //    }
                //    else
                //    {
                //        throw new Exception("Record NOt Found");
                //    }

                //}

                public void Insert(T obj)
                {
                    table.Add(obj);
                    NZ.SaveChanges();
                }

                public void Update(T obj)
                {
                    table.Attach(obj);
                    NZ.Entry(obj).State = EntityState.Modified;
                    NZ.SaveChanges();

                }
            
} } 
