using System;
using System.Dynamic;

namespace Mondial.DotNet.Library.Models
{
    public abstract class BaseModel<T>
        where T : BaseModel<T>
    {
        public virtual int Id { get; set; }

        public virtual bool IsNew => Id <= 0;

        public virtual string Display => 
            $"[{this.GetType()}] Id={Id}";
        
        public override string ToString() => Display;

        /*public virtual dynamic ToDynamic()
        {
            dynamic response = new ExpandoObject();
            response.id = Id;
            response.name = Name;
            response.fetch = DateTime.Now;
            return response;
        }*/
    }
}