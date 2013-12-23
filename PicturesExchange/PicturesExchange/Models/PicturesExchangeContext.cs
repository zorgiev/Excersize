using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PicturesExchange.Models
{
    public class PicturesExchangeContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PicturesExchangeContext() :
		base(	"Server=e5526dfd-5cae-4920-8df9-a29d012e9a89.sqlserver.sequelizer.com;Database=dbe5526dfd5cae49208df9a29d012e9a89;"+
			"User ID=wqgaqfzrkqizfguu;Password=fkQ8gTZteFgmQdkakD5HGL4o5byANRn4bDUnwULgW55ffRauAtTPtnqBpBcftxNv;")
        {
        }

        public System.Data.Entity.DbSet<PicturesExchange.Models.Picture> Pictures { get; set; }
    
    }
}
